using System.Collections.ObjectModel;
using MACrosSite.Models;
using MACrosSite.Pages;

namespace MACrosSite.Pages;

public partial class Car : ContentView
{
    public ObservableCollection<Project> Cars { get; set; } = new();

    public Car()
    {
        InitializeComponent();
        BindingContext = this;
        LoadCars();
    }

    

    private async void LoadCars()
    {
        var service = new ProjectService("Server=localhost;Database=carplace;User=root;Password=Sme322820829998;");
        var cars = await service.GetProjectsAsync();
        Cars.Clear();
        foreach (var car in cars)
            Cars.Add(car);
    }
}
