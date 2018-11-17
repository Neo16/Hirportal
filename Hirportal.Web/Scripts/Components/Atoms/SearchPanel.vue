<template>
    <div>
        <div class="form-group mt-4">
            <v-select :placeholder="'címkék'" multiple v-model="searchParams.tags" label="name" :options="tags"></v-select>
        </div>
        <div class="form-group mt-4">
            <input placeholder="szabad szöveg" v-model="searchParams.freeTextParam" class="form-control" rows="3" />
        </div>
    </div>     
</template>

<script>
    import { store } from '../../store';
    import vSelect from 'vue-select'; 
    import axios from 'axios';
    import { config } from '../../config';

    export default {      
        components: {      
            vSelect
        },
        data: function () {
            return {
                tags: [],
                searchParams: {
                    tags: store.state.searchParams.tags,
                    freeTextParam: store.state.searchParams.freeTextParam                    
                }
            }
        },      
        mounted() {
            axios
                .get(config.apiRoot + '/tags')
                .then(response => {
                    this.tags = response.data;
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        }       
    }
</script>