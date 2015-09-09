﻿using System.Collections.Generic;
using Untech.SharePoint.Common.Visitors;

namespace Untech.SharePoint.Common.Services
{
	public interface ICommonService
	{
		IEnumerable<IMetaModelVisitor> Visitors { get; }

	}
}