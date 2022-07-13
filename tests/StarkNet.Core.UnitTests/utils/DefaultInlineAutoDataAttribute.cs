using System;

using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace StarkNet.Core.UnitTests;

public class DefaultInlineAutoDataAttribute : InlineAutoDataAttribute
{
    public DefaultInlineAutoDataAttribute(params object[] values) : base(new DefaultAutoDataAttribute(), values) { }
}


public class DefaultAutoDataAttribute : AutoDataAttribute
{
    public DefaultAutoDataAttribute(Type? t = null)
        : base(() => new Fixture().Customize(new AutoNSubstituteCustomization { ConfigureMembers = true })) { }
}