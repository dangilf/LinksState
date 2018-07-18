const app = new Vue({
    el: '#app',
    data: {
        requestId: getParameterByName("requestid"),
        results:[]
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
            if (this.results.length > 0)             
                maxId = Math.max(...this.results.map(a => a.Id));
            var url = '/linkstates/' + this.requestId + /newLinkStates/ + maxId;
            axios.get(url).then( function (response) {
                self.results.push(response.data);
            });
        },
    
    }    
})