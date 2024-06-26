﻿using System.Text;
using Newtonsoft.Json.Linq;

namespace MvxCore.Helpers;
internal static class TokenHelper
{
    public static JObject ParseIdToken(string idToken)
    {
        // Parse the idToken to get user info
        idToken = idToken.Split('.')[1];
        idToken = Base64UrlDecode(idToken);
        return JObject.Parse(idToken);
    }

    public static string Base64UrlDecode(string s)
    {
        s = s.Replace('-', '+').Replace('_', '/');
        s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
        var byteArray = Convert.FromBase64String(s);
        var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
        return decoded;
    }
}
