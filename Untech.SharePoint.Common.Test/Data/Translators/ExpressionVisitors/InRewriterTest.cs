﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Untech.SharePoint.Common.Data.Translators.ExpressionVisitors;
using Untech.SharePoint.Common.Extensions;

namespace Untech.SharePoint.Common.Test.Data.Translators.ExpressionVisitors
{
	[TestClass]
	public class InRewriterTest : BaseExpressionVisitorTest<InRewriter>
	{
		[TestMethod]
		public void CanRewriteInArray()
		{
			var possibleValues = new[] {"#1", "#2", "#3"};
			TestWitEvaluator(n => n.String1.In(possibleValues), n => n.String1 == "#1" || n.String1 == "#2" || n.String1 == "#3");
		}

		[TestMethod]
		public void CanRewriteInList()
		{
			var possibleValues = new List<string> { "#1", "#2", "#3" };
			TestWitEvaluator(n => n.String1.In(possibleValues), n => n.String1 == "#1" || n.String1 == "#2" || n.String1 == "#3");
		}

		[TestMethod]
		public void CanRewriteNotInArray()
		{
			var possibleValues = new[] { "#1", "#2", "#3" };
			TestWitEvaluator(n => !n.String1.In(possibleValues), n => n.String1 != "#1" && n.String1 != "#2" && n.String1 != "#3");
		}

		[TestMethod]
		public void CanRewriteNotInList()
		{
			var possibleValues = new List<string> { "#1", "#2", "#3" };
			TestWitEvaluator(n => !n.String1.In(possibleValues), n => n.String1 != "#1" && n.String1 != "#2" && n.String1 != "#3");
		}

		[TestMethod]
		public void CanRewriteArrayContains()
		{
			var possibleValues = new[] { "#1", "#2", "#3" };
			TestWitEvaluator(n => possibleValues.Contains(n.String1), n => n.String1 == "#1" || n.String1 == "#2" || n.String1 == "#3");
		}

		[TestMethod]
		public void CanRewriteListContains()
		{
			// NOTE: List.Contains not allowed. Fix later
			IEnumerable<string> possibleValues = new List<string> { "#1", "#2", "#3" };
			TestWitEvaluator(n => possibleValues.Contains(n.String1), n => n.String1 == "#1" || n.String1 == "#2" || n.String1 == "#3");
		}

		[TestMethod]
		public void CanRewriteArrayNotContains()
		{
			var possibleValues = new[] { "#1", "#2", "#3" };
			TestWitEvaluator(n => !possibleValues.Contains(n.String1), n => n.String1 != "#1" && n.String1 != "#2" && n.String1 != "#3");
		}

		[TestMethod]
		public void CanRewriteListNotContains()
		{
			// NOTE: List.Contains not allowed. Fix later
			IEnumerable<string> possibleValues = new List<string> { "#1", "#2", "#3" };
			TestWitEvaluator(n => !possibleValues.Contains(n.String1), n => n.String1 != "#1" && n.String1 != "#2" && n.String1 != "#3");
		}

		[TestMethod]
		public void CannotRewriteStringContains()
		{
			TestWitEvaluator(n => n.String1.Contains("TEST"), n => n.String1.Contains("TEST"));
		}
	}
}
