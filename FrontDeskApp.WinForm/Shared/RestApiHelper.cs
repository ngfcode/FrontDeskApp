using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp.WinForm.Shared;

internal static class RestApiHelper
{
	public static HttpClient client = new HttpClient();
	public static string AccessToken = null;

	public static void Setup()
	{
		client.BaseAddress = new Uri("https://localhost:7116/api/");
		client.DefaultRequestHeaders.Accept.Add(
			  new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
	}

	public static void AddAuthenticationToken()
	{
		if (AccessToken is not null)
		{
			client.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
		}
	}
}
