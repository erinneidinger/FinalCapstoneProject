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
            public static string GeoDirectURL = URLDirections + DirectionsOrgin + DestinationKey + GoogleAPIKey;
            public static string DirectionsOrgin = "orgin=";
            public static string DestinationKey = "destination=";

            // origin={0},{1}&destination={2},{3}&sensor=false"; 
            public static string OtherKey = "&key=";
            public static string CallbackKey = "&callback=initMap";

            public static string MyPhoneNumber = "+12626234328";
            public static string TwilioNumber = "+18053228757";
            public static string TwilioAccountSid = "AC6655bf77deef388e8f1ecfc62114e80c";
            public static string TwilioAuthToken = "43e55c372145db975fa69a67ad5e0d90";

    }
}