const app = new Vue({
    el: '#app',
    data: {
        baseUrl: null,
        nestingLevel: null,
        requestId: null,
    },
    methods: {
        createRequest: function () {
            let self = this;
            var url = '/checkRequest';
            var model = {
                UserName: userName,
                BaseUrl: this.baseUrl,
                NestingLevel: this.nestingLevel
            }
            axios.post(url, model)
                .then(function (response) {
                    self.requestId = response.data;
                })
                .catch(function (error) {
                    console.log(error.message);
                });
        },
        openReport: function () {
            window.location.href = 'viewreportresult?requestid=' + this.requestId;
        }
    }


})