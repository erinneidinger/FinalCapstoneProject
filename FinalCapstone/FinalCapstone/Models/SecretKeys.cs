using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class SecretKeys
    {

            public static string URLGeocode = "https://maps.googleapis.com/maps/api/geocode/json?address=";

            public static string MapURL = "https://maps.googleapis.com/maps/api/js?key=AIzaSyAWMhnK9tUjnOCe8c1KjgOjer7isFvJ-kA&callback=initMap";

            public static string URLDirections = "https://maps.googleapis.com/maps/api/directions/json?";
            public static string GeoDirectURL = URLDirections + DirectionsOrgin + DestinationKey + APIKey;
            public static string DirectionsOrgin = "orgin=";
            public static string DestinationKey = "destination=";

            public static string OtherKey = "&key=";
            public static string CallbackKey = "&callback=initMap";

            public static string MyPhoneNumber = "+12626234328";
            public static string TwilioNumber = "+18509204836";


            public static string TwilioAccountSid = "AC66f72dc969b9db40be7da62579e9db26";
            public static string TwilioAuthToken = "0cf462056d20a7d696243845a479e7e2";
            public static string APIKey = "AIzaSyAWMhnK9tUjnOCe8c1KjgOjer7isFvJ-kA";
        
    }

}