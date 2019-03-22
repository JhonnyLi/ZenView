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
        for (var i = 0; i < 1; i++) {
         rows.push(<CommentBox key={i} />);
        }
        return (
            <div>
                <AlertTicker ticker={this.props.store} />
                {rows}
            </div>
        );
    }
}

function render() {
    ReactDOM.render(<MainContainer store={Main.Redux.Store.getState()} />, document.getElementById('content'));
}
setInterval(render, 1000);
