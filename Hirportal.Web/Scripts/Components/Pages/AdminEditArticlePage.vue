<template>
    <div>
        <articleform v-bind:article="article"
                     v-on:save-article="postArticle">
        </articleform>
    </div>
</template>
<script>

    import articleform from '../Molecules/ArticleForm.js';
    import { config } from '../../config';
    import axios from 'axios';
    import { store } from '../../store';

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
                        HtmlContent: '',
                        PublishDate: '',
                        ArchiveDate: '',
                        Column: {
                            Id: ''
                        },
                        Tags: []
                    }
                }
            }
        }, mounted() {
            axios
                .get(config.apiRoot + '/admin/articles/' + this.$route.params.articleId)
                .then(response => {
                    console.log(response.data);
                    this.article.Title = response.data.title;
                    this.article.CoverImageUrl = response.data.coverImageUrl;
                    this.article.HtmlContent = response.data.htmlContent;
                    this.article.PublishDate = response.data.publishDate;
                    this.article.ArchiveDate = response.data.archiveDate;
                    this.article.Column.Id = response.data.column.id;
                    this.article.Tags = response.data.tags;
                    this.article.ThumbnailContent = response.data.thumbnailContent;
                    console.log(this.article);
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        },
        computed: {

        },
        methods: {
            postArticle() {
                axios({
                    method: 'post',
                    url: config.apiRoot + '/admin/update-article/' + this.$route.params.articleId,
                    data: {
                        article : this.$data.article
                    },

                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                }).then(res => {
                    this.$router.push('/admin/articles');
                }).catch(err => {
                    alert(`There was an error submitting your form. See details: ${err}`);
                });
            }
        }
    }
</script>
