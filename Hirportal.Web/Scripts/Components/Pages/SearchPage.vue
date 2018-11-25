<template>
    <div class="mt-4 d-flex flex-column">
        <search-panel ref="searchPanel"></search-panel>
        <div class="align-self-end">
            <button @click="searchArticles()" class="btn btn-outline-info">Keresés</button>
        </div>
        <div v-if="searchState.isSearching" class="mt-3">
            <h3>Keresés...</h3>
        </div>
        <div v-if="hasItems(searchState.resultArticles)" class="row article-block-content mt-4">
            <articlecell v-for="article in searchState.resultArticles"
                         :key="article.id"
                         v-bind:article="article"
                         v-bind:cellSize="1">
            </articlecell>
        </div> 
        <b-pagination v-if="hasItems(searchState.resultArticles)"
                      align="center" size="lg" class="mt-4"
                      :total-rows="searchState.totalResultNum" 
                      v-model="currentPage" 
                      :per-page="searchPagination.pageLength">
        </b-pagination>
        
        <div v-if="!(searchState.isSearching) && !hasItems(searchState.resultArticles)">
            <h3>Nincs találat a cikkek között.</h3>
        </div>
    </div>   
</template>

<script>  
    import articlecell from '../Atoms/ArticleCell';
    import { store } from '../../store';
    import searchPanel from '../Atoms/SearchPanel';
    import { actions } from '../../actions';  

    export default {
        components: {
            articlecell,
            searchPanel
        },
        data: function () {         
            return {        
                currentPage: 1,
                searchState: store.state.searchState,
                searchPagination: store.state.searchPagination            
            }
        }, 
        methods: {
            hasItems: function(a) {
                return (a != null && a.length > 0);
            },
            searchArticles() {
                this.currentPage = 1;
                store.setSearchPagination({
                    pageStart: 0,
                    pageLength: 21
                });
                store.setSearchParams(this.$refs.searchPanel.searchParams);
                actions.searchArticles();               
            }                
        },
        watch: {
            currentPage: function (newCurrentPage, oldCurrentPage) {
                store.setSearchPagination({
                    pageStart: ((newCurrentPage -1) * this.searchPagination.pageLength),
                    pageLength: this.searchPagination.pageLength
                });               
                actions.searchArticles();
            }
        }          
    }
</script>