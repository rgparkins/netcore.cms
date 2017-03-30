'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:formEntry
 * @description
 * # formEntry
 */
angular.module('webApp')
  .directive('formEntry', function () {
    return {
      templateUrl: 'views/templates/form-entry.html',
      replace: true,
      bindToController: {
        formType: '@'
      },
      controllerAs: 'vm',
      controller: function (metaDataService, $attrs) {
        var vm = this;
        
        this.getQuestions = function () {
          return vm.questions;
        };

        vm.isDropdown = function (value) {
          return angular.isArray(value);
        };

        function init() {
           alert("formtype = " + $attrs.formType);
           metaDataService.getMetadataByProduct($attrs.formType).then(function (data) {
            vm.questions = data;
          });
        };

        init();
      }
    };
  });

