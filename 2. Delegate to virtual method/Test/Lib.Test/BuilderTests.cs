using NUnit.Framework;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void BuildString()
    {
        // 3
        var target = new FakeBuilder();
        Assert.That(target.BuildString(""), Is.EqualTo("xxExpectedxx"));
    }

    // 1
    private class FakeBuilder : Builder
    {
        // 2
        protected override string GetConfig(string configName)
        {
            return "Expected";
        }
    }
}
