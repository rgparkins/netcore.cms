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
        formType: '@',
        formData: '@'
      },
      controllerAs: 'vm',
      controller: function (metaDataService, dataService, $attrs) {
        var vm = this;
      
        this.answers = [];

        function init() {
          metaDataService.getMetadataByProduct($attrs.formType).then(function (data) {
            vm.questions = data.questions;

            if ($attrs.formData) {
              //we have data we need to fetchData
              dataService.getData($attrs.formType, $attrs.fetchData).then(function(qData) {
                vm.answers = qData;
              });
            }
          });
        };

        init();
      }
    };
  });

