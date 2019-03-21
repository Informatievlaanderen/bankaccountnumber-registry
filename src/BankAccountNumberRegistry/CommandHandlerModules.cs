namespace BankAccountNumberRegistry
{
    using Autofac;
    using Be.Vlaanderen.Basisregisters.CommandHandling;
    using Organisation;

    public static class CommandHandlerModules
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<OrganisationCommandHandlerModule>()
                .Named<CommandHandlerModule>(typeof(OrganisationCommandHandlerModule).FullName)
                .As<CommandHandlerModule>();
        }
    }
}
