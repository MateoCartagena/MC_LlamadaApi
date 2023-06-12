using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MC_LlamadaApi;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    /*private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/

    private void IngresarButtonClicked(object sender, EventArgs e)
    {
		// Lógica del botón "Ingresar"
		string latitud = lat.Text;
        string longitud = lon.Text;

		using(var client = new HttpClient())
		{
			var url = $"https://api.openweathermap.org/data/2.5/onecall?lat=" + latitud + "&lon=" + longitud+ "&appid=0f71896498f706d9e82f03843930fc11";

			var response = client.GetAsync(url).Result;
			if (response.IsSuccessStatusCode) {

				string content = response.Content.ReadAsStringAsync().Result;

				var weatherData = JsonConvert.DeserializeObject<Clima>
				weathelabel.Text = weatherData.weather[0].descripcion
			}
		}

    }

}

