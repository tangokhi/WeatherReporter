# WeatherReporter

The application use web api back end to query data from the external weather service. 

The application shows following weather data :-

# Date, Temperature, Min, Max and Weather description including image of the weather. 
Further data can be shown fairly easily.

The front end is html5/angularjs. 

The form takes in the name of the city,country example: London,UK

# Unit tests
Unit tests have been writtern both of the Web api layer and Angularjs but they only cover important cases.

For Angularjs the unit tests are in the JavaScriptsTests folder in the main project WeatherReporter.

# JavaScriptTests/weather.component.spec.js
# JavaScriptTest/weather.service.spec.js	

Angularjs tests are written using Jasmine and executed using Chutzpah.

For Web api layer there is a separate unit test project. 


There is minimal data validation. 

Error handling is minimal.

The UI can be improved. 

If the application doesn't retrieve data make sure following html request is returning data

"http://api.openweathermap.org/data/2.5/forecast/daily?APPID=39c35f311c64c8b265d5a23d5d9b6d5b&units=metric&cnt=5&q=london,uk"

Few the values such as external service address and token are hardcoded which can be moved to a more appropriate location such as config file. 

The backend service uses Unity dependecy injection.





