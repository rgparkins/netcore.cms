'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:dynamicForm
 * @description
 * # dynamicForm
 */
angular.module('webApp')
  .directive('dynamicForm', function ($compile) {
    return {
      //replace: true,
      templateUrl: 'views/templates/dynamicForm.html',
      controller: formController
    };
    // return function (scope, elem) {
    //     elem.append('<span>This span is appended from directive.</span>');
    //   };
  });


angular.module('webApp')
  .controller("formController", function() {

  });
