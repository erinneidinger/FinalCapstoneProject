using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public static class PrivateKey
    {
        public static string GoogleAPIKey = "AIzaSyAVFdH0lLZBSWw7m4EXHysoboX9fOC7f6s";

        public static string URLGeocode = "https://maps.googleapis.com/maps/api/geocode/json?";

        public static string GeoMapURL = "https://maps.googleapis.com/maps/api/js?";

        public static string URLDirections = "https://maps.googleapis.com/maps/api/directions/json?";
        public static string DirectionsOrgin = "orgin=";
        public static string DestinationKey = "destination=";
        public static string KeyKey = "key=";
        public static string CallbackKey = "&callback=initMap";
    }
}