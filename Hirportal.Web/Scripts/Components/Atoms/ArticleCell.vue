<template>
    <div class="article-cell">

        <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" />

        <p class="article-title">{{article.title}}</p>
        <p class="article-thumbnail-content">{{article.thumbnailContent}} </p>
    </div> 
</template>

<script>  
    export default {
        props: ['article']
    }
</script>