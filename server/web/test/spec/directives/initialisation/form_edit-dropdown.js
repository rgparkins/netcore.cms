describe("form initialisation", function () {
  var directiveElem;

  beforeEach(module("my.templates"));

  beforeEach(module('webApp'));

  beforeEach(inject(function (_$compile_, _$rootScope_, $q, metaDataService, dataService) {
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

    spyOn(dataService, "getData").and.callFake(function () {
      var deferred = $q.defer();
      deferred.resolve(
        {
          id: 123,
          category: 'Rings',
          subCategory: 'Longines'
        });

      return deferred.promise;
    });

    directiveElem = _$compile_(angular.element('<form-entry form-type="products" form-data="123"/>'))(_$rootScope_);

    _$rootScope_.$digest();
  }));

  it('should have form id set correctly', function () {
    expect(directiveElem).toBeDefined();
    expect(directiveElem.attr('id')).toEqual('products-form');
  });

  it('should have form button labelled "Update"', function () {
    var button = directiveElem.find('input[type="button"][value="Update"]');

    expect(button.length).toEqual(1);
  });

  it('should have hidden field set correctly for the collection', function () {
    var hiddenField = directiveElem.find('input[type="hidden"]').first();

    expect(hiddenField.attr("value")).toEqual("products");
  });

  it('should have hidden field set correctly for the data', function () {
    var hiddenField = directiveElem.find('input[type="hidden"]').last();

    expect(hiddenField.attr("value")).toEqual("123");
  });

  it('should have selected the correct data', function () {
    var category = directiveElem.find('option[selected="selected"]').first();
    var subCategory = directiveElem.find('option[selected="selected"]').last();

    expect(category.attr("value")).toEqual("Rings");
    expect(subCategory.attr("value")).toEqual("Longines");
  });
});