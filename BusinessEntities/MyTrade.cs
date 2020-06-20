#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.BusinessEntities.BusinessEntities
File: MyTrade.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.BusinessEntities
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using Ecng.Common;
	using Ecng.ComponentModel;
    using Ecng.Serialization;

	using StockSharp.Messages;
	using StockSharp.Localization;

	/// <summary>
	/// Own trade.
	/// </summary>
	[Serializable]
	[System.Runtime.Serialization.DataContract]
	[DisplayNameLoc(LocalizedStrings.Str502Key)]
	[DescriptionLoc(LocalizedStrings.Str503Key)]
	public class MyTrade : NotifiableObject, IExtendableEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MyTrade"/>.
		/// </summary>
		public MyTrade()
		{
		}

		/// <summary>
		/// Order, for which a trade was filled.
		/// </summary>
		[DataMember]
		[RelationSingle]
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str504Key,
			Description = LocalizedStrings.Str505Key,
			GroupName = LocalizedStrings.GeneralKey,
			Order = 0)]
		public Order Order { get; set; }

		/// <summary>
		/// Trade info.
		/// </summary>
		[DataMember]
		[RelationSingle]
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str506Key,
			Description = LocalizedStrings.Str507Key,
			GroupName = LocalizedStrings.GeneralKey,
			Order = 1)]
		public Trade Trade { get; set; }

		/// <summary>
		/// Commission.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str159Key,
			Description = LocalizedStrings.Str160Key,
			GroupName = LocalizedStrings.Str436Key,
			Order = 0)]
		[Nullable]
		public decimal? Commission { get; set; }

		/// <summary>
		/// Commission currency. Can be <see lnagword="null"/>.
		/// </summary>
		public string CommissionCurrency { get; set; }

		/// <summary>
		/// Slippage in trade price.
		/// </summary>
		[DataMember]
		[Nullable]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str163Key,
			Description = LocalizedStrings.Str164Key,
			GroupName = LocalizedStrings.Str436Key,
			Order = 1)]
		public decimal? Slippage { get; set; }

		private decimal? _pnL;

		/// <summary>
		/// The profit, realized by trade.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.PnLKey,
			Description = LocalizedStrings.PnLKey + LocalizedStrings.Dot,
			GroupName = LocalizedStrings.Str436Key,
			Order = 2)]
		[Nullable]
		public decimal? PnL
		{
			get => _pnL;
			set
			{
				if (_pnL == value)
					return;

				_pnL = value;
				NotifyChanged(nameof(PnL));
			}
		}

		/// <summary>
		/// The position, generated by trade.
		/// </summary>
		[DataMember]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.Str862Key,
			Description = LocalizedStrings.Str862Key + LocalizedStrings.Dot,
			GroupName = LocalizedStrings.Str436Key,
			Order = 2)]
		[Nullable]
		public decimal? Position { get; set; }

		/// <summary>
		/// Used to identify whether the order initiator is an aggressor or not in the trade.
		/// </summary>
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.InitiatorKey,
			Description = LocalizedStrings.InitiatorTradeKey,
			GroupName = LocalizedStrings.GeneralKey,
			Order = 3)]
		[Nullable]
		public bool? Initiator { get; set; }

		/// <summary>
		/// Yield.
		/// </summary>
		[DataMember]
		public decimal? Yield { get; set; }

		[field: NonSerialized]
		private IDictionary<string, object> _extensionInfo;

		/// <inheritdoc />
		[Ignore]
		[XmlIgnore]
		[Display(
			ResourceType = typeof(LocalizedStrings),
			Name = LocalizedStrings.ExtendedInfoKey,
			Description = LocalizedStrings.Str427Key,
			GroupName = LocalizedStrings.GeneralKey,
			Order = 100)]
		[Obsolete]
		public IDictionary<string, object> ExtensionInfo
		{
			get => _extensionInfo;
			set => _extensionInfo = value;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return LocalizedStrings.Str509Params.Put(Trade, Order);
		}
	}
}