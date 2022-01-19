using Autofac;
using Samsung.Placing.Contexts;
using Samsung.Placing.Services;
using Samsung.Placing.Repositories;
using Samsung.Placing.UnitOfWorks;

namespace Samsung.Placing
{
    public class PlacingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public PlacingModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlacingDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<PlacingDbContext>().As<IPlacingDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TeamRepository>().As<ITeamRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeveloperService>().As<IDeveloperService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TeamService>().As<ITeamService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PlacingUnitOfWork>().As<IPlacingUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
