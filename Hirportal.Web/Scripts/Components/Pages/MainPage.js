;(function(){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _ArticlesBlock = require('../Molecules/ArticlesBlock.js');

var _ArticlesBlock2 = _interopRequireDefault(_ArticlesBlock);

var _config = require('../../config');

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
    components: {
        articlesblock: _ArticlesBlock2.default
    },
    data: function data() {
        return {
            blocks: []
        };
    },
    mounted: function mounted() {
        var _this = this;

        axios.get(_config.config.apiRoot + '/mainpage').then(function (response) {
            return _this.blocks = response.data.blocks;
        });
    }
};
})()
if (module.exports.__esModule) module.exports = module.exports.default
var __vue__options__ = (typeof module.exports === "function"? module.exports.options: module.exports)
if (__vue__options__.functional) {console.error("[vueify] functional components are not supported and should be defined in plain js files using render functions.")}
__vue__options__.render = function render () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',_vm._l((_vm.blocks),function(block,index){return _c('articlesblock',{key:block.id,attrs:{"cells":block.cells}})}))}
__vue__options__.staticRenderFns = []
if (module.hot) {(function () {  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), true)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-867fdbc4", __vue__options__)
  } else {
    hotAPI.reload("data-v-867fdbc4", __vue__options__)
  }
})()}