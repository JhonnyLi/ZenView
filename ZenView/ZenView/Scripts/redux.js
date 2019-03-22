'use strict';

Main.Redux = (function () {
    var reducer = function reducer(state, action) {
        if (state === undefined) state = 0;

        if (action === undefined) return state;
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

