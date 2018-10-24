<template>
    <div>
        <div class="row mt-3">
            <div class="col-md-8 lead-article-box">
                <img class="lead-article-img" src="http://placehold.it/900x600" />
                <p class="lead-article-title">Végre van vezércikk az új hírportálon</p>
            </div>                       
        </div>
        <articlesblock 
            v-for="(block, index) in blocks"
            v-bind:block="block"        
            v-bind:key="block.id">
        </articlesblock>
    </div>
</template>

<script>
    import articlesblock from '../Molecules/ArticlesBlock.js';
    import { config } from '../../config';
    import axios from 'axios';
    
    export default {
        components: {
            articlesblock
        },
        data: function () {
            return {
                blocks: []                
            }
        },
        mounted() {          
            axios
                .get(config.apiRoot + '/mainpage')
                .then(response => (this.blocks = response.data.blocks))
        }
    }
</script>