using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bounce22
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			DataStore.Responses = new List<string>();
        }
    }
	public static class DataStore
	{
		static List<string> _responses;
		public static List<string> Responses
		{
			get
			{
				return _responses;
			}
			set
			{
				_responses = value;
			}
		}
	}
}
