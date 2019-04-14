'use strict';
var connection = $.connection.theHub;

Main.SignalR = (function () {
    var button = $("#signalRbtn");
    var chat = $("#signalRchat");
    
    var userId;

    connection.client.online = function (date, tickets) {
        console.log(tickets);
        button.text("User connected: " + date);
        var ticker = $("#alert-ticker").children().first()[0];
        console.log(ticker);
        ticker.innerHTML = date;
    };
    //zenUser
    connection.client.receiveTickets = function (tickets) {
        Main.Redux.store.dispatch({ type: 'INCREMENT' });
    }
    connection.client.broadcast = function (user, message) {
        chat.text(chat.text() + user + ": " + message);
    };

    connection.client.message = function (user, message) {
        chat.text(user + ": " + message);
    };

    let connectionSuccessful = function (user) {
        userId = user.id;
        console.log(user.id);
        var cookies = document.cookie.split(';').filter(name => name.startsWith("zenUser"))[0];
        var cookie = cookies.substring(cookies.indexOf('=') + 1);
        connection.server.getTickets(cookie);
        //connection.server.connected(user.id, "Torgny");
        //connection.server.send("Torgny", "Här e ja");
        
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
