using MC_LlamadaApi.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MC_LlamadaApi;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void IngresarButtonClicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
        string longitud = lon.Text;

		using(var client = new HttpClient())
		{

            var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud+ "&appid=ed8706a2ff40d764228fe120e82874e8";

			var response = client.GetAsync(url).Result;
			if (response.IsSuccessStatusCode) {

				string content = response.Content.ReadAsStringAsync().Result;

				var weatherData = JsonConvert.DeserializeObject<Root>(content);
				Estado.Text = weatherData.weather[0].description;
				Pais.Text = weatherData.sys.country;
				Ciudad.Text = weatherData.name;

            }
		}


    }

}

