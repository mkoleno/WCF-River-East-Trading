using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

using SwaggerWcf;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global : HttpApplication
{
    public Global()
    {

    }

    protected void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add(new ServiceRoute("v1/rest", new WebServiceHostFactory(), typeof(Service)));
        RouteTable.Routes.Add(new ServiceRoute("api-docs", new WebServiceHostFactory(), typeof(SwaggerWcfEndpoint)));
    }
}