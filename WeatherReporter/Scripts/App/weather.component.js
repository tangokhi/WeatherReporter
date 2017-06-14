(function () {
    'use strict';

    angular.module('app').component('weather', {
        
        templateUrl: '/Scripts/App/WeatherDetails.html',
        controller: WeatherController
    });

    WeatherController.$inject = ['weatherService'];

    function WeatherController(weatherService) {

        var vm = this;
        vm.weatherParameters = [];
        vm.getWeatherData = getWeatherData;
        vm.getIconUrl = getIconUrl;
        vm.readDate = readDate;
        vm.errorMessage = '';
        vm.cityCountry = '';

        function getWeatherData() {
            vm.errorMessage = null;

            if (angular.isUndefined(vm.cityCountry) || vm.cityCountry === null || vm.cityCountry === '') {
                vm.errorMessage = "Enter City";
                return;
            }

            weatherService.getWeatherData(vm.cityCountry).then(function (data) {
                vm.weatherParameters = data;

                if (angular.isUndefined(val) || val === null) {
                    vm.errorMessage = "No data retrieved."
                }
            }).catch(function (error) {
                vm.errorMessage = error.data;
            });
        }

        function getIconUrl(iconName) {
            return 'http://openweathermap.org/img/w/' + iconName + '.png';
        }

        function readDate(date) {
            var d = new Date(0);
            d.setUTCSeconds(date);
            return d;
        }
    }
})();