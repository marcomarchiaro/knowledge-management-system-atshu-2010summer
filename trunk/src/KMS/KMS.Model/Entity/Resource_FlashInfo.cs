using System;
using System.Collections.Generic;

namespace KMS.Model
{
	/// <summary>
	/// a class mapping for the table: dbo.T_Resource_Flash
	/// </summary>
	public  partial class Resource_FlashInfo : ResourceInfo 
	{
		
	#region getter/setters

        public virtual string Source { get; set; }
        public virtual string SourceName { get; set; }
        public virtual int? Width { get; set; }
        public virtual int? Height { get; set; }

	#endregion
	}
}