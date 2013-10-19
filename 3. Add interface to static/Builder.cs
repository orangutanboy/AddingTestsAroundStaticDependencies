using System.IO;

public sealed class Builder
{
    private IConfigReader configReader;

    // 2
    public Builder()
        : this(new ConfigReader())
    { }

    // 1
    internal Builder(IConfigReader ConfigReader)
    {
        this.configReader = ConfigReader;
    }

    public string BuildString(string configName)
    {
        // 3
        var retVal = configReader.GetConfiguration(configName);
        return "xx" + retVal + "xx";
    }
}


// 3
public interface IConfigReader
{
    string GetConfiguration(string setting);
}

//4
public class ConfigReader : IConfigReader
{
    // 1
    public string GetConfiguration(string setting)
    {
        // 2
        return GetConfig(setting);
    }

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
