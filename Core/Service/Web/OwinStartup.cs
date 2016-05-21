﻿using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using System.Web.Http;
using Microsoft.AspNet.SignalR;


namespace Symbiote.Core.Service.Web
{
    public class OwinStartup
    {
        private ProgramManager manager = ProgramManager.Instance();

        private WebServiceConfiguration WebServiceConfiguration { get; set; }

        public void Configuration(IAppBuilder app)
        {
            WebServiceConfiguration = WebService.GetConfiguration;
            string webRoot = WebServiceConfiguration.Root;

            app.UseCors(CorsOptions.AllowAll);

            app.MapSignalR((webRoot.Length > 0 ? "/" : "") + webRoot + "/signalr", new HubConfiguration());

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: webRoot + (webRoot.Length > 0 ? "/" : "") + "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };

            app.UseWebApi(config);

            // use Path.Combine to build the path to the filesystem for cross platform compatibility
            // windows uses web\content, linux uses web/content. 
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(manager.Directories.Web),
                RequestPath = PathString.FromUriComponent((webRoot.Length > 0 ? "/" : "") + webRoot)
            });
        }
    }
}
