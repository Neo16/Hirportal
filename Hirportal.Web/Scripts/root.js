import { validateEmail } from './utils';
import { VueEditor } from 'vue2-editor';
import TestComponent from './Components/testComponent.js';

new Vue({
    el: '#form',
    components: {
        VueEditor,
        'testcomponent': TestComponent
    },
    data: {
        FullName: '',
        Email: '',
        Comments: '',
        InvalidEmail: false,
        content: ''
    },
    computed: {
        isSubmitDisabled() {
            let isDisabled = true;

            if (
                this.FullName !== '' &&
                this.Email !== '' &&
                this.Comments !== ''
            ) {
                isDisabled = false;
            }

            return isDisabled;
        }
    },
    methods: {
        ResetForm() {
            this.FullName = '';
            this.Email = '';
            this.Comments = '';
        },
        SubmitForm() {
            let submit = true;

            if (!validateEmail(this.Email)) {
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
                }).then(res => {
                    alert('Successfully submitted feedback form ');
                    this.$refs.SubmitButton.setAttribute("disabled", "disabled");
                }).catch(err => {
                    alert(`There was an error submitting your form. See details: ${err}`);
                });
            }
        }
    }   
});