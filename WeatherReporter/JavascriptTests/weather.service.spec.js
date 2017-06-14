/// <reference path="../scripts/Libraries/angular/angular.js" />
/// <reference path="../scripts/Libraries/angular/angular-mocks.js" />
/// <reference path="../scripts/app/app.js" />
/// <reference path="../scripts/app/weather.service.js" />

describe('When using weather service ', function () {
    //initialize Angular
    beforeEach(module('app'));
    //parse out the scope for use in our unit tests.

    var service;
    var $httpBackend;


    beforeEach(inject([
             '$injector',
             function ($injector) {
                 $httpBackend = $injector.get('$httpBackend');
                 service = $injector.get('weatherService');
             }
    ]));

    it('Get is called for specified city and country', function () {

        $httpBackend.expectGET('api/WeatherApi/?cityCountry=London').respond({});
        service.getWeatherData('London');
        $httpBackend.flush();
    });

});