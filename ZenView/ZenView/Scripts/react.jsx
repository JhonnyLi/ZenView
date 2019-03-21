
function counter(state = 0, action) {
    switch (action.type) {
        case 'INCREMENT':
            return state + 1
        case 'DECREMENT':
            return state - 1
        default:
            return state
    }
}

let store = window.Redux.createStore(counter);

//store.subscribe(() => console.log(store.getState()));
store.subscribe(()=>render())
//store.dispatch({ type: 'INCREMENT' });


console.log("React initialized");

//let funcProxy = new Proxy(signalRInit, function () {
//    console.log("Inside proxy");
//});

var test = function () {
    store.dispatch({ type: 'INCREMENT' });
}

$("#signalRbtn").click(test);

class AlertTicker extends React.Component {
    render() {
        return (
            <div id="alert-ticker">
                <span> 22:51 mto.se - https://www.mto.se/ Your site went down! {this.props.ticker}</span>
            </div>
        );
    }
}

class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">Hello, world! {new Date().toLocaleTimeString()}.</div>
        );
    }
}

class MainContainer extends React.Component {
    render() {
        var rows = [];
        //for (var i = 0; i < 10; i++) {
            // note: we add a key prop here to allow react to uniquely identify each
            // element in this array. see: https://reactjs.org/docs/lists-and-keys.html
           // rows.push(<CommentBox key={i} />);
        //}
        return (
            <div>
                <AlertTicker ticker={this.props.store} />
            </div>
        );
    }
}


function render() {
    ReactDOM.render(<MainContainer store={store.getState()} />, document.getElementById('content'));
}

setInterval(render, 1000);
