<template>   
    <nav class="navbar navbar-expand-sm navbar-light bg-light">
        <button class="navbar-toggler" data-toggle="collapse" data-target="#navbarMenu">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarMenu">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                    <router-link class="nav-link" to="/">Főoldal</router-link>
                </li>
                <li v-if="loginInfo.userName" class="nav-item">
                    <router-link class="nav-link" to="/create-article">Új cikk</router-link>
                </li>
            </ul>         
            <div v-if="loginInfo.userName" class="d-flex">
                <p class="login-info"> belépve: {{loginInfo.userName}}</p>
                <button v-on:click="logout" class="btn btn-sm btn-outline-dark">
                    <i class="fas fa-sign-out-alt"></i>
                </button>
            </div>
        </div>     
    </nav>
</template>

<script>
    import articlecell from '../Atoms/ArticleCell';
    import { store } from '../../sore';
    export default {
        components: {
            articlecell       
        },
        props: ['cells'],
        methods: {
            logout: function () {
                localStorage.removeItem('fusionLoginInfo');
                store.setLoginInfo(null, null);
                this.$router.push('/');
            }
        },
        data: function () {
            return {
                loginInfo: store.state.loginInfo
            };
        }
    }
</script>