'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:dynamicForm
 * @description
 * # dynamicForm
 */
angular.module('webApp')
  .directive('dynamicForm', function () {
    return function (scope, elem) {
      elem.append('<span>This span is appended from directive.</span>');
    };
  });
