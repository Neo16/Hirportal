<template>
    <transition name="modal" v-if="visible">
        <div class="modal-mask">
            <div class="modal-wrapper">
                <div class="modal-container">

                    <div class="modal-header text-info">
                        <slot name="header">
                            default header
                        </slot>
                    </div>

                    <div class="modal-body">
                        <slot name="body">
                            default body
                        </slot>
                    </div>

                    <div class="modal-footer">
                        <button class="btn btn-outline-info modal-default-button" @click="ok()">
                            {{positiveButtonText}}
                        </button>
                        <button v-if="hasNegativeButton" class="btn btn-outline-info modal-default-button" @click="cancel()">
                            {{negativeButtonText}}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </transition>
</template>

<script>    
    export default {
        props: {
            hasNegativeButton: {
                type: Boolean,
                default: false
            },
            positiveButtonText: {
                type: String,
                default: 'Igen'
            },
            negativeButtonText: {
                type: String,
                default: 'Mégse'
            }           
        },        
        methods: {
            ok: function () {
                this.visible = false;
                this.$emit('ok');
            },
            cancel: function () {
                this.visible = false;
                this.$emit('cancel');
            },
            show() {
                this.visible = true;
            },
            hide() {
                this.visible = false;
            }        
        },
        data: function () {
            return {
                visible: false
            }
        }
    }
</script>