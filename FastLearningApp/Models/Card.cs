using FastLearningApp.ViewModels.Base;
using System.Collections.Generic;

namespace FastLearningApp.Models
{

    public class Card : BaseViewModel
    {
        public bool IsAnswered { get; set; }
        public string Question { get; set; }
        public string ImageLink { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
