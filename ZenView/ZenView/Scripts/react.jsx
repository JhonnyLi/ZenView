console.log("React initialized");

let funcProxy = new Proxy(signalRInit, function () {
    console.log("Inside proxy");
});



class AlertTicker extends React.Component {
    render() {
        return (
            <div id="alert-ticker">
                <span> 22:51 mto.se - https://www.mto.se/ Your site went down!</span>
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
        for (var i = 0; i < numrows; i++) {
            // note: we add a key prop here to allow react to uniquely identify each
            // element in this array. see: https://reactjs.org/docs/lists-and-keys.html
            rows.push(<CommentBox key={i} />);
        }
        return (
            <div>
                <AlertTicker />
                <div>
                    {rows}
                </div>
            </div>
        );
    }
}


function tick() {
    ReactDOM.render(<MainContainer />, document.getElementById('content'));
}

setInterval(tick, 1000);
