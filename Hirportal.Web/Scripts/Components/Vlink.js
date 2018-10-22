;(function(){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _Home = require('./Pages/Home.js');

var _Home2 = _interopRequireDefault(_Home);

var _FormExample = require('./Pages/FormExample.js');

var _FormExample2 = _interopRequireDefault(_FormExample);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var routes = {
    '/': _Home2.default,
    '/form': _FormExample2.default
};
exports.default = {
    props: {
        href: {
            type: String,
            required: true
        }
    },
    computed: {
        isActive: function isActive() {
            return this.href === this.$root.currentRoute;
        }
    },
    methods: {
        go: function go(event) {
            event.preventDefault();
            this.$root.currentRoute = this.href;
            window.history.pushState(null, routes[this.href], this.href);
        }
    }
};
})()
if (module.exports.__esModule) module.exports = module.exports.default
var __vue__options__ = (typeof module.exports === "function"? module.exports.options: module.exports)
if (__vue__options__.functional) {console.error("[vueify] functional components are not supported and should be defined in plain js files using render functions.")}
__vue__options__.render = function render () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('a',{class:{ active: _vm.isActive },attrs:{"href":_vm.href},on:{"click":_vm.go}},[_vm._t("default")],2)}
__vue__options__.staticRenderFns = []
if (module.hot) {(function () {  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), true)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7bb992e3", __vue__options__)
  } else {
    hotAPI.reload("data-v-7bb992e3", __vue__options__)
  }
})()}