//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by NHibernate.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;

namespace KMS.Model
{
	/// <summary>
	/// a class mapping for the table: dbo.KnowledgeTagAssociation
	/// </summary>
	public  partial class KnowledgeTagAssociationInfo 
	{

	#region private fields
		Int32 _knowledgeTagId;	
		DateTime? _timeStamp;	
		TagInfo _tagInfo;	/* TagId */
		KnowledgeInfo _knowledgeInfo;	/* KnowledgeId */
	#endregion
		
	#region getter/setters		
		/// <summary>
		///		
		/// </summary>
		public virtual Int32 KnowledgeTagId
		{
			get{ return _knowledgeTagId; }
			set{ _knowledgeTagId = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual DateTime? TimeStamp
		{
			get{ return _timeStamp; }
			set{ _timeStamp = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual TagInfo TagInfo
		{
			get{ return _tagInfo; }
			set{ _tagInfo = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual KnowledgeInfo KnowledgeInfo
		{
			get{ return _knowledgeInfo; }
			set{ _knowledgeInfo = value; }
		}
	#endregion
	}
}