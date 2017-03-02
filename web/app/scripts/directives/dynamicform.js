'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:dynamicForm
 * @description
 * # dynamicForm
 */
angular.module('webApp')
  .directive('dynamicForm', function () {
    return {
      restrict: 'A',
      templateUri: 'views/templates/dynamicForm.html'
    };
    // return function (scope, elem) {
    //     elem.append('<span>This span is appended from directive.</span>');
    //   };
  });
