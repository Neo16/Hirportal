<template>   
    <nav class="navbar navbar-expand-sm navbar-light bg-light">        
        <button class="navbar-toggler" data-toggle="collapse" data-target="#navbarMenu">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarMenu">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <router-link class="nav-link" to="/">Home</router-link>
                </li>
                <li class="nav-item">                    
                    <router-link class="nav-link" to="/form">Form</router-link>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
    import articlecell from '../Atoms/ArticleCell'
    export default {
        components: {
            articlecell
        },
        props: ['cells']
    }
</script>