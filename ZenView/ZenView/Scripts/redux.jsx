Main.Redux = (() => {
    let reducer = (state, action) => {
        debugger;
        if (state === undefined) {
            $.getJSON('https://zenview.zendesk.com/api/v2/search.json?query=type:ticket status:open').done(function (data) {
                console.log(data);
            }).fail((err) => { console.log(err); });
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