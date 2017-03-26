var compile, scope, directiveElem, metaService;

describe("form control", function () {
  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  //beforeEach(module('views/templates/dynamicForm.html'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $injector) {
    compile = _$compile_;
    scope = _$rootScope_;

    metaService = $injector.get('metaDataService');
    
    spyOn(metaService, "getMetadataByProduct").and.returnValue("{ collectionName: 'product', category : ['Watches'], subCategory: ['cartier]}");

    directiveElem = getCompiledElement();
  }));

  it('should have form id set corrrectly', function () {
    expect(directiveElem).toBeDefined();
    expect(directiveElem.attr('id')).toEqual('product-form');
  });
});

function getCompiledElement() {
  var element = angular.element('<dynamic-form form-type="product"/>');

  var compiledElement = compile(element)(scope);

  scope.$digest();

  return compiledElement;
}