using System;

using FluentAssertions;

using Xunit;

namespace StarkNet.Core.UnitTests;

public class BlockIdentifierFactoryUnitTests
{
    [Theory]
    [DefaultInlineAutoData("")]
    [DefaultInlineAutoData("")]
    public void BlockIdentifierFactorySuccess(
        string identifier)
    {
        BlockIdentifierFactory.Create(identifier);
    }

/*    [Theory]
    [DefaultInlineAutoData("")]
    public void BlockIdentifierFactoryNotNullException(
    string identifier)
    {
        Action act = () => subject.Foo2("Hello");

        var res = BlockIdentifierFactory.Create(identifier);

        res.Should().
    }*/
}