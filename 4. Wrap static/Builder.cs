using System.IO;

public class Builder
{
    private IConfigReaderWrapper configReader;

    // 2
    public Builder()
        : this(new ConfigReaderWrapper())
    { }

    // 1
    internal Builder(IConfigReaderWrapper ConfigReader)
    {
        this.configReader = ConfigReader;
    }

    public string BuildString(string configName)
    {
        // 3
        var retVal = configReader.GetConfig(configName);
        return "xx" + retVal + "xx";
    }
}

// 3
public interface IConfigReaderWrapper
{
    string GetConfig(string setting);
}

// 1
public class ConfigReaderWrapper : IConfigReaderWrapper
{
    // 2
    public string GetConfig(string setting)
    {
        return ConfigReader.GetConfig(setting);
    }
}

public static class ConfigReader
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
