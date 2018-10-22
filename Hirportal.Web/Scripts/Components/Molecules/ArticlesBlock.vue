<template>
    <div>
        <articlecell 
              v-for="cell in cells"
              :key="cell.displayId"
              v-bind:article="cell.article">
        </articlecell>
    </div>
</template>

<script>  
    import articlecell from '../Atoms/ArticleCell'
    export default {
        components: {
            articlecell
        },
        props: ['cells']
    }
</script>