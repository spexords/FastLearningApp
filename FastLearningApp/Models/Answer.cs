
using FastLearningApp.ViewModels.Base;

namespace FastLearningApp.Models
{
    public class Answer : BaseViewModel
    {
        public bool IsValid { get; set; }
        public string Content { get; set; }
        public bool UserSelection { get; set; }
    }
}
