/// <reference path="../scripts/Libraries/angular/angular.js" />
/// <reference path="../scripts/Libraries/angular/angular-mocks.js" />
/// <reference path="../scripts/app/app.js" />
/// <reference path="../scripts/app/weather.component.js" />
/// <reference path="../scripts/app/weather.service.js" />

describe('When using weather component ', function () {
    //initialize Angular
    beforeEach(module('app'));
    //parse out the scope for use in our unit tests.

    var $componentController;
    var $weatherService;

    var $rootScope;
    beforeEach(inject(function (_$rootScope_) {
        $rootScope = _$rootScope_;
    }));

    var q;
    beforeEach(inject(function ($q) {
        q = $q;
    }));


    beforeEach(inject([
             '$injector',
             function ($injector) {
                 $componentController = $injector.get('$componentController');
                 $weatherService = $injector.get('weatherService');

                 spyOn($weatherService, "getWeatherData").and.callFake(function (cityCountry) {
                     var deferred = q.defer();

                     if (cityCountry === 'London') {
                         deferred.resolve('Remote call result');
                     }
                     else {
                         deferred.reject({ data: 'remote call error' });
                     }

                     return deferred.promise;
                 })
             }
    ]));

    it('getWeatherData retrieves correct data', function () {
        var ctrl = $componentController("weather", $weatherService);

        ctrl.cityCountry = "London";
        ctrl.getWeatherData();
        $rootScope.$apply();

        expect(ctrl.weatherParameters).toBe('Remote call result');

    });

    it('getWeatherData errors populate errorMessage', function () {
        var ctrl = $componentController("weather", $weatherService);

        ctrl.cityCountry = "error";
        ctrl.getWeatherData();
        $rootScope.$apply();

        expect(ctrl.errorMessage).toBe('remote call error');

    });

    it('getWeatherData populate errorMessage when input is empty', function () {
        var ctrl = $componentController("weather", $weatherService);

        ctrl.cityCountry = "";
        ctrl.getWeatherData();
        expect(ctrl.errorMessage).toBe('Enter City');

    });

    it('getIconUrl constructs the expected url', function () {
        var ctrl = $componentController("weather", $weatherService);
        var retrievedIconUrl = ctrl.getIconUrl('03');
        expect(retrievedIconUrl).toBe('http://openweathermap.org/img/w/03.png');
    });
});