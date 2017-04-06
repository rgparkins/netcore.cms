describe("form control", function () {
  var directiveElem;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService) {
    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          collectionName: 'product',
          questions: [{
            questionType: 'textarea',
            id: "summary",
            placeholder: "Please enter your address",
            title: "Summary"
          }]
        });

      return deferred.promise;
    });

    directiveElem = _$compile_(angular.element('<form-entry form-type="products"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));

  it('should have text area field', function () {
    expect(directiveElem.find('label:contains("Summary")').length).toEqual(1);

    var textInput = directiveElem.find('textarea[name="summary"]');

    expect(textInput.length).toEqual(1);

    expect(textInput.attr('placeholder')).toEqual("Please enter your address");
  });
});