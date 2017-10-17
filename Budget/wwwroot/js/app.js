angular.module('ngApp', [])
    .controller('home', [
        '$scope',
        'dataService',
        function ($scope, dataService) {
            //dataService.get('/api/data/day', { date: new Date() }).then(console.log);
            //dataService.get('/api/data/month', { date: new Date() }).then(console.log);
            //dataService.get('/api/data/year', { date: new Date() }).then(console.log);
            dataService.get('/api/data/line', { id : 1 }).then(console.log);
        }
    ]);