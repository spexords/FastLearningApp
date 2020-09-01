using FastLearningApp.Base;
using FastLearningApp.Extensions;
using FastLearningApp.Models;
using FastLearningApp.ViewModels.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastLearningApp.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        #region Members
        #endregion

        #region Properties
        public ObservableCollection<Card> Cards { get; set; }
        public Card CurrentCard { get; set; }
        public int CardIndex { get; set; } 
        public int CorrectCardsCount { get; set; }
        public int AnsweredCardsCount { get; set; }
        public int CardsScorePercentage { get; set; }
        public bool IsShuffleEnabled { get; set; }
        #endregion

        #region Commands
        public IAsyncCommand ResetCardsAsyncCommand { get; set; }
        public IAsyncCommand SubmitAnswerCommand { get; set; }
        public IAsyncCommand SelectAnswerCommand { get; set; }
        #endregion

        #region Default Constructor
        public MainWindowVM()
        {
            LoadData();
            ResetCardsAsyncCommand = new AsyncCommand(LoadData);
            SubmitAnswerCommand = new AsyncCommand(SubmitCard);
            SelectAnswerCommand = new AsyncCommand(SelectAnswer)
        }

        #endregion


        #region Methods
        private async Task LoadData()
        {
            using(var sr = new StreamReader("data.json", Encoding.GetEncoding("windows-1250")))
            {
                var data = await sr.ReadToEndAsync();
                Cards = JsonConvert.DeserializeObject<ObservableCollection<Card>>(data);
                if(IsShuffleEnabled)
                {
                    Cards.Shuffle();
                }
            }
            CardIndex = 1;
            CorrectCardsCount = 0;
            AnsweredCardsCount = 0;
            CurrentCard = Cards.First();
        }
        
        private async Task SubmitCard()
        {
            if (!CurrentCard.IsAnswered)
            {
                var correctCard = !await Task.Run(() => CurrentCard.Answers.Any(a => a.UserSelection != a.IsValid));
                if (correctCard)
                {
                    CorrectCardsCount++;
                }
                AnsweredCardsCount++;
                CardsScorePercentage = CorrectCardsCount * 100 / AnsweredCardsCount;
                CurrentCard.IsAnswered = true;
                NotifyPropertyChanged("CurrentCard");
            }
            else
            {
                CurrentCard = Cards[++CardIndex - 1];
            }
        }

        private async Task SelectAnswer()
        {
            
        }
        #endregion
    }
}
