using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Roles;
using FrontDeskApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FrontDeskApp.Infrastructure.Services;

internal class RoleService : IRoleService
{
	private readonly RoleManager<ApplicationRole> _roleManager;

	public RoleService(
		RoleManager<ApplicationRole> roleManager)
	{
		_roleManager = Guard.Against.Null(roleManager, nameof(roleManager));
	}

	public Task<ApplicationRoleDto.Dto> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task<List<ApplicationRoleDto.IndexDto>> ListAsync(
		CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
