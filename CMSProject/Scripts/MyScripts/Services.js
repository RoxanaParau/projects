/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />

app.service("RESTClientService", function ($http) {

    this.get = function () {
        return $http.get("http://localhost:50676/Service1.svc/User");
    };
});
/*
The above JavaScript code define the Angular Service of name RESTClientService in the Angular module. 
This makes use of $http to make call to the WCF REST service.
*/