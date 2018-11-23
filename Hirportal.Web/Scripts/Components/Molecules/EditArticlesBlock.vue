<template>    
    <div class="edit-articles-block">
        <div class="d-flex justify-content-between">
            <p class="block-title">{{block.name}}</p>
            <font-awesome-icon @click="$emit('remove')" icon="trash" class="pointer" />
        </div>
        <edit-article-cell v-for="cell in block.cells"
                           :key="cell.article.id"
                           v-on:remove="removeCell(cell.article.id)"
                           v-bind:cell="cell">
        </edit-article-cell>
        <button class="btn btn-outline-info align-self-start" @click="$emit('addCell')">
            Cikk hozzáadása
        </button>
    </div>      
</template>

<script>
    import EditArticleCell from '../Atoms/EditArticleCell';  

    export default {
        components: {
            EditArticleCell          
        },
        props: ['block', 'allArticles'],
        methods: {
            removeCell(id) {
                let index = this.block.cells.findIndex(x => x.article.id == id);
                this.$delete(this.block.cells, index);
            }
        },

    }
</script>