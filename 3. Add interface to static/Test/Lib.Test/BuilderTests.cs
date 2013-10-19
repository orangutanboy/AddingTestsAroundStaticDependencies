using NUnit.Framework;
using Rhino.Mocks;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void BuildString()
    {
        // 1
        var configFileReader = MockRepository.GenerateMock<IConfigReader>();
        configFileReader.Stub(fr => fr.GetConfiguration(Arg<string>.Is.Anything))
            .Return("Expected");

        //2
        var target = new Builder(configFileReader);
        Assert.That(target.BuildString(""), Is.EqualTo("xxExpectedxx"));
    }
}
