let Main = (function () {
    let init = function () {
        console.log("Main Initialized");
    };
    
    return {
        Init: init
    };
})();

$(function () {
    Main.Init();
});

