<template>
    <div>
        <articleform v-bind:article="article"
                     v-on:save-article="postArticle">
        </articleform>
        <p>{{article.HtmlContent}}</p>
    </div>
</template>
<script>

    import articleform from '../Molecules/ArticleForm.js'

    export default {
        components: {
            articleform
        },
        data: function () {
            {
                return {
                    article: {
                        Title: '',
                        CoverImageUrl: '',
                        ThumbnailContent: '',
                        HtmlContent: ''
                    }
                }
            }
        },
        computed: {

        },
        methods: {
            postArticle() {
                alert('todo');
            }
        }
    }
</script>
