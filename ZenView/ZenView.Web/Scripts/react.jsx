'use strict'

const { Provider, connect } = ReactRedux;

class AlertTicker extends React.Component {
    render() {
        return (
            <div id="alert-ticker">
                <span>Status ticker</span>
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
        var rows = [];
        for (var i = 0; i < 1; i++) {
            rows.push(<CommentBox key={i} />);
        }
        return (
            <Provider store={Main.Redux.Store}>
                <div>
                    <AlertTicker ticker={this.props.store} />
                    {rows}
                </div>
            </Provider>
        );
    }
}

function render() {
    ReactDOM.render(<MainContainer store={Main.Redux.Store.getState()} />, document.getElementById('content'));
}
setInterval(render, 1000);
