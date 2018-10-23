<template>
    <div class="col-sm-6 col-md-4 col-lg-3">
        <p>This is a cell</p>
        <p>Title: {{article.title}}</p>
    </div> 
</template>

<script>  
    export default {
        props: ['article']
    }
</script>