﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Untech.SharePoint.Common.Data.QueryModels;

namespace Untech.SharePoint.Common.Data
{
	internal static class SpQueryable
	{

		internal static IEnumerable<T> GetAll<T>(ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeGetAll(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			return Expression.Call(OpUtils.SpqGetAll.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)));

		}

		internal static MethodCallExpression MakeAsQueryable(Type entityType, Expression source)
		{
			return Expression.Call(OpUtils.QAsQueryable.MakeGenericMethod(entityType), source);
		}

		internal static IEnumerable<T> Take<T>(ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeTake(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			return Expression.Call(OpUtils.SpqTake.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)));
		}

		internal static IEnumerable<T> Skip<T>(ISpItemsProvider itemsProvider, QueryModel queryModel, int count)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeSkip(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel, int count)
		{
			return Expression.Call(OpUtils.SpqSkip.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)),
				Expression.Constant(count));
		}

		internal static T First<T>(ISpItemsProvider itemsProvider, QueryModel queryModel, bool throwIfNothing, bool throwIfMultiple)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeFirst(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel, bool throwIfNothing, bool throwIfMultiple)
		{
			return Expression.Call(OpUtils.SpqFirst.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)),
				Expression.Constant(throwIfNothing),
				Expression.Constant(throwIfMultiple));
		}

		internal static T ElementAt<T>(ISpItemsProvider itemsProvider, QueryModel queryModel, int index, bool throwIfNothing)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeElementAt(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel, int index, bool throwIfNothing)
		{
			return Expression.Call(OpUtils.SpqElementAt.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)),
				Expression.Constant(index),
				Expression.Constant(throwIfNothing));
		}

		internal static bool Any(ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeAny(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			return Expression.Call(OpUtils.SpqAny.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)));

		}

		internal static int Count(ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			throw new NotImplementedException();
		}

		internal static MethodCallExpression MakeCount(Type entityType, ISpItemsProvider itemsProvider, QueryModel queryModel)
		{
			return Expression.Call(OpUtils.SpqCount.MakeGenericMethod(entityType),
				Expression.Constant(itemsProvider, typeof(ISpItemsProvider)),
				Expression.Constant(queryModel, typeof(QueryModel)));

		}
	}
}
