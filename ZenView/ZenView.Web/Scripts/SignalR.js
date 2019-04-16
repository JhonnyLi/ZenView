'use strict';
var connection = $.connection.theHub;

Main.SignalR = (function () {
    var button = $("#signalRbtn");
    var chat = $("#signalRchat");
    
    var userId;

    connection.client.online = function (date, tickets) {
        button.text("User connected: " + date);
        var ticker = $("#alert-ticker").children().first()[0];
    };
    //zenUser
    //Clients.Caller.receiveState(vm.Tickets, vm.Users);
    connection.client.receiveState = function (tickets, users) {
        var tick = JSON.stringify(tickets);
        var userr = JSON.stringify(users);
        Main.Redux.Store.dispatch({ type: 'INIT_TICKETS',state: tickets }); 
        Main.Redux.Store.dispatch({ type: 'INIT_USERS', state: users });
        console.log(tick);
        console.log(userr);
    };

    let connectionSuccessful = function (user) {
        var cookie = Cookies.get("ZenViewG");
        connection.server.connected(user.id, cookie);
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
