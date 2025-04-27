namespace HobbyTracker.Tests;

using HobbyTracker;

public class ActivityCreatorTests
{
    Activity testActivity = new Activity();
    
    public ActivityCreatorTests()
    {
        testActivity.name = "testing";
        testActivity.priority = "High";
    }

    [Fact]
    public void ActivytCreatorName()
    {
        Assert.Equal("testing", testActivity.name);
    }
    [Fact]
    public void ActivytCreatorPriority()
    {
        Assert.Equal("High", testActivity.priority);
    }
}