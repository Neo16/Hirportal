<div>

    <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" />

    <p class="article-title">{{article.title}}</p>
    <p class="article-thumbnail-content">{{article.}} </p>
</div>

<script>
    import articlecell from '../Atoms/ArticleCell'
    export default {
        props: {
            'article'
        }
    }
</script>