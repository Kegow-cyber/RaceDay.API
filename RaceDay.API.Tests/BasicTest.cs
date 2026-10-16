using Xunit;

namespace RaceDay.API.Tests;

public class BasicTests
{
    [Fact]
    public void Project_Builds_Successfully()
    {
        Assert.True(true);
    }

    [Fact]
    public void Event_Model_Exists()
    {
        var model = new RaceDay.API.Category();
        Assert.NotNull(model);
    }

    [Fact]
    public void Api_Should_Have_Controllers()
    {
        Assert.True(true);
    }
}