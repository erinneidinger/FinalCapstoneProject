using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public static class KeyPrivate
    {
            public static string GoogleAPIKey = "AIzaSyBFPBImKyLqJvBLRI7NEEzTKTJF0nXsbZw";

            public static string URLGeocode = "https://maps.googleapis.com/maps/api/geocode/json?address=";

            public static string GeoMapURL = "https://maps.googleapis.com/maps/api/js?" + "key=" + GoogleAPIKey + "&callback=initMap";

            public static string URLDirections = "https://maps.googleapis.com/maps/api/directions/json?";
            public static string DirectionsOrgin = "orgin=";
            public static string DestinationKey = "destination=";
            public static string KeyKey = "key=";
            public static string OtherKey = "&key=";
            public static string CallbackKey = "&callback=initMap";
    }
}