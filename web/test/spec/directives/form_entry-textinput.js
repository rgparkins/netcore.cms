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
            questionType: 'text',
            id: "name",
            placeholder: "Please enter your name",
            title: "Name"            
          }]
        });

      return deferred.promise;
    });

    directiveElem = getCompiledElement();
  }));

  it('should have text field', function () {
    expect(directiveElem.find('label:contains("Name")').length).toEqual(1);
    
    var textInput = directiveElem.find('input[name="name"]');

    expect(textInput.length).toEqual(1);

    expect(textInput.attr('placeholder')).toEqual("Please enter your name");
  });
});

function getCompiledElement() {
  var element = angular.element('<form-entry form-type="product"/>');

  var compiledElement = compile(element)(scope);

  scope.$digest();

  return compiledElement;
}