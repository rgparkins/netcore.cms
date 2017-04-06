describe("form control", function () {
  var directiveElem;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService) {
    q = $q;

    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          collectionName: 'product',
          questions: [{
            questionType: 'text',
            id: "name",
            placeholder: "Please enter your name",
            title: "Name"
          }]
        });

      return deferred.promise;
    });

     directiveElem = _$compile_(angular.element('<form-entry form-type="products"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));

  it('should have text field', function () {
    expect(directiveElem.find('label:contains("Name")').length).toEqual(1);

    var textInput = directiveElem.find('input[name="name"]');

    expect(textInput.length).toEqual(1);

    expect(textInput.attr('placeholder')).toEqual("Please enter your name");
  });
});