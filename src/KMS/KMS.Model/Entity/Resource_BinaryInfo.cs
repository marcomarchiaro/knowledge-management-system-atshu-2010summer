using System;
using System.Collections.Generic;

namespace KMS.Model
{
	/// <summary>
	/// a class mapping for the table: dbo.T_Resource_Binary
	/// </summary>
	public  partial class Resource_BinaryInfo : ResourceInfo 
	{
		
	#region getter/setters

        public virtual byte[] Binary { get; set; }
        public virtual string MIME { get; set; }
        public virtual int? Width { get; set; }
        public virtual int? Height { get; set; }

	#endregion
	}
}