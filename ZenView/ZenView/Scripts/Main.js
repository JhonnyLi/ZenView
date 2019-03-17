let Main = (function () {
    //let funcProxy = new Proxy(signalRInit, function (test) {
    //    console.log("Inside proxy");
    //    test();
    //});
    // Init scripts
    let init = function () {
        console.log("Main Initialized");
        //Main.SignalR.Init();
    };

    return {
        Init: init
    };
})();

$(function () {
    Main.Init();
});

