'use strict';
var connection = $.connection.theHub;

Main.SignalR = (function () {
    var button = $("#signalRbtn");
    var chat = $("#signalRchat");
    var userId;

    connection.client.online = function (date, tickets) {
        console.log(tickets);
        button.text("User connected: " + date);
    };

    connection.client.broadcast = function (user, message) {
        chat.text(chat.text() + user + ": " + message);
    };

    connection.client.message = function (user, message) {
        chat.text(user + ": " + message);
    };

    let connectionSuccessful = function (user) {
        userId = user.id;
        console.log(user.id);
        connection.server.connected(user.id, "Torgny");
        connection.server.send("Torgny", "Här e ja");
        //connection.server.sendToUser("maga-dog", "Ett meddelande");
        button.addClass("btn btn-success");
        //button.text("Connected");
    };

    let connectionFailed = function () {
        button.addClass("btn btn-danger");
        button.text("Connection failed");
    };


    // Init scripts
    let init = function () {
        console.log("SignalR Initialized");
        $.connection.hub.start()
            .done(connectionSuccessful)
            .fail(connectionFailed);
    };
    return {
        Init: init,
        Button: button
    };
})();


$(function () {
    Main.SignalR.Init();
});
