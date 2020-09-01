using System.Threading.Tasks;
using System.Windows.Input;

namespace FastLearningApp.Base
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
