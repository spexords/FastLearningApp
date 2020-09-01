using FastLearningApp.Extensions;
using FastLearningApp.Models;
using FastLearningApp.ViewModels.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FastLearningApp.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        #region Members
        private List<Card> mCleanCards;
        #endregion

        #region Properties
        public ObservableCollection<Card> Cards { get; set; }
        public int QuestionCounter { get; set; } = 1
        public bool IsShuffleEnabled { get; set; }
        #endregion

        #region Commands

        #endregion

        #region Default Constructor
        public MainWindowVM()
        {
            LoadData();
        }
        #endregion


        #region Methods
        private async Task LoadData()
        {
            using(var sr = new StreamReader("data.json", Encoding.GetEncoding("windows-1250")))
            {
                var data = await sr.ReadToEndAsync();
                mCleanCards = JsonConvert.DeserializeObject<List<Card>>(data);
                if (Cards == null)
                {
                    Cards = new ObservableCollection<Card>(mCleanCards);
                }
            }
        }
        
        private async Task ResetCards()
        {
            var cards = await Task.Run(() => 
            {
                var c = new ObservableCollection<Card>(mCleanCards);
                if(IsShuffleEnabled)
                {
                    c.Shuffle();
                }    
                return c;
            });
            QuestionCounter = 1;
            Cards = cards;
        }
        #endregion
    }
}
