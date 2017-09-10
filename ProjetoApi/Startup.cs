using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using ProjetoAcessoDados.Context;
using ProjetoAcessoDados.Base;
using System.Web.Http;
using SimpleInjector.Extensions.ExecutionContextScoping;
using ProjetoAcessoDados.Interfaces;
using ProjetoAcessoDados.Services;

[assembly: OwinStartup(typeof(ProjetoApi.Startup))]

namespace ProjetoApi
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public SimpleInjector.Container Container = null;
        public void Configuration(IAppBuilder app)
        {
            this.Container = new SimpleInjector.Container();
            InitializeContainer(Container);
            Container.Verify();

            app.Use(async (context, next) =>
            {
                using (Container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(this.Container);

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        private void ConfigureOAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static void InitializeContainer(Container container)
        {
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            container.Register<AppContext>(Lifestyle.Scoped);
            container.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), Lifestyle.Scoped);

            container.Register<IUsuarioService, UsuarioService>();
            container.Register<IFinanceiroService, FinanceiroService>();
            container.Register<ICadastroService, CadastroService>();
        }
    }
}
