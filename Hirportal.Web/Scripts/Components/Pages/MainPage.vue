<template>
    <div>
        <!-- Lead block -->
        <div class="mt-2">
            <articlesblock v-if="leadBlock"
                           v-bind:block="leadBlock"
                           v-bind:key="leadBlock.id">
            </articlesblock>
        </div>
        <!-- Sub blocks -->
        <articlesblock v-for="(subBlock, index) in subBlocks"
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
                });
        }
    }
</script>