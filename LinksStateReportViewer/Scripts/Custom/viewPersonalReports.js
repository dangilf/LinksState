const app = new Vue({
    el: '#app',
    data: {
        user: '',
        results: []
    },
    methods: {
        processFile(event) {
            var self = this;
            var file = event.target.files[0]
            var formData = new FormData();
            formData.append("requests", file);
            var url = '/checkRequest/uploadCsv/' + self.user + '/';
            axios.post(url, formData)
                .then(function (response) {
                    self.getRequests();
                })
                .catch(function (error) {
                    console.log(error.message);
                });
        },
        getRequests() {
            var self = this;
            self.user = userName;
            var url = '/checkRequest/personal/' + self.user + '/';
            axios.get(url).then(function (response) {
                if (response.data) {
                    self.results.push(...response.data);
                }
            }).catch(function (error) {
                console.log(error.message);
            });
        }
    },
    created: function () {
        this.getRequests();
    }
})