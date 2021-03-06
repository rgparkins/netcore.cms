'use strict';

/**
 * @ngdoc overview
 * @name webApp
 * @description
 * # webApp
 *
 * Main module of the application.
 */
angular
  .module('webApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl',
        controllerAs: 'about'
      })
      .otherwise({
        redirectTo: '/'
      });
  });

angular.module('webApp')
  .factory('metaDataService', function ($http) {
    return {
      getMetadataByProduct: function (name, callback) {
        $http.get("/api/metadata/" + name).then(function (e) {
          callback(e);
        });
      }
    };
  });

angular.module('webApp')
  .factory('dataService', function ($http) {
    return {
      getData: function (name, id, callback) {
        $http.get("/api/" + name + "/" + id).then(function (e) {
          callback(e);
        });
      }
    };
  });