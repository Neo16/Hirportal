<template>
    <div>
        <h1>Main page</h1>
        <articlesblock 
            v-for="(block, index) in blocks"
            v-bind:cells="block.cells"        
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