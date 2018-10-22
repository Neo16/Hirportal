<template>   
    <div>
        <h1>Example Form</h1>
        <div>
            <p>
                <label>Full Name</label>
                <input type="text" placeholder="Enter your full name" v-model="FullName" />
            </p>

            <p>
                <label>Email</label>
                <input type="text" placeholder="Enter your email" v-model="Email" />
                <span class="invalid-input" v-show="InvalidEmail">Invalid Email</span>
            </p>

            <p>
                <label>Comments</label>
                <vue-editor v-model="Comments"></vue-editor>
            </p>

            <div id="form-buttons">
                <button type="button" class="danger" v-on:click="ResetForm">Reset Form</button>
                <button type="button" class="success" ref="SubmitButton" v-bind:disabled="isSubmitDisabled" v-on:click="SubmitForm">
                    Submit Form
                </button>
            </div>
            <testcomponent v-bind:text="FullName">
            </testcomponent>
        </div>
    </div>
</template>

<script>
    import { validateEmail } from '../../utils';
    import { VueEditor } from 'vue2-editor';
    import TestComponent from '../TestComponent.js';

    export default {
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
    }
</script>
