<template>
    <div v-if="article" class="article-details">
        <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" />
        <p class="article-title">{{article.title}}</p>
        <p v-html="article.htmlContent"></p>
    </div>
</template>

<script>
    import axios from 'axios';
    import { config } from '../../config';

    export default {
        props: {
            htmlContent: String
        },
        data: function () {
            return {
               article: null
            }
        },
        mounted() {           
            axios
                .get(config.apiRoot + '/articles/' + this.$route.params.articleId)
                .then(response => {
                    this.article = response.data;
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        }
    }
</script>