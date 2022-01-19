using Autofac;
using Samsung.Web.Areas.Admin.Models;

namespace Samsung.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateTeamModel>().AsSelf();
            builder.RegisterType<EditTeamModel>().AsSelf();
            builder.RegisterType<TeamListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
