<template>
    <div>
        <p>This is a cell</p>
        <p>Title: {{article.title}}</p>
    </div> 
</template>

<script>  
    export default {
        props: ['article']
    }
</script>