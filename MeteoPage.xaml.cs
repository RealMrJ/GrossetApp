using GrossetApp.Model;
using Microsoft.Maui.Controls;
using Org.Xmlpull.V1.Sax2;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace GrossetApp;

public partial class MeteoPage : ContentPage
{
    readonly string _baseMeteoUri = "https://api.jsonbin.io/v3/b/662034fead19ca34f85bbe8b";

    private readonly HttpClient _httpClientMeteo;
    public ObservableCollection<Meteo.Daily> MeteoRecords { get; set; } = new();

    public MeteoPage()
    {
        InitializeComponent();
        _httpClientMeteo = new HttpClient { BaseAddress = new Uri(_baseMeteoUri) };
        collectionMeteoView.ItemsSource = MeteoRecords;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMeteoRecords();
    }

    private async Task LoadMeteoRecords()
    {
        var meteoResponse = await _httpClientMeteo.GetFromJsonAsync<Meteo.MeteoRoot>(_baseMeteoUri);

        MeteoRecords.Clear();
        foreach (var dailyRecord in meteoResponse.record.timelines.daily)
        {
            MeteoRecords.Add(dailyRecord);
        }
    }
}