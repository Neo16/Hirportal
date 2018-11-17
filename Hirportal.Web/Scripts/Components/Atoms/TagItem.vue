<template>
    <div class="tag-item" @click="searchTag()">
        {{tag.name}}
    </div>
</template>

<script>
    import { actions } from '../../actions';  
    import { store } from '../../store';

    export default {
        props: ['tag'],     
        methods: {
            searchTag: function () {
                store.setSearchPagination({
                    pageStart: 0,
                    pageLength: 21
                });
                store.setSearchParams({
                    tags: [this.tag],
                    freeTextParam: '' 
                });
                actions.searchArticles();
                this.$router.push('/search');
            }
        }
    }
</script>