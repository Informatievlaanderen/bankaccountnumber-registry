namespace BankAccountNumberRegistry.Tests.Infrastructure
{
    using System;
    using AutoFixture;
    using AutoFixture.Dsl;

    internal static class Customizations
    {
        public static IPostprocessComposer<T>
            FromFactory<T>(this IFactoryComposer<T> composer, Func<Random, T> factory) =>
            composer.FromFactory<int>(value => factory(new Random(value)));

        public static void CustomizeOvoNumber(this IFixture fixture) =>
            fixture.Customize<OvoNumber>(composer =>
                composer.FromFactory(generator =>
                    new OvoNumber($"OVO{generator.Next(1, 999999).ToString().PadLeft(6, '0')}")));
    }
}
