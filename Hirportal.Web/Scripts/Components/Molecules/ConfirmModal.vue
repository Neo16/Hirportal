<template>
    <transition name="modal">
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
                        <button class="btn btn-outline-info modal-default-button" @click="$emit('close')">
                            Igen
                        </button>                        
                    </div>
                </div>
            </div>
        </div>
    </transition>
</template>

<script>    
    export default {
       
    }
</script>