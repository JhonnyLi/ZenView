'use strict';

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

var _get = function get(_x, _x2, _x3) { var _again = true; _function: while (_again) { var object = _x, property = _x2, receiver = _x3; _again = false; if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { _x = parent; _x2 = property; _x3 = receiver; _again = true; desc = parent = undefined; continue _function; } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var _ReactRedux = ReactRedux;
var Provider = _ReactRedux.Provider;
var connect = _ReactRedux.connect;

var AlertTicker = (function (_React$Component) {
    _inherits(AlertTicker, _React$Component);

    function AlertTicker() {
        _classCallCheck(this, AlertTicker);

        _get(Object.getPrototypeOf(AlertTicker.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(AlertTicker, [{
        key: "render",
        value: function render() {
            return React.createElement(
                "div",
                { id: "alert-ticker" },
                React.createElement(
                    "span",
                    null,
                    " 22:51 mto.se - https://www.mto.se/ Your site went down! ",
                    this.props.ticker
                )
            );
        }
    }]);

    return AlertTicker;
})(React.Component);

var CommentBox = (function (_React$Component2) {
    _inherits(CommentBox, _React$Component2);

    function CommentBox() {
        _classCallCheck(this, CommentBox);

        _get(Object.getPrototypeOf(CommentBox.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(CommentBox, [{
        key: "render",
        value: function render() {
            return React.createElement(
                "div",
                { className: "commentBox" },
                new Date().toLocaleTimeString(),
                "."
            );
        }
    }]);

    return CommentBox;
})(React.Component);

var MainContainer = (function (_React$Component3) {
    _inherits(MainContainer, _React$Component3);

    function MainContainer() {
        _classCallCheck(this, MainContainer);

        _get(Object.getPrototypeOf(MainContainer.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(MainContainer, [{
        key: "render",
        value: function render() {
            var rows = [];
            for (var i = 0; i < 1; i++) {
                rows.push(React.createElement(CommentBox, { key: i }));
            }
            return React.createElement(
                Provider,
                { store: Main.Redux.Store },
                React.createElement(
                    "div",
                    null,
                    React.createElement(AlertTicker, { ticker: this.props.store }),
                    rows
                )
            );
        }
    }]);

    return MainContainer;
})(React.Component);

function render() {
    ReactDOM.render(React.createElement(MainContainer, { store: Main.Redux.Store.getState() }), document.getElementById('content'));
}
setInterval(render, 1000);

