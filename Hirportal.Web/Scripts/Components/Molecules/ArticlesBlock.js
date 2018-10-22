;(function(){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _ArticleCell = require('../Atoms/ArticleCell');

var _ArticleCell2 = _interopRequireDefault(_ArticleCell);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
    components: {
        articlecell: _ArticleCell2.default
    },
    props: ['cells']
};
})()
if (module.exports.__esModule) module.exports = module.exports.default
var __vue__options__ = (typeof module.exports === "function"? module.exports.options: module.exports)
if (__vue__options__.functional) {console.error("[vueify] functional components are not supported and should be defined in plain js files using render functions.")}
__vue__options__.render = function render () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',_vm._l((_vm.cells),function(cell){return _c('articlecell',{key:cell.displayId,attrs:{"article":cell.article}})}))}
__vue__options__.staticRenderFns = []
if (module.hot) {(function () {  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), true)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7065c574", __vue__options__)
  } else {
    hotAPI.rerender("data-v-7065c574", __vue__options__)
  }
})()}