<template>
    <div>
        <h2>Cikkek (hamarosan...)</h2>
        <div id="people">
            <v-client-table :data="tableData" :columns="columns" :options="options">
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
                columns: ['id', 'name', 'age'],
                tableData: [
                    { id: 1, name: "John", age: "20" },
                    { id: 2, name: "Jane", age: "24" },
                    { id: 3, name: "Susan", age: "16" },
                    { id: 4, name: "Chris", age: "55" },
                    { id: 5, name: "Dan", age: "40" }
                ],
                theme: 'bootstrap4',
                options: {      
                    filterByColumn: true,
                    headings: {
                        id: 'Id',
                        name: 'Név',
                        age: 'Kor'
                    },
                    sortable: ['name', 'age'],
                    filterable: ['name', 'age'],
                    texts: {
                        filter: '',
                        filterBy: 'keresés {column} alapján',
                        count: ''
                    },
                }
            };
        },
    }
</script>
