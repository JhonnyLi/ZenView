Main.Redux = (() => {
    let reducer = (state, action) => {
        debugger;
        if (state === undefined) {
            var test = createCORSRequest('GET', 'https://zenview.zendesk.com/api/v2/search.json?query=type:ticket status:open');
            console.log(test);
            debugger;
            if (test) {
                state = test;
            }
            //$.getJSON('https://zenview.zendesk.com/api/v2/search.json?query=type:ticket status:open').done(function (data) {
            //    console.log(data);
            //}).fail((err) => { console.log(err); });
            //$.ajax({
            //    url: 'https://zenview.zendesk.com/api/v2/search.json?query=type:ticket status:open',
            //    contentType: 'application/json',
            //    type: 'GET'
            //}).done(function (data) {
            //    console.log(data.results);
            //    state = data.results;
            //});
            return state;
        }
        console.log("Reducers reduce");
        switch (action.type) {
            case 'INCREMENT':
                return state + 1
            case 'DECREMENT':
                return state - 1
            default:
                return state
        }
    };

    function createCORSRequest(method, url) {
        var xhr = new XMLHttpRequest();
        if ("withCredentials" in xhr) {

            // Check if the XMLHttpRequest object has a "withCredentials" property.
            // "withCredentials" only exists on XMLHTTPRequest2 objects.
            xhr.open(method, url, true);

        } else if (typeof XDomainRequest != "undefined") {

            // Otherwise, check if XDomainRequest.
            // XDomainRequest only exists in IE, and is IE's way of making CORS requests.
            xhr = new XDomainRequest();
            xhr.open(method, url);

        } else {

            // Otherwise, CORS is not supported by the browser.
            xhr = null;

        }
        return xhr;
    }

    //var xhr = createCORSRequest('GET', url);
    //if (!xhr) {
    //    throw new Error('CORS not supported');
    //}


    var store = window.Redux.createStore(reducer);
    var increment = () => { store.dispatch({ type: 'INCREMENT' }); };
    var decrement = () => { store.dispatch({ type: 'DECREMENT' }); };

    var init = function () {
        console.log("Redux Init");
        store.subscribe(() => render());
    };
    return {
        Init: init,
        Store: store,
        Increment: increment,
        Decrement: decrement
    }
})();

$(function () {
    Main.Redux.Init();
});

$("#signalRbtn").click(Main.Redux.Increment);