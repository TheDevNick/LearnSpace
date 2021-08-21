using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Container
    {
        public List<Topic> AllTopics { get; set; }
        public Topic Topic { get; set; }
        public List<Association> AllAssociations { get; set; }
        public Association Association { get; set; }
    }
}