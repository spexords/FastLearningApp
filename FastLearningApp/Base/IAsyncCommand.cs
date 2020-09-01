using System.Threading.Tasks;
using System.Windows.Input;

namespace FastLearningApp.Base
{
    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }
}
