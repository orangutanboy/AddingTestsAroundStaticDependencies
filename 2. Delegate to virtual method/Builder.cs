using System.IO;

public class Builder
{
    public string BuildString(string configName)
    {
        // 3
        var retVal = GetConfig(configName);
        return "xx" + retVal + "xx";
    }

    // 1
    protected virtual string GetConfig(string configName)
    {
        // 2
        return ConfigReader.GetConfig(configName);
    }
}

public class ConfigReader
{
    public static string GetConfig(string setting)
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
