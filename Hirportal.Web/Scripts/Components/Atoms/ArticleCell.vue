<template>
    <div>
        <p>This is a cell2</p>
        <p>Title: {{article.title}}</p>
    </div> 
</template>

<script>  
    export default {
        props: ['article']
    }
</script>