let Main = (function () {
    let init = function () {
        console.log("Main Initialized");
        $("#zendesk-login").click(function () {
            $.get("https://zenview.zendesk.com/oauth/authorizations/new?response_type=code&redirect_uri=&client_id=zenview_agent&scope=read").done(function (response) {
                console.log("Response: ", response);
            });
        });
    };
    
    return {
        Init: init
    };
})();

$(function () {
    Main.Init();
});

//https://zenview.zendesk.com/oauth/authorizations/new?response_type=code&redirect_uri=&client_id=zenview_agent&scope=read