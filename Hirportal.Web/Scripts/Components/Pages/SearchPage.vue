<template>
    <div class="mt-4">
        <search-panel ref="searchPanel"></search-panel>

        <div v-if="isSearching.value" class="mt-3">
            <h3>Keresés...</h3>
        </div>
        <div v-if="hasItems(articles)" class="row article-block-content">
            <articlecell v-for="article in articles"
                         :key="article.id"
                         v-bind:article="article"
                         v-bind:cellSize="1">
            </articlecell>
        </div>
        <div v-if="!(isSearching.value) && !hasItems(articles)">
            <h3>Nincs találat a cikkek között.</h3>
        </div>
    </div>   
</template>

<script>  
    import articlecell from '../Atoms/ArticleCell';
    import { store } from '../../store';
    import searchPanel from '../Atoms/SearchPanel';

    export default {
        components: {
            articlecell,
            searchPanel
        },
        data: function () {          
            return {                
                articles: store.state.searchResultArticles,
                isSearching: store.state.isSearching
            }
        }, 
        methods: {
            hasItems: function(a) {
                return (a != null && a.length > 0);
            }
        }       
    }
</script>