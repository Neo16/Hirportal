<template>
    <div class="edit-article-cell d-flex justify-content-between">
        <p class="mb-0">{{cell.article.title}}</p>
        <div class="cell-row-right">
            <select v-model="cell.cellSize" class="d-inline-block form-control width-select">
                <option disabled selected value="">Méret</option>
                <option value="0">normál</option>
                <option value="1">széles</option>
                <option value="2">szélesebb</option>
                <option value="3">vezér</option>
            </select>
            <font-awesome-icon class="pointer" @click="$emit('remove')" icon="times" />
        </div>     
    </div>
</template>

<script>
    export default {
        props: ['cell']
    }
</script>