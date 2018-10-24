<template>
    <div>
        <div class="row mt-3">
            <template v-if="leadBlock">
                <div class="col-sm-12 col-md-8 lead-article-box">
                    <img class="lead-article-img" src="http://placehold.it/900x600" />
                    <p class="lead-article-title">Végre van vezércikk az új hírportálon</p>
                    <p class="lead-article-thumbnail-content">{{leadBlock.cells[0].article.thumbnailContent}}</p>
                </div>

                <articlecell class="col-sm-12 col-lg-4"                           
                             v-bind:article="leadBlock.cells[1].article">
                </articlecell>

                <articlecell class="col-sm-6 col-lg-3"
                                v-for="cell in leadBlock.cells.slice(2)"
                                :key="cell.article.id"
                                v-bind:article="cell.article">
                </articlecell>
            </template>
        </div>
        <articlesblock 
            v-for="(subBlock, index) in subBlocks"
            v-bind:block="subBlock"        
            v-bind:key="subBlock.id">
        </articlesblock>
    </div>
</template>

<script>
    import articlesblock from '../Molecules/ArticlesBlock.js';
    import articlecell from '../Atoms/ArticleCell'
    import { config } from '../../config';
    import axios from 'axios';
    
    export default {
        components: {
            articlesblock,
            articlecell
        },
        data: function () {
            return {
                subBlocks: [],
                leadBlock: null
            }
        },
        mounted() {          
            axios
                .get(config.apiRoot + '/mainpage')
                .then(response => {
                    this.subBlocks = response.data.blocks;
                    this.leadBlock = response.data.leadBlock;
                })
        }
    }
</script>