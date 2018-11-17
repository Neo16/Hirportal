<template>
    <b-tabs>
        <b-tab title="Címke alapján" active>
            <div class="form-group mt-4">
                <v-select multiple v-model="searchObj.tags" label="name" :options="tags"></v-select>
            </div>
        </b-tab>
        <b-tab title="Szabad szöveg">
            <div class="form-group mt-4">
                <input v-model="searchObj.freeTextParam" class="form-control" rows="3" />
            </div>
        </b-tab>
    </b-tabs>
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
                searchObj: {
                    tags: store.state.searchObj.tags,
                    freeTextParam: store.state.searchObj.freeTextParam,
                    pageStart: store.state.searchObj.pageStart,
                    pageLength: store.state.searchObj.pageLength
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