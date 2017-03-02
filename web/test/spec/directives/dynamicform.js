var compile, scope, directiveElem;

describe("form control", function () {

  beforeEach(module("my.templates")); 
  
  //beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_) {
    compile = _$compile_;
    scope = _$rootScope_.$new();

    directiveElem = getCompiledElement();
  }));

  it('should have span element', function () {
    var spanElement = directiveElem.find('span');
    expect(spanElement).toBeDefined();
    expect(spanElement.text()).toEqual('This span is appended from directive.');
  });
});

function getCompiledElement() {
  var element = angular.element('<div dynamic-form></div>');
  
  var compiledElement = compile(element)(scope);
  
  alert(element);
  alert(compiledElement);

  scope.$digest();
  
  alert(compiledElement);
  return compiledElement;
}