<template>
    <div v-bind:class="cellClasses[cellSize]">

        <img v-if="article.coverImageUrl" class="article-img" v-bind:src="article.coverImageUrl" />

        <p class="article-title">{{article.title}}</p>
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
            asd: function () {
                this.$router.push('/');
            }
        }
    }
</script>