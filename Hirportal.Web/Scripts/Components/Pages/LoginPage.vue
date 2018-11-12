<template>
    <div class="container">
        <div class="col-lg-4 offset-lg-4 mt-4 col-md-6 offset-md-3">
            <form>
                <div class="form-group">
                    <label for="username">Felhasználó</label>
                    <input v-model="UserName" class="form-control" id="username" placeholder="felhasználónév">
                </div>
                <div class="form-group">
                    <label for="password">Jelszó</label>
                    <input v-model="Password" type="password" class="form-control" id="password" placeholder="jelszó">
                </div>
                <button type="button" v-on:click="onSubmit" class="btn btn-outline-info login-button">Belépés</button>
            </form>
        </div>
    </div>
</template>

<script>
    import { config } from '../../config';
    import { store } from '../../store';
    import axios from 'axios';

    export default {
        data: function () {
            return {
                UserName: "",
                Password: ""
            }
        },
        methods: {
            onSubmit: function () {
                axios
                    .post(config.apiRoot + '/account/login', this.$data)
                    .then(response => {
                        var info = {
                            userName: response.data.userName,
                            userToken: response.data.userToken
                        }
                        localStorage.setItem('fusionLoginInfo', JSON.stringify(info));
                        store.setLoginInfo(info.userName, info.userToken);
                        this.$router.push('/');
                    })
                    .catch(function (error) {
                        console.log(error.response);
                        //todo
                    });
            }
        }
    }
</script>