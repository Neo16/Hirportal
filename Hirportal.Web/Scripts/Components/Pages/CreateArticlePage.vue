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
        },
        computed: {

        },
        methods: {
            postArticle() {
                axios({
                    method: 'post',
                    url: config.apiRoot + '/admin/create-article',
                    data: this.$data.article,
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }                  
                }).then(res => {
                    alert('Success');                   
                }).catch(err => {
                    alert(`There was an error submitting your form. See details: ${err}`);
                });
            }
        }
    }
</script>
