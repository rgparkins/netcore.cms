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

        this.answers = [];
        
        function init() {
          metaDataService.getMetadataByProduct($attrs.formType).then(function (data) {
            vm.questions = data.questions;
          });
        };

        init();
      }
    };
  });

