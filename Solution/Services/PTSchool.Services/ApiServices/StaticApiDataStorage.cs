using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.ApiKeys
{
    public static class StaticApiDataStorage
    {
        public static class NewsApi
        {
            public static string ApiKey = "503fc5cefc084d7bbbbb04f855a85da6";

            public static string Url = $"http://newsapi.org/v2/everything?q=education&language=en&sources=bbc-news&sortBy=publishedAt&apiKey={ApiKey}";
        }

        public static class WeatherApi
        {
            public static string ApiKey = "f32fd645c455b498e9fd278e8ca0625e";

            public static double latitudeSchool = 42.514083;
            public static double longitudeSchool = 27.469551;

            public static string Url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitudeSchool:F5}&lon={longitudeSchool:F5}&appid={ApiKey}";
        }
    }
}
