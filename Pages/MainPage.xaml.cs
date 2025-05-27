using CommunityToolkit.Mvvm.Input;
using MACrosSite.Models;
using MACrosSite.PageModels;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;

namespace MACrosSite.Pages
{
    public partial class MainPage : ContentPage
    {
        public ICommand GoCarListCommand { get; }
        public MainPage()
        {
        
            Loaded += MainPage_Loaded;

      
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            await LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            await Task.CompletedTask;
        }
    }
}