﻿using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Untech.SharePoint.Common.Test.Spec;
using Untech.SharePoint.Common.Test.Spec.Models;
using Untech.SharePoint.Server.Data;

namespace Untech.SharePoint.Server.Test.Data
{
	[TestClass]
	public class QueryableTest
	{
		private static QueryableSpec _spec;

		[ClassInitialize]
		public static void Init(TestContext ctx)
		{
			_spec = new QueryableSpec(GetContext());
			_spec.Init();
		}

		[TestMethod]
		public void Aggregate()
		{
			_spec.Aggregate();
		}

		[TestMethod]
		public void Filtering()
		{
			_spec.Filtering();
		}

		[TestMethod]
		public void Ordering()
		{
			_spec.Ordering();
		}

		[TestMethod]
		public void Paging()
		{
			_spec.Paging();
		}

		[TestMethod]
		public void Set()
		{
			_spec.Set();
		}

		[TestMethod]
		public void Projection()
		{
			_spec.Projection();
		}

		private static DataContext GetContext()
		{
			var site = new SPSite(@"http://sp2013dev/sites/orm-test", SPUserToken.SystemAccount);
			var web = site.OpenWeb();
			return new DataContext(new SpServerCommonService(web, Bootstrap.GetConfig()));
		}
	}
}
