using NUnit.Framework;
using System.Net;
using Parkwell.cms.server.serialisation;
using Parkwell.cms.server.metadata;
using System.Collections.Generic;

namespace Parkwell.cms.tests.product
{
    public class Adding_metadata : contexts.metadata_context
    {
        public Adding_metadata()
        {
            Given_a_server();

            When_adding_metadata(
                new
                {
                    questions = new[] {
                      new {
                        title = "Category",
                        options = new[]
                        {
                            "Watches",
                            "Rings"
                        }
                      },
                      new {
                        title = "Sub category",
                        options = new[]
                        {
                            "Bracelets",
                            "Toe rings"
                        }
                      }
                    },
                    collectionName = "product"
                }
            );

            When_retrieving_metadata("product");
        }

        [Test]
        public void The_metadata_is_retrieved()
        {
            Assert.That(last_http_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = last_http_response.Content.ReadAsStringAsync().Result;

            var metaData = new BsonConverter().Deserialise<Metadata>(content);

            Assert.That(metaData.Questions.Count, Is.EqualTo(2));
            
            var categoryQuestion = metaData.Questions[0];
            var categoryOptions = categoryQuestion.UnmappedProperties["options"];
            
            Assert.That(categoryQuestion.Title, Is.EqualTo("Category"));
            Assert.That(categoryOptions, Is.EquivalentTo(new List<string> {"Watches", "Rings"}));

            var subcategoryQuestion = metaData.Questions[1];
            var subcategoryOptions = subcategoryQuestion.UnmappedProperties["options"];
            
            Assert.That(subcategoryQuestion.Title, Is.EqualTo("Sub category"));
            Assert.That(subcategoryOptions, Is.EquivalentTo(new List<string> {"Bracelets", "Toe rings"}));
        }
    }
}