import MainPage from './Components/Pages/MainPage.js';
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
import AdminTagsPage from './Components/Pages/AdminTagsPage.js';
import AdminEditArticlePage from './Components/Pages/AdminEditArticlePage.js';
import AdminMainPageEditor from './Components/Pages/AdminMainPageEditor.js';
import SearchPage from './Components/Pages/SearchPage.js';
import { ClientTable } from 'vue-tables-2';
import VueMoment from 'vue-moment';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCoffee, faPencilAlt, faTrash, faSearch } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

//Define routes
const routes = [
    { path: '*', component: MainPage },
    { path: '/form', component: FormExample },
    { path: '/article/:articleId', component: ArticleDetails },
    { path: '/column/:columnName', component: ColumnPage},
    { path: '/login', component: LoginPage },
    { path: '/search', component: SearchPage },
    { path: '/admin/create-article', component: CreateArticlePage, beforeEnter: adminFilter },
    { path: '/admin/articles', component: AdminArticlesPage, beforeEnter: adminFilter },
    { path: '/admin/columns', component: AdminColumnsPage, beforeEnter: adminFilter },
    { path: '/admin/edit-article/:articleId', component: AdminEditArticlePage, beforeEnter: adminFilter },
    { path: '/admin/edit-mainpage', component: AdminMainPageEditor, beforeEnter: adminFilter },
    { path: '/admin/tags', component: AdminTagsPage, beforeEnter: adminFilter },
    { path: '/admin/edit-article/:articleId', component: AdminEditArticlePage, beforeEnter: adminFilter }   
];

function adminFilter(to, from, next) {
    if (!store.state.loginInfo.userToken) {
        return next('/');
    }
    else {
        next();
    }
}

//Create the router instance and pass the `routes` option
const router = new VueRouter({
    mode: 'history',
    routes, // short for `routes: routes`
    scrollBehavior(to, from, savedPosition) {
        return { x: 0, y: 0 };
    }
});


//Add font awesome icons 
library.add([faCoffee, faPencilAlt, faTrash, faSearch]);

//global components 
Vue.component('font-awesome-icon', FontAwesomeIcon);

//pulugins 
Vue.use(Datetime);
Vue.use(ClientTable);
Vue.use(VueMoment);


// Create and mount the root instance.
// Make sure to inject the router with the router option to make the
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


