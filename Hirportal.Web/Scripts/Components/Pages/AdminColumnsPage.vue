﻿<template>
    <div>
        <h2>Rovatok</h2>
        <v-client-table ref="columnsTable" v-if="tableData" :data="tableData" :columns="columns" :options="options">
            <template slot="id" slot-scope="props">
                <div class="d-flex float-right">
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="pencil-alt" @click="openEditColumn(props.row)" />
                    </div>
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="trash" @click="tryDeleteColumn(props.row.id)" />
                    </div>
                </div>
            </template>
        </v-client-table>
        <div class="float-right">
            <button class="btn btn-outline-info" @click="$refs.createColumn.show()">Új rovat</button>
        </div>

        <basic-modal ref="createColumn" @ok="createNewColumn()" :positiveButtonText="Mentés" :hasNegativeButton="true">
            <h3 slot="header">Új rovat</h3>
            <div slot="body">
                <input v-model="columnToCreateName" class="form-control title-input" placeholder="rovat neve">
            </div>
        </basic-modal>
        <basic-modal ref="editColumn" @ok="editColumn()" :positiveButtonText="Átnevezés" :hasNegativeButton="true">
            <h3 slot="header">Rovat átnevezése</h3>
            <div slot="body">
                <input v-model="columnToEdit.name" class="form-control title-input" placeholder="rovat neve">
            </div>
        </basic-modal>
        <basic-modal ref="deleteConfirm" @ok="deleteColumn(columnToDeleteId)" :hasNegativeButton="true">
            <h3 slot="header">Megerősítés</h3>
            <p slot="body">Biztosan törölni akarja a rovatot?</p>
        </basic-modal>
        <basic-modal ref="deleteError">
            <h3 slot="header">Hiba</h3>
            <p slot="body">A rovat törlése nem sikerült, előbb a hozzá tartozó cikkeket kell törölni. </p>
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
                columnToCreateName: null,
                columnToDeleteId: null,     
                columnToEdit: {
                    name: null,
                    id: null
                },
                columns: ['name', 'id'],
                tableData: null,
                theme: 'bootstrap4',
                options: {
                    filterByColumn: true,
                    headings: {                      
                        name: 'rovat neve',
                        id: ''
                    },
                    sortable: ['name'],
                    filterable: ['name'],
                    texts: {
                        filter: '',
                        filterBy: 'keresés {column} alapján',
                        count: ''
                    }
                }
            };
        },
        mounted() {
            axios({
                method: 'GET',
                url: config.apiRoot + '/columns'               
            })
            .then(response => {
                this.tableData = response.data;
            })
        },
        methods: {
            openEditColumn: function (column) {
                this.$refs.editColumn.show();  
                this.columnToEdit.name = column.name;
                this.columnToEdit.id = column.id;
            },
            editColumn: function () {
                axios({
                    method: 'put',
                    url: config.apiRoot + '/admin/update-column',
                    data: this.columnToEdit,                    
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
                .then(response => {                    
                    let index = this.tableData.map(function (c) { return c.id; }).indexOf(this.columnToEdit.id);
                    Vue.set(this.tableData, index, response.data);
                    this.columnToEdit.name = null;
                    this.columnToEdit.id = null;
                })
            },
            createNewColumn: function () {
                axios({
                    method: 'post',
                    url: config.apiRoot + '/admin/create-column',
                    data: {
                        name: this.columnToCreateName
                    },
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
                .then(response => {                    
                    this.tableData.push({
                        name: this.columnToCreateName,
                        id: response.data
                    })
                    this.columnToCreateName = null;
                })
            },
            tryDeleteColumn: function (id) {           
                this.$refs.deleteConfirm.show();
                this.columnToDeleteId = id;
            },
            deleteColumn: function (id) {       
                axios({
                    method: 'delete',                
                    url: config.apiRoot + `/admin/delete-column?columnId=${id}`,
                    headers: {
                        "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                    }
                })
               .then(response => {                   
                    var index = this.tableData.map(x => {
                        return x.id;
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
