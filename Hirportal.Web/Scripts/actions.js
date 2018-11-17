import { store } from './store';
import axios from 'axios';
import { config } from './config';

export const actions = {
    searchArticles: function () {       
        store.setIsSearching(true);
        axios({
            method: 'post',
            url: config.apiRoot + '/articles/search',
            data: {
                ...store.state.searchParams, ...store.state.searchPagination
            },
            headers: {
                "Authorization": `Bearer ${store.state.loginInfo.userToken}`
            }
        })
        .then(response => {            
            store.setSearcResultArticles(response.data);              
            store.setIsSearching(false);
        })
        .catch(function (error) {
            console.log(error.response);
        });        
    }
};