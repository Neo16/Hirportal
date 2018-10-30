<template>
    <div v-bind:class="cellClasses[cellSize]">

        <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" v-on:click="navigate" />

        <p class="article-title"  v-on:click="navigate" >{{article.title}}</p>
        <p class="article-thumbnail-content">{{article.thumbnailContent}} </p>
    </div>
</template>

<script>
    export default {
        props: ['article', 'cellSize'],
        data: function () {
            return {
                cellClasses: {
                    //Normal
                    0: ['col-lg-3', 'col-sm-6', 'article-cell'],
                    // Wide
                    1: ['col-lg-4', 'col-sm-12', 'article-cell'],
                    //Large
                    2: ['col-lg-6', 'col-sm-6', 'article-cell'],
                    //Lead
                    3: ['col-lg-8', 'col-sm-12', 'article-cell', 'lead-article-cell'],
                }
            }
        },
        methods: {
            navigate: function () {
                this.$router.push('/article/' + this.article.id)
            }
        }
    }
</script>