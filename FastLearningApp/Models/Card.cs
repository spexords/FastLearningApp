using System.Collections.Generic;

namespace FastLearningApp.Models
{

    public class Card
    {
        public string Question { get; set; }
        public string ImageLink { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
