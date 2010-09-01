//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by NHibernate.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace KMS.Model
{
	/// <summary>
	/// a class mapping for the table: dbo.KnowledgeClass
	/// </summary>
	public  partial class KnowledgeClassInfo 
	{

	#region private fields
		Int32 _knowledgeClassId;	
		String _description;	
		String _name;	
		DateTime? _timeStamp;	
		KnowledgeClassInfo _fatherKnowledgeClassInfo;	/* FatherClassId */
		IList<KnowledgeKnowledgeClassAssociationInfo> _knowledgeKnowledgeClassAssociationInfos = new List<KnowledgeKnowledgeClassAssociationInfo>();	
		IList<KnowledgeClassInfo> _knowledgeClassInfos = new List<KnowledgeClassInfo>();	
	#endregion
		
	#region getter/setters		
		/// <summary>
		///		
		/// </summary>
		public virtual Int32 KnowledgeClassId
		{
			get{ return _knowledgeClassId; }
			set{ _knowledgeClassId = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual String Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual String Name
		{
			get{ return _name; }
			set{ _name = value; }
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
		public virtual KnowledgeClassInfo FatherKnowledgeClassInfo
		{
			get{ return _fatherKnowledgeClassInfo; }
			set{ _fatherKnowledgeClassInfo = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual IList<KnowledgeKnowledgeClassAssociationInfo> KnowledgeKnowledgeClassAssociationInfos
		{
			get{ return _knowledgeKnowledgeClassAssociationInfos; }
			set{ _knowledgeKnowledgeClassAssociationInfos = value; }
		}
		/// <summary>
		///		
		/// </summary>
		public virtual IList<KnowledgeClassInfo> KnowledgeClassInfos
		{
			get{ return _knowledgeClassInfos; }
			set{ _knowledgeClassInfos = value; }
		}
	#endregion
	}
}