using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using FrontDeskApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrontDeskApp.Infrastructure.Persistence.Extensions;

[ExcludeFromCodeCoverage]
public static class SoftDeleteQueryExtension
{
	public static void AddSoftDeleteQueryFilter(
		this IMutableEntityType entityData)
	{
		var methodToCall = typeof(SoftDeleteQueryExtension)
			.GetMethod(nameof(GetSoftDeleteFilter),
			BindingFlags.NonPublic | BindingFlags.Static)
			.MakeGenericMethod(entityData.ClrType);

		var filter = methodToCall.Invoke(null, Array.Empty<object>());
		entityData.SetQueryFilter((LambdaExpression)filter);

		var softDeleteProp = entityData.FindProperty(nameof(ISoftDelete.IsSoftDeleted));
		if (entityData.FindIndex(softDeleteProp) is null)
		{
			entityData.AddIndex(softDeleteProp);
		}
	}

	private static LambdaExpression GetSoftDeleteFilter<TEntity>()
		where TEntity : class, ISoftDelete
	{
		Expression<Func<TEntity, bool>> filter = x => x.IsSoftDeleted == 0;
		return filter;
	}
}
