export const store = {
    state: {
        loginInfo: {
            userName: null,
            userToken: null
        },
        searchState: {
            resultArticles: [],
            totalResultNum: null,
            isSearching: false
        },
        searchPagination: {
            pageStart: 0,
            pageLength: 21
        },
        searchParams: {
            tags: [],
            freeTextParam: '',           
        }
    },
    setLoginInfo(newUserName, newUserToken) {
        this.state.loginInfo.userName = newUserName;
        this.state.loginInfo.userToken = newUserToken;
    },
    setSearcResultArticles(searchResult) {
        this.state.searchState.resultArticles.length = 0; 
        this.state.searchState.resultArticles.push(...searchResult.articles);
        this.state.searchState.totalResultNum = searchResult.total;
    },
    setSearchParams(searchParams) {
        this.state.searchParams.freeTextParam = searchParams.freeTextParam;
        this.state.searchParams.tags = searchParams.tags;      
    },
    setSearchPagination(searchPagination) {
        this.state.searchPagination.pageStart = searchPagination.pageStart;
        this.state.searchPagination.pageLength = searchPagination.pageLength;
    },
    setIsSearching(isSearching) {
        this.state.searchState.isSearching = isSearching;              
    }
};