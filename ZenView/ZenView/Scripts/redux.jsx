Main.Redux = (() => {
    let reducer = (state = 0, action) => {
        if (action === undefined) return state;
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