<template>
    <div>
        <h2>Rovatok</h2>
        <v-client-table ref="columnsTable" v-if="tableData" :data="tableData" :columns="columns" :options="options">
            <template slot="id" slot-scope="props">
                <div class="d-flex float-right">
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="pencil-alt" />
                    </div>
                    <div class="icon-wrapper pointer">
                        <font-awesome-icon icon="trash" @click="tryDeleteColumn(props.row.id)" />
                    </div>
                </div>
            </template>
        </v-client-table>
        <div class="float-right">
            <button class="btn btn-outline-info" @click="showCreateColumn = true">Új rovat</button>
        </div>

        <confirm-modal v-if="showCreateColumn" @close="createNewColumn()">
            <h3 slot="header">Új rovat</h3>
            <div slot="body">
                <input v-model="columnToCreateName" class="form-control title-input" placeholder="rovat neve">
            </div>
        </confirm-modal>
        <confirm-modal v-if="showDeleteConfirm" @close="deleteColumn(columnToDeleteId)">
            <h3 slot="header">Megerősítés</h3>
            <p slot="body">Biztosan törölni akarja a rovatot?</p>
        </confirm-modal>
    </div>
</template>
<script>
   
    import { config } from '../../config';
    import axios from 'axios';
    import { store } from '../../store';
    import ConfirmModal from '../Molecules/ConfirmModal'

    export default {
        components: {
            ConfirmModal
        },
        data: function () {
            return {
                showCreateColumn: false,
                columnToCreateName: null,
                columnToDeleteId: null,
                showDeleteConfirm: false,
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
                    this.showCreateColumn = false;
                    this.tableData.push({
                        name: this.columnToCreateName,
                        id: response.data
                    })
                    this.columnToCreateName = null;
                })
            },
            tryDeleteColumn: function (id) {
                this.showDeleteConfirm = true;
                this.columnToDeleteId = id;
            },
            deleteColumn: function (id) {            
                this.showDeleteConfirm = false;
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
                    let responseData = err.response.data;
                    if (responseData.errorMessages) {
                        alert(`Hiba: ${responseData.errorMessages.toString()}`);
                    } 
                 });                
            }           
        }
    }
</script>
