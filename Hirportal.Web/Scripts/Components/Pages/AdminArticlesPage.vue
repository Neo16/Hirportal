<template>
    <div>
        <h2>Cikkek</h2>
        <div id="people">
            <v-client-table v-if="tableData" :data="tableData" :columns="columns" :options="options">
                <a slot="title" slot-scope="props" :href="'/article/' + props.row.id">{{props.row.title}}</a>
                <p slot="publishDate" slot-scope="props">{{props.row.publishDate | moment("YYYY.MM.DD hh:mm")}}</p>
                <p slot="archiveDate" slot-scope="props">{{props.row.archiveDate | moment("YYYY.MM.DD hh:mm")}}</p>
                <template slot="id" slot-scope="props">
                    <a :href="'/admin/edit-article/' + props.row.id">
                        <font-awesome-icon icon="pencil-alt" />
                    </a>
                    <a href="#">
                        <font-awesome-icon icon="trash" />
                    </a>
                </template>
            </v-client-table>
        </div>
    </div>
</template>
<script>

    import { config } from '../../config';
    import axios from 'axios';
    import { store } from '../../store';

    export default {
        data: function () {
            return {
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
        mounted() {
            axios({
                method: 'GET',
                url: config.apiRoot + '/admin/articles',
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
