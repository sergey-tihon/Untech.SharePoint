﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Untech.SharePoint.Common.CodeAnnotations;

namespace Untech.SharePoint.Common.Models
{
	/// <summary>
	/// Represents geo info data.
	/// </summary>
	[PublicAPI]
	[DataContract]
	public class GeoInfo
	{
		/// <summary>
		/// Gets or sets altitude.
		/// </summary>
		[DataMember]
		[JsonProperty("altitude")]
		public double Altitude { get; set; }

		/// <summary>
		/// Gets or sets latitude.
		/// </summary>
		[DataMember]
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		/// <summary>
		/// Gets or sets longitude.
		/// </summary>
		[DataMember]
		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		/// <summary>
		/// Gets or sets measure.
		/// </summary>
		[DataMember]
		[JsonProperty("measure")]
		public double Measure { get; set; }
	}
}