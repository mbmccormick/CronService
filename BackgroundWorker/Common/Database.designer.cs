﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackgroundWorker.Common
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="cron")]
	public partial class DatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSchedule(Schedule instance);
    partial void UpdateSchedule(Schedule instance);
    partial void DeleteSchedule(Schedule instance);
    partial void InsertInformation(Information instance);
    partial void UpdateInformation(Information instance);
    partial void DeleteInformation(Information instance);
    #endregion
		
		public DatabaseDataContext() : 
				base(global::BackgroundWorker.Properties.Settings.Default.cronConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Schedule> Schedules
		{
			get
			{
				return this.GetTable<Schedule>();
			}
		}
		
		public System.Data.Linq.Table<Information> Informations
		{
			get
			{
				return this.GetTable<Information>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Schedules")]
	public partial class Schedule : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private string _Name;
		
		private string _Occurrence;
		
		private string _Endpoint;
		
		private bool _IsEnabled;
		
		private System.DateTime _CreatedDate;
		
		private System.DateTime _NextOccurrence;
		
		private EntitySet<Information> _Informations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnOccurrenceChanging(string value);
    partial void OnOccurrenceChanged();
    partial void OnEndpointChanging(string value);
    partial void OnEndpointChanged();
    partial void OnIsEnabledChanging(bool value);
    partial void OnIsEnabledChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnNextOccurrenceChanging(System.DateTime value);
    partial void OnNextOccurrenceChanged();
    #endregion
		
		public Schedule()
		{
			this._Informations = new EntitySet<Information>(new Action<Information>(this.attach_Informations), new Action<Information>(this.detach_Informations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Occurrence", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Occurrence
		{
			get
			{
				return this._Occurrence;
			}
			set
			{
				if ((this._Occurrence != value))
				{
					this.OnOccurrenceChanging(value);
					this.SendPropertyChanging();
					this._Occurrence = value;
					this.SendPropertyChanged("Occurrence");
					this.OnOccurrenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Endpoint", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Endpoint
		{
			get
			{
				return this._Endpoint;
			}
			set
			{
				if ((this._Endpoint != value))
				{
					this.OnEndpointChanging(value);
					this.SendPropertyChanging();
					this._Endpoint = value;
					this.SendPropertyChanged("Endpoint");
					this.OnEndpointChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsEnabled", DbType="Bit NOT NULL")]
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				if ((this._IsEnabled != value))
				{
					this.OnIsEnabledChanging(value);
					this.SendPropertyChanging();
					this._IsEnabled = value;
					this.SendPropertyChanged("IsEnabled");
					this.OnIsEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NextOccurrence", DbType="DateTime NOT NULL")]
		public System.DateTime NextOccurrence
		{
			get
			{
				return this._NextOccurrence;
			}
			set
			{
				if ((this._NextOccurrence != value))
				{
					this.OnNextOccurrenceChanging(value);
					this.SendPropertyChanging();
					this._NextOccurrence = value;
					this.SendPropertyChanged("NextOccurrence");
					this.OnNextOccurrenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Schedule_Information", Storage="_Informations", ThisKey="ID", OtherKey="ScheduleID")]
		public EntitySet<Information> Informations
		{
			get
			{
				return this._Informations;
			}
			set
			{
				this._Informations.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Informations(Information entity)
		{
			this.SendPropertyChanging();
			entity.Schedule = this;
		}
		
		private void detach_Informations(Information entity)
		{
			this.SendPropertyChanging();
			entity.Schedule = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Information")]
	public partial class Information : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private System.Guid _ScheduleID;
		
		private int _Result;
		
		private string _Message;
		
		private System.DateTime _CreatedDate;
		
		private EntityRef<Schedule> _Schedule;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnScheduleIDChanging(System.Guid value);
    partial void OnScheduleIDChanged();
    partial void OnResultChanging(int value);
    partial void OnResultChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    #endregion
		
		public Information()
		{
			this._Schedule = default(EntityRef<Schedule>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduleID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ScheduleID
		{
			get
			{
				return this._ScheduleID;
			}
			set
			{
				if ((this._ScheduleID != value))
				{
					if (this._Schedule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnScheduleIDChanging(value);
					this.SendPropertyChanging();
					this._ScheduleID = value;
					this.SendPropertyChanged("ScheduleID");
					this.OnScheduleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Result", DbType="Int NOT NULL")]
		public int Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				if ((this._Result != value))
				{
					this.OnResultChanging(value);
					this.SendPropertyChanging();
					this._Result = value;
					this.SendPropertyChanged("Result");
					this.OnResultChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Schedule_Information", Storage="_Schedule", ThisKey="ScheduleID", OtherKey="ID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Schedule Schedule
		{
			get
			{
				return this._Schedule.Entity;
			}
			set
			{
				Schedule previousValue = this._Schedule.Entity;
				if (((previousValue != value) 
							|| (this._Schedule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Schedule.Entity = null;
						previousValue.Informations.Remove(this);
					}
					this._Schedule.Entity = value;
					if ((value != null))
					{
						value.Informations.Add(this);
						this._ScheduleID = value.ID;
					}
					else
					{
						this._ScheduleID = default(System.Guid);
					}
					this.SendPropertyChanged("Schedule");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
