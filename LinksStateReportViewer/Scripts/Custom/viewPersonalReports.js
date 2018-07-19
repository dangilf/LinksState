const app = new Vue({
    el: '#app',
    data: {
        user: '',
        results: []
    },

    created: function () {
        var self = this;
        self.user = userName;
        var url = '/checkRequest/personal/' + self.user+'/';
        axios.get(url).then(function (response) {
            if (response.data) {
                self.results.push(...response.data);
            }
        }).catch(function (error) {
            console.log(error.message);
        });
    }
})