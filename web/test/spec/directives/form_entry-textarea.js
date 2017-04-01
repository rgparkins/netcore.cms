var compile, scope, directiveElem;

describe("form control", function () {
  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService) {
    compile = _$compile_;
    scope = _$rootScope_;

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

    directiveElem = getCompiledElement();
  }));

  it('should have text area field', function () {
    expect(directiveElem.find('label:contains("Summary")').length).toEqual(1);
    
    var textInput = directiveElem.find('textarea[name="summary"]');

    expect(textInput.length).toEqual(1);

    expect(textInput.attr('placeholder')).toEqual("Please enter your address");
  });
});

function getCompiledElement() {
  var element = angular.element('<form-entry form-type="product"/>');

  var compiledElement = compile(element)(scope);

  scope.$digest();

  return compiledElement;
}