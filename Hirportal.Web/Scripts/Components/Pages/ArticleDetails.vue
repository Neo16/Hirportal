<template>
    <div v-if="article" class="article-details">
        <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" />
        <div class="author-block d-flex justify-content-between">
            <div class="author-name">{{article.authorName}}</div>
            <div class="publish-date">{{article.publishDate | moment("YYYY.MM.DD hh:mm")}}</div>
        </div>
        <div class="article-title">szerző: {{article.title}}</div>
        <div class="article-body" v-html="article.htmlContent"></div>
    </div>
</template>

<script>
    import axios from 'axios';
    import { config } from '../../config';

    export default {
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