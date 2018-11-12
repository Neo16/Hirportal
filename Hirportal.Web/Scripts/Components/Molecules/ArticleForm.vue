<template>
    <form class="col-lg-10 offset-lg-1 mt-3">
        <div class="form-group">
            <input v-model="article.Title" class="form-control title-input" placeholder="Cím">
        </div>
        <div class="form-group">
            <label>Rovat</label>
            <select v-model="article.Column.Id" class="form-control">
                <option disabled selected value="">Rovat</option>
                <option v-if="columns" v-for="column in columns" v-bind:value="columns.id">
                    {{ column.name }}
                </option>
            </select>
        </div>
        <div class="form-group">
            <label>Címkék</label>
            <v-select multiple v-model="article.Tags" label="name" :options="tags"></v-select>
        </div>
        <div class="form-group">
            <label>Publikálási idő</label>
            <datetime v-model="article.PublishDate" type="datetime" input-class="form-control"></datetime>
        </div>
        <div class="form-group">
            <label>Archiválási idő</label>
            <datetime v-model="article.ArchiveDate" type="datetime" input-class="form-control"></datetime>
        </div>
        <div class="form-group">
            <label>Kivonat</label>
            <textarea v-model="article.ThumbnailContent" class="form-control" rows="3"></textarea>
        </div>
        <div class="form-group">
            <label>Tartalom</label>
            <vue-editor v-model="article.HtmlContent"></vue-editor>
        </div>

        <button type="button" v-on:click="onSubmit" class="btn btn-outline-info submit-button">Mentés</button>
    </form>
</template>

<script>

    import { VueEditor } from 'vue2-editor';
    import axios from 'axios';
    import { config } from '../../config';
    import vSelect from 'vue-select';

    export default {
        props: ['article'],
        components: {
            VueEditor,
            vSelect
        },
        methods: {
            onSubmit: function () {
                this.$emit('save-article');
            }           
        },
        data: function () {
            return {               
                columns: null,
                tags: []
            };
        },
        mounted() {
            axios
                .get(config.apiRoot + '/columns')
                .then(response => {
                    this.columns = response.data;                    
                })
                .catch(function (error) {
                    console.log(error.response);
                });

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