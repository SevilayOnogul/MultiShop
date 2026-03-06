namespace MultiShop.RapidApiWebUI.Models
{
    public class WeatherViewModel
    {
        public string name { get; set; }
        public string city => name;

        public Main main { get; set; }
        public Weather[] weather { get; set; }

        public int temp => main != null ? (int)(main.temp - 273.15) : 0;

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public int humidity { get; set; }

            public int celsiusTemp => (int)(temp - 273.15);
        }

        public class Weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
    }
}