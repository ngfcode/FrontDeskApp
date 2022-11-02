using System.Net.Http.Json;
using FrontDeskApp.WinForm.Models;
using FrontDeskApp.WinForm.Shared;

namespace FrontDeskApp.WinForm.Services;

internal sealed class LoginService
{
	public async Task<DtoResult<AccountDto.LoginResponseDto>> LoginAsync(
		string userName,
		string password)
	{
		var dto = new AccountDto.LoginDto
		{
			UserName = userName,
			Password = password
		};
		HttpResponseMessage response = await RestApiHelper.client.PostAsJsonAsync(
			   "account/login", dto);

		var result = await response.Content.ReadAsAsync<DtoResult<AccountDto.LoginResponseDto>>();

		return result;
	}
}
