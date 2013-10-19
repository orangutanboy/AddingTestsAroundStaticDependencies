using System.IO;

public class Builder
{
    public string BuildString(string configName)
    {
        var retVal = ConfigReader.GetConfig(configName);
        return "xx" + retVal + "xx";
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
