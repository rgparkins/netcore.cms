describe("form control", function () {
  var directiveElem;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService) {
    spyOn(metaDataService, "getMetadataByProduct").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          collectionName: 'products',
          questions: [{
            id: "category",
            questionType: "dropdown",
            title: "Category",
            options: [
              "Watches",
              "Rings"
            ]
          },
          {
            id: "subCategory",
            questionType: "dropdown",
            title: "Sub category",
            options: [
              "Cartier",
              "Longines"
            ]
          }],
        });

      return deferred.promise;
    });

    directiveElem = _$compile_(angular.element('<form-entry form-type="products"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));


  it('should have form id set correctly', function () {
    expect(directiveElem).toBeDefined();
    expect(directiveElem.attr('id')).toEqual('products-form');
  });

  it('should have form button labelled "Add"', function () {
    var button = directiveElem.find('input[type="button"][value="Add"]');

    expect(button.length).toEqual(1);
  });

  it('should have hidden field set correctly', function () {
    var hiddenField = directiveElem.find('input[type="hidden"]').first();

    expect(hiddenField.attr("value")).toEqual("products");
  });

  it('should have category field with options', function () {
    alert(directiveElem);
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

function fakeService() {

}