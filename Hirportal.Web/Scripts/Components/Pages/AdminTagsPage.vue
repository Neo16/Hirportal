<template>
    <div>
        <h2>Címkék</h2>
        <v-client-table ref="tagsTable" v-if="tableData" :data="tableData" :columns="tags" :options="options">
            <template slot="id" slot-scope="props">
                <div class="d-flex float-right">
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="pencil-alt" @click="openEditTag(props.row)" />
                    </div>
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="trash" @click="tryDeleteTag(props.row.tagId)" />
                    </div>
                </div>
            </template>
        </v-client-table>
        <div class="float-right">
            <button class="btn btn-outline-info" @click="$refs.createTag.show()">Új címke</button>
        </div>

        <basic-modal ref="createTag" @ok="createNewTag()" :positiveButtonText="Mentés" :hasNegativeButton="true">
            <h3 slot="header">Új címke</h3>
            <div slot="body">
                <input v-model="tagToCreateName" class="form-control title-input" placeholder="címke neve">
            </div>
        </basic-modal>
        <basic-modal ref="editTag" @ok="editTag()" :positiveButtonText="Átnevezés" :hasNegativeButton="true">
            <h3 slot="header">Rovat átnevezése</h3>
            <div slot="body">
                <input v-model="tagToEdit.name" class="form-control title-input" placeholder="címke neve">
            </div>
        </basic-modal>
        <basic-modal ref="deleteConfirm" @ok="deleteTag(tagToDeleteId)" :hasNegativeButton="true">
            <h3 slot="header">Megerősítés</h3>
            <p slot="body">Biztosan törölni akarja a címkét?</p>
        </basic-modal>
        <basic-modal ref="deleteError">
            <h3 slot="header">Hiba</h3>
            <p slot="body">A címke törlése nem sikerült, előbb a hozzá tartozó cikkeket kell törölni. </p>
        </basic-modal>
    </div>
</template>
<script>
   
    import { config } from '../../config';
    import axios from 'axios';
    import { store } from '../../store';
    import BasicModal from '../Molecules/BasicModal'

    export default {
        components: {
            BasicModal
        },
        data: function () {
            return {                
                tagToCreateName: null,
                tagToDeleteId: null,     
                tagToEdit: {
                    name: null,
                    tagId: null
                },
                tags: ['name', 'id'],
                tableData: null,
                theme: 'bootstrap4',
                options: {
                    filterByTag: true,
                    headings: {                      
                        name: 'címke neve',
                        id: ''
                    },
                    sortable: ['name'],
                    filterable: ['name'],
                    texts: {
                        filter: '',
                        filterBy: 'keresés {tag} alapján',
                        count: ''
                    }
                }
            };
        },
        mounted() {
            axios({
                method: 'GET',
                url: config.apiRoot + '/tags'               
            })
            .then(response => {
                this.tableData = response.data;
            })
        },
        methods: {
            openEditTag: function (tag) {
                this.$refs.editTag.show();  
                this.tagToEdit.name = tag.name;
                this.tagToEdit.tagId = tag.tagId;
            },
            editTag: function () {
                axios({
                    method: 'put',
                    url: config.apiRoot + '/admin/update-tag',
                    data: this.tagToEdit,                    
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
                .then(response => {                    
                    let index = this.tableData.map(function (c) { return c.tagId; }).indexOf(this.tagToEdit.tagId);
                    Vue.set(this.tableData, index, response.data);
                    this.tagToEdit.name = null;
                    this.tagToEdit.tagId = null;
                })
            },
            createNewTag: function () {
                axios({
                    method: 'post',
                    url: config.apiRoot + '/admin/create-tag',
                    data: {
                        name: this.tagToCreateName
                    },
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
                .then(response => {                    
                    this.tableData.push({
                        name: this.tagToCreateName,
                        tagId: response.data
                    })
                    this.tagToCreateName = null;
                })
            },
            tryDeleteTag: function (id) {           
                this.$refs.deleteConfirm.show();
                this.tagToDeleteId = id;
            },
            deleteTag: function (id) {       
                axios({
                    method: 'delete',                
                    url: config.apiRoot + `/admin/delete-tag?tagId=${id}`,
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
               .then(response => {                   
                    var index = this.tableData.map(x => {
                        return x.tagId;
                    }).indexOf(response.data);                  
                    Vue.delete(this.tableData, index);
                })
                .catch(err => {                   
                    if (err.response.status != 400) {
                       alert('Törlés nem sikerült.')
                    }
                    let responseData = err.response.data;
                    if (responseData.errorMessages) {                      
                        this.$refs.deleteError.show();
                    } 
                 });                
            }           
        }
    }
</script>
