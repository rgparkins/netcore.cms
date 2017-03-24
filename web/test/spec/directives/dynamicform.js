var compile, scope, directiveElem;

describe("form control", function () {
  beforeEach(module("my.templates")); 
  
  beforeEach(module('webApp'));
  
  //beforeEach(module('views/templates/dynamicForm.html'));
  
  beforeEach(inject(function (_$compile_, _$rootScope_) {
    compile = _$compile_;
    scope = _$rootScope_;
  
    directiveElem = getCompiledElement();
  }));

  it('should have span element', function () {
    var spanElement = directiveElem.find('span');
    
    alert(spanElement);
    expect(spanElement).toBeDefined();
    expect(spanElement.text()).toEqual('This span is appended from directive.');
  });
});

function getCompiledElement() {
  var element = angular.element('<dynamic-form/>');
  
  var compiledElement = compile(element)(scope);
  
  scope.$digest();
  
  alert(compiledElement);
  return compiledElement;
}