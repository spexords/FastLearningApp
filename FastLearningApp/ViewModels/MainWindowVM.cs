using FastLearningApp.Base;
using FastLearningApp.Extensions;
using FastLearningApp.Models;
using FastLearningApp.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        public IAsyncCommand<object> ResetCardsAsyncCommand { get; set; }
        public IAsyncCommand<object> SubmitAnswerCommand { get; set; }
        public ICommand SelectAnswerCommand { get; set; }
        public ICommand ChangeCardByArrowsCommand { get; set; }
        #endregion

        #region Default Constructor
        public MainWindowVM()
        {
            LoadData();
            ResetCardsAsyncCommand = new AsyncCommand<object>(LoadData);
            SubmitAnswerCommand = new AsyncCommand<object>(SubmitCard);
            SelectAnswerCommand = new CommandHandler(SelectAnswer);
            ChangeCardByArrowsCommand = new CommandHandler(ChangeCardByArrows);
        }
        #endregion


        #region Methods
        private async Task LoadData(object o = null)
        {
            using (var sr = new StreamReader("data.json", Encoding.GetEncoding("windows-1250")))
            {
                var data = await sr.ReadToEndAsync();
                Cards = JsonConvert.DeserializeObject<ObservableCollection<Card>>(data);
                if (IsShuffleEnabled)
                {
                    Cards.Shuffle();
                }
            }
            CardIndex = 1;
            CorrectCardsCount = 0;
            AnsweredCardsCount = 0;
            CurrentCard = Cards.First();
        }

        private async Task SubmitCard(object o)
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
                if(CurrentCard == Cards.Last())
                {
                    ShowSummaryPopup();
                    await LoadData();
                }
            }
            else
            {
                CurrentCard = Cards[++CardIndex - 1];
            }
        }

        private void ShowSummaryPopup()
        {
            MessageBox.Show($"Congratulations your score is: {CorrectCardsCount}/{AnsweredCardsCount} ({CardsScorePercentage}).", 
                            "Results", 
                            MessageBoxButton.OK, 
                            MessageBoxImage.Information);
        }

        private void SelectAnswer(object o)
        {
            if (!CurrentCard.IsAnswered)
            {
                var answerNumber = Convert.ToInt32(o);
                if (answerNumber < CurrentCard.Answers.Count)
                {
                    var answer = CurrentCard.Answers[answerNumber];
                    answer.UserSelection = !answer.UserSelection;
                }
            }
        }
        private void ChangeCardByArrows(object o)
        {
            var offset = Convert.ToInt32(o);
            CardIndex = CardIndex + offset - 1 < Cards.Count && CardIndex + offset - 1 >= 0 ? CardIndex + offset : CardIndex;
            CurrentCard = Cards[CardIndex - 1];
        }
        #endregion
    }
}
