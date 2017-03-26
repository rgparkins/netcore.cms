'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:dynamicForm
 * @description
 * # dynamicForm
 */
angular.module('webApp')
  .directive('dynamicForm', function ($compile, metaDataService) {
    return {
      //replace: true,
      templateUrl: 'views/templates/dynamicForm.html',
      controllerAs: 'ctrl',
      restrict: 'EAMC',
      replace: true,
      scope: {
        //@ reads the attribute value, = provides two-way binding, & works with functions
        formType: '@'
      },
      controller: function ($scope, metaDataService) {
        alert($scope.formType);
        metaDataService.getMetadataByProduct($scope.formType, function(err, data) {
          $scope.metaData = data;
        });
      }
    };
  });