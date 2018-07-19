const app = new Vue({
    el: '#app',
    data: {
        user: getParameterByName("user"),
        personal: false,
        requestId: getParameterByName("requestid"),
        results:[]
    },
    created: function () {
        this.getNewResults();
        this.timer = setInterval(this.getNewResults, 3000)
        if (this.user)
            this.personal = true;

    },
    methods: {
        startCheck: function () {
            var url = '/checkRequest/' + this.requestId + '/start';
            axios.post(url, null);
            this.timer = setInterval(this.getNewResults, 3000)
        },
        getNewResults: function () {
            var self = this;
            var maxId = 0;
            if (this.results && this.results.length > 0)             
                maxId = Math.max(...this.results.map(a => a.ID));
            
            var url = '/linkstates/' + this.requestId + '/newLinkStates/' + maxId;
            axios.get(url).then(function (response) {
                if (response.data) {
                    self.results.push(...response.data);
                }
            }).catch (function (error) {
                console.log(error.message);
            });
        },
    
    }    
})