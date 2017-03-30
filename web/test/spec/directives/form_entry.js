var compile, scope, directiveElem;

describe("form control", function () {
  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService) {
    compile = _$compile_;
    scope = _$rootScope_;

    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve({
        collectionName: 'product', category: ['Watches'], subCategory: ['Cartier']
      });
      
      return deferred.promise;
    });

    directiveElem = getCompiledElement();
  }));


  it('should have form id set correctly', function () {
    expect(directiveElem).toBeDefined();
    expect(directiveElem.attr('id')).toEqual('product-form');
  });

  it('should have hidden field set correctly', function () {
    var hiddenField = directiveElem.find('input[type="hidden"]').first();

    expect(hiddenField.attr("value")).toEqual("product");
  });

  it('should have category field with options', function () {
    var mainCategory = directiveElem.find('select[name="category"]');

    expect(mainCategory.length).toEqual(1);
  });
});

function getCompiledElement() {
  var element = angular.element('<form-entry form-type="product"/>');

  var compiledElement = compile(element)(scope);

  scope.$digest();

  alert(compiledElement);
  
  return compiledElement;
}