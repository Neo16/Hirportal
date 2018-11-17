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

   