'use strict';

Main.Redux = (function () {
    var reducer = function reducer(state, action) {
        debugger;
        if (state === undefined) {
            $.getJSON('https://zenview.zendesk.com/api/v2/search.json?query=type:ticket status:open').done(function (data) {
                console.log(data);
            }).fail(function (err) {
                console.log(err);
            });
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
                return state + 1;
            case 'DECREMENT':
                return state - 1;
            default:
                return state;
        }
    };
    var store = window.Redux.createStore(reducer);
    var increment = function increment() {
        store.dispatch({ type: 'INCREMENT' });
    };
    var decrement = function decrement() {
        store.dispatch({ type: 'DECREMENT' });
    };

    var init = function init() {
        console.log("Redux Init");
        store.subscribe(function () {
            return render();
        });
    };
    return {
        Init: init,
        Store: store,
        Increment: increment,
        Decrement: decrement
    };
})();

$(function () {
    Main.Redux.Init();
});

$("#signalRbtn").click(Main.Redux.Increment);

