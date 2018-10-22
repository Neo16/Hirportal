;(function(){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _utils = require('../../utils');

var _vue2Editor = require('vue2-editor');

var _TestComponent = require('../TestComponent.js');

var _TestComponent2 = _interopRequireDefault(_TestComponent);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
    components: {
        VueEditor: _vue2Editor.VueEditor,
        'testcomponent': _TestComponent2.default
    },
    data: {
        FullName: '',
        Email: '',
        Comments: '',
        InvalidEmail: false,
        content: ''
    },
    computed: {
        isSubmitDisabled: function isSubmitDisabled() {
            var isDisabled = true;

            if (this.FullName !== '' && this.Email !== '' && this.Comments !== '') {
                isDisabled = false;
            }

            return isDisabled;
        }
    },
    methods: {
        ResetForm: function ResetForm() {
            this.FullName = '';
            this.Email = '';
            this.Comments = '';
        },
        SubmitForm: function SubmitForm() {
            var _this = this;

            var submit = true;

            if (!(0, _utils.validateEmail)(this.Email)) {
                this.InvalidEmail = true;
                submit = false;
            } else {
                this.InvalidEmail = false;
            }

            if (submit) {
                axios({
                    method: 'post',
                    url: '/Home/SubmitedForm',
                    data: this.$data
                }).then(function (res) {
                    alert('Successfully submitted feedback form ');
                    _this.$refs.SubmitButton.setAttribute("disabled", "disabled");
                }).catch(function (err) {
                    alert('There was an error submitting your form. See details: ' + err);
                });
            }
        }
    }
};
})()
if (module.exports.__esModule) module.exports = module.exports.default
var __vue__options__ = (typeof module.exports === "function"? module.exports.options: module.exports)
if (__vue__options__.functional) {console.error("[vueify] functional components are not supported and should be defined in plain js files using render functions.")}
__vue__options__.render = function render () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',[_c('h1',[_vm._v("Example Form")]),_vm._v(" "),_c('div',[_c('p',[_c('label',[_vm._v("Full Name")]),_vm._v(" "),_c('input',{directives:[{name:"model",rawName:"v-model",value:(_vm.FullName),expression:"FullName"}],attrs:{"type":"text","placeholder":"Enter your full name"},domProps:{"value":(_vm.FullName)},on:{"input":function($event){if($event.target.composing){ return; }_vm.FullName=$event.target.value}}})]),_vm._v(" "),_c('p',[_c('label',[_vm._v("Email")]),_vm._v(" "),_c('input',{directives:[{name:"model",rawName:"v-model",value:(_vm.Email),expression:"Email"}],attrs:{"type":"text","placeholder":"Enter your email"},domProps:{"value":(_vm.Email)},on:{"input":function($event){if($event.target.composing){ return; }_vm.Email=$event.target.value}}}),_vm._v(" "),_c('span',{directives:[{name:"show",rawName:"v-show",value:(_vm.InvalidEmail),expression:"InvalidEmail"}],staticClass:"invalid-input"},[_vm._v("Invalid Email")])]),_vm._v(" "),_c('p',[_c('label',[_vm._v("Comments")]),_vm._v(" "),_c('vue-editor',{model:{value:(_vm.Comments),callback:function ($$v) {_vm.Comments=$$v},expression:"Comments"}})],1),_vm._v(" "),_c('div',{attrs:{"id":"form-buttons"}},[_c('button',{staticClass:"danger",attrs:{"type":"button"},on:{"click":_vm.ResetForm}},[_vm._v("Reset Form")]),_vm._v(" "),_c('button',{ref:"SubmitButton",staticClass:"success",attrs:{"type":"button","disabled":_vm.isSubmitDisabled},on:{"click":_vm.SubmitForm}},[_vm._v("\n                Submit Form\n            ")])]),_vm._v(" "),_c('testcomponent',{attrs:{"text":_vm.FullName}})],1)])}
__vue__options__.staticRenderFns = []
if (module.hot) {(function () {  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), true)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-370d6f40", __vue__options__)
  } else {
    hotAPI.reload("data-v-370d6f40", __vue__options__)
  }
})()}