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
angular.module('ngApp')
    .service('dataService', ['$http',
        function dataService($http) {
            var _self = this;

            _self.get = function get(url, params) {
                var config = { params: params };
                return $http.get(url, config).then(onSuccess, onError);
            };

            _self.post = function post(url, data) {
                return $http.post(url, data, config).then(onSuccess, onError);
            };

            _self.delete = function del(url, params) {
                var config = { params: params };
                return $http.delete(url, config).then(onSuccess, onError);
            };

            function onError(error, callback) {
                console.log(error);
                if (callback) {
                    callback(error);
                }
                return error;
            }

            function onSuccess(data) {
                return data.data;
            }
        }
    ]);