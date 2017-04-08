describe("form initialisation - text area", function () {
  var directiveElem, q, scope;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService, dataService) {
    scope = _$rootScope_;
    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          collectionName: 'products',
          questions: [{
            id: "description",
            questionType: "textarea",
            title: "Description"
          }],
        });

      return deferred.promise;
    });
    spyOn(dataService, "getData").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          id: 123,
          description: 'A big long jug in the morning'
        });

      return deferred.promise;
    });

    directiveElem = _$compile_(angular.element('<form-entry form-type="products" form-data="123"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));

  it('When changing the text it should be reflected on controller', function () {
    var textarea = directiveElem.find('#description');
    textarea.val('Hello I have changed').trigger('input');
    expect(scope.vm.answers.description).toEqual("Hello I have changed");
  });
});