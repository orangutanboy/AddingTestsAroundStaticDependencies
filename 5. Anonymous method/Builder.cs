using System;
using System.IO;

public class Builder
{
    public string BuildString(string configName)
    {
        var retVal = ConfigReader.GetConfig(configName);
        return "xx" + retVal + "xx";
    }
}

public static class ConfigReader
{
    // 2
    internal static Func<string, string> getConfigImpl { get; set; }

    // 3
    static ConfigReader()
    {
        // 4
        getConfigImpl = s => _GetConfig(s);
    }

    public static string GetConfig(string setting)
    {
        // 5
        return getConfigImpl(setting);
    }

    // 1
    private static string _GetConfig(string setting)
    {
        using (var reader = File.OpenText("..\app.config"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var elements = line.Split('=');
                if (elements[0] == setting)
                {
                    return elements[1];
                }
            }
        }
        return null;
    }
}
