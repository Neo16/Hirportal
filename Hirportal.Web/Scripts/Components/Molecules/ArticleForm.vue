<template>
    <form class="col-lg-10 offset-lg-1 mt-3">
        <div class="form-group">
            <input v-model="article.Title" class="form-control title-input" placeholder="Cím">
        </div>
        <div class="form-group">
            <label>Publikálási idő</label>
            <input v-model="article.PublishDate" type="date" class="form-control" placeholder="Publikálási idő">
        </div>
        <div class="form-group">
            <label>Archiválási idő</label>
            <input v-model="article.ArchiveDate" type="date" class="form-control" placeholder="Archiválási idő">
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

    export default {
        props: ['article'],
        components: {
            VueEditor            
        },
        methods: {
            onSubmit: function () {
                this.$emit('save-article');
            }
        }        
    }
</script>