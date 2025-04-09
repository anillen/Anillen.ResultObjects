using Xunit;

namespace Anillen.ResultObjects.Tests;

public class ResultValueTests
{
    [Fact]
    public void Success()
    {
        var result = ResultValue<string>.Success("Test");
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal("Test", result.Value);
        Assert.Equal(result.Error, Error.None);
    }

    [Fact]
    public void Failure()
    {
        var result = ResultValue<string>.Failure(new Error("TestCode", "TestDescription"));
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.NotEqual(result.Error, Error.None);
        Assert.Throws<Exception>(() => result.Value);
    }
}