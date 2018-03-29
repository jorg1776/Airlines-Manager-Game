/*
using AirlinesManagerGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Device.Location;

namespace AirlinesManagerGame.FlightManager
{
    public class GoogleGeoCodeRequest
    {
        public static int GetDistance(Airport origin, Airport destination)
        {
            string originAirportName = origin.Name.Replace(' ', '+');
            string destinationAirportName = destination.Name.Replace(' ', '+');
            var googleAPIKey = System.Configuration.ConfigurationManager.AppSettings["GoogleAPIKey"];
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=" + googleAPIKey;

            GeoCoordinate originCoordinates = GetCoordinates(url, originAirportName);
            GeoCoordinate destinationCoordinates = GetCoordinates(url, destinationAirportName);

            double distanceInMeters = originCoordinates.GetDistanceTo(destinationCoordinates);
            double distanceInMiles = ConvertToMiles(distanceInMeters);

            return Convert.ToInt32(distanceInMiles);
        }

        private static double ConvertToMiles(double meters) { return meters * 0.00062137119223733; }

        public static GeoCoordinate GetCoordinates(string url, string airportName)
        {
            string json = GetGoogleGeoCodeJson(string.Format(url, airportName));
            var root = JsonConvert.DeserializeObject<RootObject>(json);

            double latitude = 0;
            double longitude = 0;

            foreach (var singleResult in root.results)
            {
                var location = singleResult.geometry.location;
                latitude = location.lat;
                longitude = location.lng;
            }

            return new GeoCoordinate(latitude, longitude);
        }

        private static string GetGoogleGeoCodeJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                Console.WriteLine("Could not get Json from Google Maps Geocode API");
                return "";
            }
            
        }

        #region Google GeoCode Json Properties

        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Bounds
        {
            public Location northeast { get; set; }
            public Location southwest { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Bounds viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public bool partial_match { get; set; }
            public List<string> types { get; set; }
        }

        public class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }

        #endregion
    }
}
*/