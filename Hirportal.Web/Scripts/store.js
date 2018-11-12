export const store = {
    state: {
        loginInfo: {
            userName: null,
            userToken: null
        }
    },
    setLoginInfo(newUserName, newUserToken) {
        this.state.loginInfo.userName = newUserName;
        this.state.loginInfo.userToken = newUserToken;
    }
};