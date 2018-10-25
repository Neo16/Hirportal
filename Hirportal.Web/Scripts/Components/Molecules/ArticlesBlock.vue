<template>
    <div class="article-block">
        <div v-if="!block.isLeadBlock" class="d-flex article-block-header">
            <p class="article-block-title">{{block.name}}</p>          
        </div>
        <div class="row article-block-content">
            <articlecell v-for="cell in block.cells"
                         :key="cell.article.id"
                         v-bind:article="cell.article"
                         v-bind:cellSize="cell.cellSize">
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