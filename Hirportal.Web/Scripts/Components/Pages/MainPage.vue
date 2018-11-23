<template>
    <div>   
        <!--blocks -->
        <articlesblock class="mt-2"
                       v-for="(subBlock, index) in blocks"
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
                blocks: [],                
            }
        },
        mounted() {                        
            axios
                .get(config.apiRoot + '/mainpage')
                .then(response => {
                    this.blocks = response.data.blocks;                 
                });
        }
    }
</script>