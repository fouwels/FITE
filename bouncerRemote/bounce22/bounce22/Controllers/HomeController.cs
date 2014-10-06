using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace bounce22.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public string Index()
		{
			var data = new List<string>();
			data.AddRange(DataStore.Responses);
			//DataStore.Responses.Clear();
			return JsonConvert.SerializeObject(DataStore.Responses);
		}

		// POST: Home/CreateSG
		[HttpPost]
		public HttpStatusCode CreateSG(FormCollection collection)
		{
			Debug.WriteLine("Create hit");
			//var text = collection["text"];
			var text = collection["text"];
			DataStore.Responses.Add(text);
			return HttpStatusCode.Accepted;
		}
		// POST: Home/CreateTW
		[HttpPost]
		public HttpStatusCode CreateTW(FormCollection collection)
		{
			Debug.WriteLine("Create hit");
			//var text = collection["text"];
			var text = collection["body"];
			DataStore.Responses.Add(text);
			return HttpStatusCode.Accepted;
		}

		public HttpStatusCode Clear()
		{
			DataStore.Responses.Clear();
			return HttpStatusCode.Accepted;
		}
	}
}