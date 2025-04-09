using System.Runtime.InteropServices.JavaScript;
using Xunit;

namespace Anillen.ResultObjects.Tests;

public class ResultTests
{
    [Fact]
    public void Success()
    {
        var result = Result.Success();
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(result.Error, Error.None);
    }

    [Fact]
    public void Failure()
    {
        var result = Result.Failure(new Error("TestCode", "TestDescription"));
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.NotEqual(result.Error, Error.None);
    }
}