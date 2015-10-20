using System.Collections.Generic;
using Untech.SharePoint.Common.Extensions;
using Untech.SharePoint.Common.MetaModels;
using Untech.SharePoint.Common.MetaModels.Visitors;

namespace Untech.SharePoint.Server.MetaModels.Visitors
{
	internal class MetaModelProcessor : IMetaModelVisitor
	{
		public MetaModelProcessor(IReadOnlyCollection<IMetaModelVisitor> steps)
		{
			Steps = steps;
		}

		public IReadOnlyCollection<IMetaModelVisitor> Steps { get; private set; }

		public void Visit(IMetaModel model)
		{
			Steps.Each(n => n.Visit(model));
		}

		public void VisitContext(MetaContext context)
		{
			throw new System.NotImplementedException();
		}

		public void VisitList(MetaList list)
		{
			throw new System.NotImplementedException();
		}

		public void VisitContentType(MetaContentType contentType)
		{
			throw new System.NotImplementedException();
		}

		public void VisitField(MetaField field)
		{
			throw new System.NotImplementedException();
		}
	}
}