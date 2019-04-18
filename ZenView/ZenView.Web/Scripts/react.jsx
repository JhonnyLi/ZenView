'use strict'

const { Provider, connect } = ReactRedux;

class AlertTicker extends React.Component {
    render() {
        return (
            <div id="alert-ticker">
                <span>Status ticker {this.props.ticker}</span>
            </div>
        );
    }
}

class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">{new Date().toLocaleTimeString()}.</div>
        );
    }
}

class MainContainer extends React.Component {
    render() {
        var rows = Main.Redux.Store.getStore().tickets;
        for (var i = 0; i < rows.length; i++) {
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
    ReactDOM.render(<Provider store={Main.Redux.Store}/>, document.getElementById('content'));
}
setInterval(render, 1000);
