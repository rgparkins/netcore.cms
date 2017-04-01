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

        vm.isDropdown = function (id) {
          var question = vm.questions.single(i => i.id === id);

          return question.options || angular.isArray(question.options);
        };

        vm.getOptionsForDropdown = function (id) {
            var question = vm.questions.single(i => i.id === id);

            return question.options;
        }

        function init() {
          metaDataService.getMetadataByProduct($attrs.formType).then(function (data) {
            vm.questions = data.questions;
          });
        };

        init();
      }
    };
  });

