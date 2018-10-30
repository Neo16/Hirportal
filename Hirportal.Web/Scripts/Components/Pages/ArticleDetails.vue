<template>

    <p> Hello There.</p>
</template>

<script>
    import axios from 'axios';
    export default {
        props: {
            title: String,
            htmlContent: String
        },
        mounted() {
            axios
                .get(config.apiRoot + '/articles/' + this.$router.params.articleId)
                .then(response => {
                    this.title = response.data.title;
                    this.htmlContent = response.data.htmlContent;
                });
        }
    }
</script>