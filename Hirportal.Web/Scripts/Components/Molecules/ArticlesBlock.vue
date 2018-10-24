<template>
    <div class="article-block">
        <div class="d-flex article-block-header">
            <p class="article-block-title">{{block.name}}</p>
            <div></div>
        </div>
        <div class="row article-block-content">
            <articlecell class="col-sm-6 col-lg-3"
                         v-for="cell in block.cells"
                         :key="cell.displayId"
                         v-bind:article="cell.article">
            </articlecell>
        </div>       
    </div>
</template>

<script>
    import articlecell from '../Atoms/ArticleCell'
    export default {
        components: {
            articlecell
        },
        props: ['block']
    }
</script>