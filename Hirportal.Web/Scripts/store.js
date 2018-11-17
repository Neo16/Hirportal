export const store = {
    state: {
        loginInfo: {
            userName: null,
            userToken: null
        },
        searchResultArticles: [], 
        isSearching: {
            value: false
        },
        searchObj: {
            tags: [],
            freeTextParam: '',
            pageStart: 0,
            pageLength: 21
        }
    },
    setLoginInfo(newUserName, newUserToken) {
        this.state.loginInfo.userName = newUserName;
        this.state.loginInfo.userToken = newUserToken;
    },
    setSearcResultArticles(searchResultArticles) {
        this.state.searchResultArticles.length = 0; 
        this.state.searchResultArticles.push(...searchResultArticles);              
    },
    setSearchObj(searchObj) {
        this.state.searchObj.freeTextParam = searchObj.freeTextParam;
        this.state.searchObj.tags = searchObj.tags;
        this.state.searchObj.pageStart = searchObj.pageStart;
        this.state.searchObj.pageLength = searchObj.pageLength;
    },
    setIsSearching(isSearching) {       
       this.state.isSearching.value = isSearching;              
    }
};