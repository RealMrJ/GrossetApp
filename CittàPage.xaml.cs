using GrossetApp.Model;
using Microsoft.Maui.Controls;
using Org.Xmlpull.V1.Sax2;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace GrossetApp;

public partial class CittàPage : ContentPage
{
    readonly string _baseCityUri = "https://api.jsonbin.io/v3/b/6620334ce41b4d34e4e60a2c";

    private readonly HttpClient _httpClientCity;
    public ObservableCollection<Città.Record> City { get; set; } = new();

    public CittàPage()
    {
        InitializeComponent();
        _httpClientCity = new HttpClient { BaseAddress = new Uri(_baseCityUri) };
        collectionCityView.ItemsSource = City;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadCities();
    }

    private async Task LoadCities()
    {
        var citiesResponse = await _httpClientCity.GetFromJsonAsync<Città.CityRoot>(_baseCityUri);
        if (citiesResponse != null)
        {
            City.Clear();
            City.Add(citiesResponse.record);
        }
    }
}