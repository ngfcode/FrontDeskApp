using System.Text;
using FrontDeskApp.WinForm.Models;
using FrontDeskApp.WinForm.Shared;
using Newtonsoft.Json;

namespace FrontDeskApp.WinForm.Services;

internal sealed class StorageService
{
	public async Task<QueryResult<StorageDto.QueryDto>> GetStorages(
		StorageDto.SearchCriteria searchCriteria)
	{
		var url = new StringBuilder();
		url.Append("storage?");
		var keyValue = searchCriteria.ToKeyValue();
		foreach (var item in keyValue)
		{
			url.Append($"{item.Key}={item.Value}&");
		}

		HttpResponseMessage response = await RestApiHelper.client.GetAsync(url.ToString());
		var data = await response.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<QueryResult<StorageDto.QueryDto>>(data);
	}
}
