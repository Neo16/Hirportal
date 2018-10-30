<template>
    <div v-if="column" class="row article-block-content">
        <articlecell v-for="article in column"
                        :key="article.id"
                        v-bind:article="article"
                        v-bind:cellSize="2">
        </articlecell>
    </div>

</template>

<script>
    import axios from 'axios';
    import { config } from '../../config';
    import articlecell from '../Atoms/ArticleCell'

    export default {
        components: {
            articlecell
        },
        data: function () {
            return {
               column: null
            }
        },
        mounted() {
            axios
                .get(config.apiRoot + '/column/' + this.$route.params.columnName)
                .then(response => {
                    this.column = response.data;                    
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        }
    }
</script>