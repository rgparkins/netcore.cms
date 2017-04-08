describe("form initialisation", function () {
  var directiveElem, scope;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService, dataService) {
    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      scope = _$rootScope_;
      
      var deferred = $q.defer();
      deferred.resolve(
        {
          collectionName: 'products',
          questions: [{
            id: "category",
            questionType: "dropdown",
            title: "Category",
            options: [
              "Watches",
              "Rings"
            ]
          },
          {
            id: "subCategory",
            questionType: "dropdown",
            title: "Sub category",
            options: [
              "Cartier",
              "Longines",
              "Rolex"
            ]
          }],
        });

      return deferred.promise;
    });

    spyOn(dataService, "getData").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          id: 123,
          category: 'Rings',
          subCategory: 'Longines'
        });

      return deferred.promise;
    });

    directiveElem = _$compile_(angular.element('<form-entry form-type="products" form-data="123"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));

  it('When selecting Rolex model should be set on controller', function () {
    var select = directiveElem.find('#subCategory');
    select.val('Rolex').change();
    expect(scope.vm.answers.subCategory).toEqual("Rolex");
  });
});