using System;
using System.Linq;
using System.Reflection;
using Untech.SharePoint.Common.MetaModels;
using Untech.SharePoint.Common.MetaModels.Providers;
using Untech.SharePoint.Common.Utils;

namespace Untech.SharePoint.Common.Mappings.Annotation
{
	internal class AnnotatedFieldPart : IMetaFieldProvider
	{
		private readonly MemberInfo _member;
		private readonly SpFieldAttribute _fieldAttribute;

		private AnnotatedFieldPart(MemberInfo member)
		{
			Guard.CheckNotNull(nameof(member), member);

			_member = member;
			_fieldAttribute = member.GetCustomAttribute<SpFieldAttribute>(true);
		}

		#region [Public Static]

		public static bool IsAnnotated(MemberInfo member)
		{
			return member.IsDefined(typeof(SpFieldAttribute)) && !member.IsDefined(typeof(SpFieldRemovedAttribute));
		}

		public static AnnotatedFieldPart Create(PropertyInfo property)
		{
			Rules.CheckContentTypeField(property);

			return new AnnotatedFieldPart(property);
		}

		public static AnnotatedFieldPart Create(FieldInfo field)
		{
			Rules.CheckContentTypeField(field);

			return new AnnotatedFieldPart(field);
		}

		#endregion

		public MetaField GetMetaField(MetaContentType parent)
		{
			var internalName = string.IsNullOrEmpty(_fieldAttribute.Name) 
				? _member.Name 
				: _fieldAttribute.Name;

			return new MetaField(parent, _member, internalName)
			{
				CustomConverterType = _fieldAttribute.CustomConverterType,
				TypeAsString = _fieldAttribute.FieldType
			};
		}
	}
}