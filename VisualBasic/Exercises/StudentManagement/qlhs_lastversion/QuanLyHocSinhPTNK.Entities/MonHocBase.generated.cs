﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file MonHoc.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace QuanLyHocSinhPTNK.Entities
{
	///<summary>
	/// An object representation of the 'MonHoc' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class MonHocBase : EntityBase, QuanLyHocSinhPTNK.Entities.IMonHoc, IEntityId<MonHocKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private MonHocEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private MonHocEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private MonHocEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<MonHoc> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event MonHocEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event MonHocEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="MonHocBase"/> instance.
		///</summary>
		public MonHocBase()
		{
			this.entityData = new MonHocEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="MonHocBase"/> instance.
		///</summary>
		///<param name="maMon"></param>
		///<param name="tenMon"></param>
		public MonHocBase(System.String maMon, System.String tenMon)
		{
			this.entityData = new MonHocEntityData();
			this.backupData = null;

			this.MaMon = maMon;
			this.TenMon = tenMon;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="MonHoc"/> instance.
		///</summary>
		///<param name="maMon"></param>
		///<param name="tenMon"></param>
		public static MonHoc CreateMonHoc(System.String maMon, System.String tenMon)
		{
			MonHoc newMonHoc = new MonHoc();
			newMonHoc.MaMon = maMon;
			newMonHoc.TenMon = tenMon;
			return newMonHoc;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the MaMon property. 
		///		
		/// </summary>
		/// <value>This type is nchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false, 10)]
		public virtual System.String MaMon
		{
			get
			{
				return this.entityData.MaMon; 
			}
			
			set
			{
				if (this.entityData.MaMon == value)
					return;
					
				OnColumnChanging(MonHocColumn.MaMon, this.entityData.MaMon);
				this.entityData.MaMon = value;
				this.EntityId.MaMon = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(MonHocColumn.MaMon, this.entityData.MaMon);
				OnPropertyChanged("MaMon");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the MaMon property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the MaMon property.</remarks>
		/// <value>This type is nchar</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.String OriginalMaMon
		{
			get { return this.entityData.OriginalMaMon; }
			set { this.entityData.OriginalMaMon = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the TenMon property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false, 50)]
		public virtual System.String TenMon
		{
			get
			{
				return this.entityData.TenMon; 
			}
			
			set
			{
				if (this.entityData.TenMon == value)
					return;
					
				OnColumnChanging(MonHocColumn.TenMon, this.entityData.TenMon);
				this.entityData.TenMon = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(MonHocColumn.TenMon, this.entityData.TenMon);
				OnPropertyChanged("TenMon");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of Diem objects
		///	which are related to this object through the relation FK_Diem_MonHoc
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<Diem> DiemCollection
		{
			get { return entityData.DiemCollection; }
			set { entityData.DiemCollection = value; }	
		}
		#endregion Children Collections
		
		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("MaMon", "Ma Mon"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("MaMon", "Ma Mon", 10));
			ValidationRules.AddRule(
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("TenMon", "Ten Mon"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("TenMon", "Ten Mon", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "MonHoc"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"MaMon", "TenMon"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as MonHocEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (MonHoc) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<MonHoc>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as MonHoc);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed MonHoc Entity 
		///</summary>
		public virtual MonHoc Copy()
		{
			//shallow copy entity
			MonHoc copy = new MonHoc();
			copy.SuppressEntityEvents = true;
			copy.MaMon = this.MaMon;
			copy.OriginalMaMon = this.OriginalMaMon;
			copy.TenMon = this.TenMon;
			
		
			//deep copy nested objects
			copy.DiemCollection = (TList<Diem>) MakeCopyOf(this.DiemCollection); 
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed MonHoc Entity which is a deep copy of the current entity.
		///</summary>
		public virtual MonHoc DeepCopy()
		{
			return EntityHelper.Clone<MonHoc>(this as MonHoc);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as MonHocEntityData;
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as MonHocEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(MonHocColumn column)
		{
			switch(column)
			{
					case MonHocColumn.MaMon:
					return entityData.MaMon != _originalData.MaMon;
					case MonHocColumn.TenMon:
					return entityData.TenMon != _originalData.TenMon;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has data changed]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.MaMon != _originalData.MaMon;
			result = result || entityData.TenMon != _originalData.TenMon;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="MonHocBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is MonHocBase)
				return Equals(this, (MonHocBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="MonHocBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.MaMon.GetHashCode() ^ 
					this.TenMon.GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="MonHocBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(MonHocBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="MonHocBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="MonHocBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="MonHocBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(MonHocBase Object1, MonHocBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.MaMon != Object2.MaMon)
				equal = false;
			if (Object1.TenMon != Object2.TenMon)
				equal = false;
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((MonHocBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static MonHocComparer GetComparer()
        {
            return new MonHocComparer();
        }
        */

        // Comparer delegates back to MonHoc
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(MonHoc rhs, MonHocColumn which)
        {
            switch (which)
            {
            	
            	
            	case MonHocColumn.MaMon:
            		return this.MaMon.CompareTo(rhs.MaMon);
            		
            		                 
            	
            	
            	case MonHocColumn.TenMon:
            		return this.TenMon.CompareTo(rhs.TenMon);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<MonHocKey> Members
		
		// member variable for the EntityId property
		private MonHocKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual MonHocKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new MonHocKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("MonHoc")
					.Append("|").Append( this.MaMon.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- MaMon: {0}{2}- TenMon: {1}{2}", 
				this.MaMon,
				this.TenMon,
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'MonHoc' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class MonHocEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// MaMon : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "MonHoc"</remarks>
			public System.String MaMon;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalMaMon;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// TenMon : 
		/// </summary>
		public System.String		  TenMon = string.Empty;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#region DiemCollection
		
		private TList<Diem> diemMaMon;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation diemMaMon
		/// </summary>	
		public TList<Diem> DiemCollection
		{
			get
			{
				if (diemMaMon == null)
				{
				diemMaMon = new TList<Diem>();
				}
	
				return diemMaMon;
			}
			set { diemMaMon = value; }
		}
		
		#endregion

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			MonHocEntityData _tmp = new MonHocEntityData();
						
			_tmp.MaMon = this.MaMon;
			_tmp.OriginalMaMon = this.OriginalMaMon;
			
			_tmp.TenMon = this.TenMon;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this.diemMaMon != null)
				_tmp.DiemCollection = (TList<Diem>) MakeCopyOf(this.DiemCollection); 
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct



		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="MonHocColumn"/> which has raised the event.</param>
		public void OnColumnChanging(MonHocColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="MonHocColumn"/> which has raised the event.</param>
		public void OnColumnChanged(MonHocColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="MonHocColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(MonHocColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				MonHocEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new MonHocEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="MonHocColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(MonHocColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				MonHocEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new MonHocEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region MonHocEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="MonHoc"/> object.
	/// </remarks>
	public class MonHocEventArgs : System.EventArgs
	{
		private MonHocColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the MonHocEventArgs class.
		///</summary>
		public MonHocEventArgs(MonHocColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the MonHocEventArgs class.
		///</summary>
		public MonHocEventArgs(MonHocColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The MonHocColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="MonHocColumn" />
		public MonHocColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all MonHoc related events.
	///</summary>
	public delegate void MonHocEventHandler(object sender, MonHocEventArgs e);
	
	#region MonHocComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class MonHocComparer : System.Collections.Generic.IComparer<MonHoc>
	{
		MonHocColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:MonHocComparer"/> class.
        /// </summary>
		public MonHocComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MonHocComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public MonHocComparer(MonHocColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="MonHoc"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="MonHoc"/> to compare.</param>
        /// <param name="b">The second <c>MonHoc</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(MonHoc a, MonHoc b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(MonHoc entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(MonHoc a, MonHoc b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public MonHocColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region MonHocKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="MonHoc"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class MonHocKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the MonHocKey class.
		/// </summary>
		public MonHocKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the MonHocKey class.
		/// </summary>
		public MonHocKey(MonHocBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.MaMon = entity.MaMon;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the MonHocKey class.
		/// </summary>
		public MonHocKey(System.String maMon)
		{
			#region Init Properties

			this.MaMon = maMon;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private MonHocBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public MonHocBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the MaMon property
		private System.String _maMon;
		
		/// <summary>
		/// Gets or sets the MaMon property.
		/// </summary>
		public System.String MaMon
		{
			get { return _maMon; }
			set
			{
				if ( this.Entity != null )
					this.Entity.MaMon = value;
				
				_maMon = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				MaMon = ( values["MaMon"] != null ) ? (System.String) EntityUtil.ChangeType(values["MaMon"], typeof(System.String)) : string.Empty;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("MaMon", MaMon);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("MaMon: {0}{1}",
								MaMon,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region MonHocColumn Enum
	
	/// <summary>
	/// Enumerate the MonHoc columns.
	/// </summary>
	[Serializable]
	public enum MonHocColumn : int
	{
		/// <summary>
		/// MaMon : 
		/// </summary>
		[EnumTextValue("MaMon")]
		[ColumnEnum("MaMon", typeof(System.String), System.Data.DbType.StringFixedLength, true, false, false, 10)]
		MaMon = 1,
		/// <summary>
		/// TenMon : 
		/// </summary>
		[EnumTextValue("TenMon")]
		[ColumnEnum("TenMon", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		TenMon = 2
	}//End enum

	#endregion MonHocColumn Enum

} // end namespace