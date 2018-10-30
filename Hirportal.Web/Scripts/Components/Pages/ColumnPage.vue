<template>
    <div v-if="blocks">
        <p>Block</p>
    </div>
</template>

<script>
    import axios from 'axios';
    import { config } from '../../config';

    export default {
        data: function () {
            return {
               blocks: []
            }
        },
        mounted() {
            axios
                .get(config.apiRoot + 'column/' + this.$route.params.columnName)
                .then(response => {
                    this.blocks = response.data;
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        }
    }
</script>