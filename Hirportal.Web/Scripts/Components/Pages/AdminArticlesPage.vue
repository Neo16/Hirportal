<template>
    <div>
        <h2>Cikkek</h2>
        <v-client-table ref="articlesTable" v-if="tableData" :data="tableData" :columns="columns" :options="options">
                <a slot="title" slot-scope="props" :href="'/article/' + props.row.id">{{props.row.title}}</a>
                <p slot="publishDate" slot-scope="props">{{props.row.publishDate | moment("YYYY.MM.DD hh:mm")}}</p>
                <p slot="archiveDate" slot-scope="props">{{props.row.archiveDate | moment("YYYY.MM.DD hh:mm")}}</p>
                <template slot="id" slot-scope="props">
                    <div class="d-flex">
                        <router-link :to="'/admin/edit-article/' + props.row.id">
                            <a>
                                <font-awesome-icon icon="pencil-alt" />
                            </a>
                        </router-link>
                        <div class="icon-wrapper pointer">
                            <font-awesome-icon @click="tryDeleteArticle(props.row.id)" icon="trash" />
                        </div>
                    </div>
                </template>
         </v-client-table>        
        <confirm-modal ref="deleteConfirm" @ok="deleteArticle(articleToDeleteId)" :hasNegativeButton="true">
            <h3 slot="header">Megerősítés</h3>
            <p slot="body">Biztosan törölni akarja a cikket?</p>
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
                articleToDeleteId: null,            
                columns: ['title', 'author.name', 'publishDate', 'archiveDate', 'column.name', 'id' ],
                tableData: null,
                theme: 'bootstrap4',
                options: {
                    filterByColumn: true,
                    headings: {
                        title: 'cím',
                        author: 'szerző',
                        publishDate: 'publikálási idő',
                        archiveDate: 'archiválási idő',
                        column: 'rovat',
                        'author.name': 'szerző',
                        'column.name': 'rovat',
                        id: ''
                    },
                    sortable: ['title', 'author', 'publishDate', 'archiveDate', 'column.name', 'author.name'],
                    filterable: ['title', 'author', 'column.name', 'author.name'],
                    texts: {
                        filter: '',
                        filterBy: 'keresés {column} alapján',
                        count: ''
                    }
                }
            };
        },
        methods: {
            tryDeleteArticle: function (id) {               
                this.$refs.deleteConfirm.show();
                this.articleToDeleteId = id;
            },
            deleteArticle: function (id) {   
                axios({
                    method: 'delete',                   
                    url: config.apiRoot + `/admin/delete-article?articleId=${id}`,
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
            }           
        },
        mounted() {
            axios({
                method: 'GET',
                url: config.apiRoot + '/admin/articles' ,
                headers: {
                    "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                }
            })
            .then(response => {
                this.tableData = response.data;
            })
        }
    }
</script>
