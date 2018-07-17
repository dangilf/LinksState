const app = new Vue({
    el: '#app',
    data: {
        errors: [],
        email: null,
        password: null,
        rememberMe: null
    },
    methods: {
        checkForm: function (e) {
            this.errors = [];
            if (!this.email) {
                this.errors.push("Specify email address");
            } else if (!this.validEmail(this.email)) {
                this.errors.push("Specify correct email address");
            }
            if (!this.password) {
                this.errors.push("Specify password")
            }           
            if (!this.errors.length)
                return true;
            e.preventDefault();
        },
        validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }
    }
})