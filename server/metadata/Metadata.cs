using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parkwell.cms.server.metadata
{
    public enum QuestionType {
        Dropdown,
        TextArea,
        Text
    }
    public class Metadata : Document
    {
        [Required]
        public string CollectionName { get; set; }

        public List<Question> Questions { get; set; }
    }

    public class Question : Document
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public QuestionType QuestionType { get; set;}
    }
}