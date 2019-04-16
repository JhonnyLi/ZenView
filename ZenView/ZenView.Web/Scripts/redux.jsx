Main.Redux = (() => {
    let ticketReducer = (state = [], action) => {
        console.log("Ticket reducer");
        console.log(action);
        if (action === undefined)
            return state;
        switch (action.type) {
            case 'INIT_TICKETS':
                return Object.assign({}, action.state);
            case 'DECREMENT':
                return state - 1
            default:
                return state
        }
    };
    let userReducer = (state = [], action) => {
        console.log("User reducer");
        if (action === undefined)
            return state;
        switch (action.type) {
            case 'INIT_USERS':
                return action.state;
            default:
                return state
        }
    };
    let settingReducer = (state = {}, action) => {
        console.log("Setting reducer");
        if (action === undefined)
            return state;
        switch (action.type) {
            case 'SHOW_COMPONENT':
                return [...state, { "show_component" : true }]
            default:
                return state
        }
    };
    var rootReducer = Redux.combineReducers({ tickets: ticketReducer, users: userReducer, settings: settingReducer });
    var store = window.Redux.createStore(rootReducer);
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