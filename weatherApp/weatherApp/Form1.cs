using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace weatherApp
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "0aed29f684a1853c62bbc985a1e2c0b3";
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/forecast?";

        private HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private  void FetchWeatherButton_Click(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string cityName = CityTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(cityName))
            {
                string apiUrl = $"{ApiUrl}?key={ApiKey}&q={cityName}";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Parse the response and update the UI with weather information
                        // You need to implement this part based on the weatherAPI's response structure.
                        // Update the Label with relevant weather information.
                    }
                    else
                    {
                        MessageBox.Show("Weather data retrieval failed. Please try again later.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a city name.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
