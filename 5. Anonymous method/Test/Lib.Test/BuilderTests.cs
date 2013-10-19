using NUnit.Framework;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void BuildString()
    {
        // 1
        ConfigReader.getConfigImpl = s => "Expected";
        
        var target = new Builder();
        Assert.That(target.BuildString(""), Is.EqualTo("xxExpectedxx"));
    }
}
