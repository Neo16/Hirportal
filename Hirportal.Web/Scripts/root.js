﻿import MainPage from './Components/Pages/MainPage.js';
import FormExample from './Components/Pages/FormExample.js';
import ArticleDetails from './Components/Pages/ArticleDetails';
import Navbar from './Components/Molecules/Navbar.js';
import VueRouter from 'vue-router';
import CreateArticlePage from './Components/Pages/CreateArticlePage.js';
import LoginPage from './Components/Pages/LoginPage.js';
import ColumnPage from './Components/Pages/ColumnPage.js';
import { store } from './store.js';
import Datetime from 'vue-datetime';
import AdminArticlesPage from './Components/Pages/AdminArticlesPage.js';
import AdminColumnsPage from './Components/Pages/AdminColumnsPage.js';

// 2. Define some routes
// Each route should map to a component. The "component" can
// either be an actual component constructor created via
// `Vue.extend()`, or just a component options object.
// We'll talk about nested routes later.
const routes = [
    { path: '*', component: MainPage },
    { path: '/form', component: FormExample },
    { path: '/article/:articleId', component: ArticleDetails },
    { path: '/column/:columnName', component: ColumnPage},
    { path: '/login', component: LoginPage },
    { path: '/admin/create-article', component: CreateArticlePage, beforeEnter: adminFilter },
    { path: '/admin/articles', component: AdminArticlesPage, beforeEnter: adminFilter },
    { path: '/admin/columns', component: AdminColumnsPage, beforeEnter: adminFilter }
];

function adminFilter(to, from, next) {
    if (!store.state.loginInfo.userToken) {
        return next('/');
    }
    else {
        next();
    }
}

// 3. Create the router instance and pass the `routes` option
// You can pass in additional options here, but let's
// keep it simple for now.
const router = new VueRouter({
    mode: 'history',
    routes // short for `routes: routes`
});

// 4. Create and mount the root instance.
// Make sure to inject the router with the router option to make the
// whole app router-aware.

Vue.use(Datetime);

const app = new Vue({
    router,
    components: {
        'navbar': Navbar
    }, 
    mounted() {
        var loginInfoJSON = localStorage.getItem('fusionLoginInfo');
        if (loginInfoJSON) {
            var loginInfoFromLocalStorage = JSON.parse(loginInfoJSON);
            store.setLoginInfo(
                loginInfoFromLocalStorage.userName,
                loginInfoFromLocalStorage.userToken);
        }       
    }
}).$mount('#app');


