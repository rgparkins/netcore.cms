'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:form
 * @description
 * # form
 */
angular.module('webApp')
  .directive('form', function () {
    return {
      template: '<div>{{}}</div>',
      restrict: 'E',
      link: function postLink(scope, element, attrs) {
        element.text('this is the form directive');
      }
    };
  });
