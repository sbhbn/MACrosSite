using CommunityToolkit.Mvvm.Input;
using MACrosSite.Models;

namespace MACrosSite.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}