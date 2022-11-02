using System.Linq.Expressions;
using System.Reflection;
using Ardalis.Specification;

namespace FrontDeskApp.Application.Common.Extensions;

public static class SpecificationExtension
{
	/// <summary>
	/// This extension method performs ordering given the field name and sequence.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="specificationBuilder"></param>
	/// <param name="fieldName"></param>
	/// <param name="isAscending"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public static IOrderedSpecificationBuilder<T> OrderBy<T>(
		this ISpecificationBuilder<T> specificationBuilder,
		string fieldName,
		bool isAscending)
	{
		var matchedProperty = typeof(T).GetProperty(fieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
		if (matchedProperty == null)
		{
			//Actually you can decide no to throw here. Ordering is not a crucial task.
			throw new ArgumentException("name");
		}

		var paramExpr = Expression.Parameter(typeof(T));
		var propAccess = Expression.PropertyOrField(paramExpr, matchedProperty.Name);
		var propAccessConverted = Expression.Convert(propAccess, typeof(object));
		var expr = Expression.Lambda<Func<T, object?>>(propAccessConverted, paramExpr);

		if (isAscending)
		{
			specificationBuilder.OrderBy(expr);
		}

		else
		{
			specificationBuilder.OrderByDescending(expr);
		}

		var orderedSpecificationBuilder = new OrderedSpecificationBuilder<T>(specificationBuilder.Specification);

		return orderedSpecificationBuilder;
	}
}
