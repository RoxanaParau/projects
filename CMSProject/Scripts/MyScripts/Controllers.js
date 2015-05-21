/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />
/// <reference path="Services.js" />

app.controller("RESTClientController", function ($scope, RESTClientService) {
    // debugger;
    var promiseGet = RESTClientService.get();

    promiseGet.then(function (pl) {
        $scope.Users = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Users', errorPl);
              });
});
/*
The above JavaScript code defines Angular Controller on the Module which defines $scope to be bound with the UI. 
The controller has the dependency on the RESTClientService so that the controller can make call methods from the service.
The controller makes use of the Promise object to manage an Asynchronous calls to the method ‘GET’ method from the service.
Once the call is complete, the retrieved data will be stored in the $scope.Employees which will be used for DataBinding in the UI.
*/