(function () {
    'use strict';

    angular.module('app').factory('weatherService', weatherService);

    weatherService.$inject = ['$http', '$log', '$q'];

    function weatherService($http, $log, $q) {
        return {
            getWeatherData: getWeatherData
        };

        function getWeatherData(cityCountry) {

            return $http({
                method: 'GET',
                url: 'api/WeatherApi/',
                params: {cityCountry: cityCountry}
            })
            .then(getWeather)
            .catch(getWeatherFailed);

            function getWeather(response) {
                return response.data;
            }

            function getWeatherFailed(error) {
                //logger.error('XHR Failed for getAvengers.' + error.data);
                var newMessage = 'XHR Failed for getWeatherData';
                $log.error(newMessage);
                return $q.reject(error);
            }
        }
    }
})();
