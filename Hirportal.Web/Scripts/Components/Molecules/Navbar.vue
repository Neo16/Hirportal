<template>   
    <div>     
        <b-navbar type="light" toggleable="md" variant="light">

            <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>          

            <b-collapse is-nav id="nav_collapse">
                <b-navbar-nav>
                    <b-nav-item href="/">Főoldal</b-nav-item>
                    <b-nav-item if="columns" v-for="column in columns" :to="'/column/' + column.name">{{column.name}}</b-nav-item>
                </b-navbar-nav>

                <!-- Right aligned nav items -->
                <b-navbar-nav class="ml-auto">
                    <b-nav-item-dropdown v-if="loginInfo.userName" text="Admin opciók" right>
                        <b-dropdown-item :to="{path: '/admin/articles'}">Cikkek</b-dropdown-item>
                        <b-dropdown-item v-bind:to="{path: '/admin/create-article'}">Új cikk</b-dropdown-item>
                        <b-dropdown-item v-bind:to="{path: '/admin/columns'}">Rovatok</b-dropdown-item>
                    </b-nav-item-dropdown>
                    <div v-if="loginInfo.userName" class="d-flex">
                        <button v-on:click="logout" class="btn btn-sm btn-outline-dark">
                            <i class="fas fa-sign-out-alt"></i>
                        </button>
                    </div>
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>
    </div>  
</template>

<script>
    import articlecell from '../Atoms/ArticleCell';
    import { store } from '../../store';
    import axios from 'axios';
    import { config } from '../../config';

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
                loginInfo: store.state.loginInfo,
                columns : null
            };
        },
        mounted() {    
            console.log('navbar mounted data:' + this.loginInfo.userName);

            axios
                .get(config.apiRoot + '/columns')
                .then(response => {
                    this.columns = response.data;
                })
                .catch(function (error) {
                    console.log(error.response);
                });
        }
    }
</script>