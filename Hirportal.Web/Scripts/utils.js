export const validateEmail = email => {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
};

export const dateCompare = function (property) {
    return function (ascending) {
        return function (a, b) {
            console.log(a[property]);
            let dateA = new Date(a[property]);
            let dateB = new Date(b[property]);

            if (ascending)
                return dateA >= dateB ? 1 : -1;

            return dateA <= dateB ? 1 : -1;
        };
    };
};

function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}

export const generateGuid = function () {
    var guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
    return guid;
};


