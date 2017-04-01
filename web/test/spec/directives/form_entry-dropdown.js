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
            id: "category",
            title: "Category",
            options: [
              "Watches",
              "Rings"
            ]
          },
          {
            id: "subCategory",
            title: "Sub category",
            options: [
              "Cartier",
              "Longines"
            ]
          }],
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
    expect(directiveElem.find('label:contains("Category")').length).toEqual(1);
    
    var mainCategory = directiveElem.find('select[name="category"]');
    expect(mainCategory.length).toEqual(1);

    expect(mainCategory.find('option[value="Watches"]').length).toEqual(1);
    expect(mainCategory.find('option[value="Rings"]').length).toEqual(1);
  });

  it('should have sub category field with options', function () {
    expect(directiveElem.find('label:contains("Sub category")').length).toEqual(1);
    
    var mainCategory = directiveElem.find('select[name="subCategory"]');
    expect(mainCategory.length).toEqual(1);

    expect(mainCategory.find('option[value="Cartier"]').length).toEqual(1);
    expect(mainCategory.find('option[value="Longines"]').length).toEqual(1);
  });
});

function getCompiledElement() {
  var element = angular.element('<form-entry form-type="product"/>');

  var compiledElement = compile(element)(scope);

  scope.$digest();

  return compiledElement;
}