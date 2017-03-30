'use strict';

/**
 * @ngdoc directive
 * @name webApp.directive:formEntry
 * @description
 * # formEntry
 */
angular.module('webApp')
  .directive('formEntry', function ($compile, metaDataService) {
    return {
      templateUrl: 'views/templates/form-entry.html',
      replace: true,
      scope: {
        formType: '@',
        isDropdown: '&'
      },
      controller: function ($scope, $element, $attrs, metaDataService) {
        
        function isDropdown(value) {
          return angular.isArray(value);
        }

        function init() {
          $scope.questions = {
            collectionName: 'product', category: ['Watches'], subCategory: ['Cartier']
          };

          metaDataService.getMetadataByProduct($attrs.formType, function (data) {
            $scope.questions = data;
          });
        }

        init();
      }
    };
  });

