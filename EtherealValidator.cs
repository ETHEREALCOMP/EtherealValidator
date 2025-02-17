
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace EtherealValidator;

public static class EtherealValidator
{
    private static readonly Dictionary<string, bool> Cache = new Dictionary<string, bool>();

    public static bool IsValidEmail(string email)
    {
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex);
    }

    public static bool IsValidEmailWithCache(string email)
    {
        if (Cache.ContainsKey(email))
            return Cache[email];

        var result = IsValidEmail(email);
        Cache[email] = result;
        return result;
    }

    public static bool IsValidPhoneNumber(string phone)
    {
        var phoneRegex = @"^\+?\d{10,15}$";
        return Regex.IsMatch(phone, phoneRegex);
    }

    public static bool IsStrongPassword(string password)
    {
        var regex = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        return Regex.IsMatch(password, regex);
    }

    public static bool IsValidUrl(string url)
    {
        var urlRegex = @"^(http|https):\/\/[a-zA-Z0-9-]+\.[a-zA-Z]{2,6}(\S*)$";
        return Regex.IsMatch(url, urlRegex);
    }


    public static bool IsValidJson(string json)
    {
        try
        {
            JsonConvert.DeserializeObject(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public static bool IsValidXml(string xml)
    {
        try
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return true;
        }
        catch (XmlException)
        {
            return false;
        }
    }
}
