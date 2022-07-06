﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPProject
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MyArtDataBase")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertDERIVE_PRODUCT(DERIVE_PRODUCT instance);
    partial void UpdateDERIVE_PRODUCT(DERIVE_PRODUCT instance);
    partial void DeleteDERIVE_PRODUCT(DERIVE_PRODUCT instance);
    partial void InsertPRODUCT_TYPE(PRODUCT_TYPE instance);
    partial void UpdatePRODUCT_TYPE(PRODUCT_TYPE instance);
    partial void DeletePRODUCT_TYPE(PRODUCT_TYPE instance);
    partial void InsertORIGINAL_PRODUCT(ORIGINAL_PRODUCT instance);
    partial void UpdateORIGINAL_PRODUCT(ORIGINAL_PRODUCT instance);
    partial void DeleteORIGINAL_PRODUCT(ORIGINAL_PRODUCT instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MyArtDataBaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DERIVE_PRODUCT> DERIVE_PRODUCT
		{
			get
			{
				return this.GetTable<DERIVE_PRODUCT>();
			}
		}
		
		public System.Data.Linq.Table<PRODUCT_TYPE> PRODUCT_TYPE
		{
			get
			{
				return this.GetTable<PRODUCT_TYPE>();
			}
		}
		
		public System.Data.Linq.Table<ORIGINAL_PRODUCT> ORIGINAL_PRODUCT
		{
			get
			{
				return this.GetTable<ORIGINAL_PRODUCT>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DERIVE_PRODUCT")]
	public partial class DERIVE_PRODUCT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _Id_Product_Type;
		
		private System.Nullable<int> _Id_Original_Product;
		
		private string _Name;
		
		private System.Nullable<double> _Price;
		
		private System.Nullable<int> _Quantity;
		
		private System.Data.Linq.Binary _Image;
		
		private EntityRef<PRODUCT_TYPE> _PRODUCT_TYPE;
		
		private EntityRef<ORIGINAL_PRODUCT> _ORIGINAL_PRODUCT;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnId_Product_TypeChanging(System.Nullable<int> value);
    partial void OnId_Product_TypeChanged();
    partial void OnId_Original_ProductChanging(System.Nullable<int> value);
    partial void OnId_Original_ProductChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPriceChanging(System.Nullable<double> value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(System.Nullable<int> value);
    partial void OnQuantityChanged();
    partial void OnImageChanging(System.Data.Linq.Binary value);
    partial void OnImageChanged();
    #endregion
		
		public DERIVE_PRODUCT()
		{
			this._PRODUCT_TYPE = default(EntityRef<PRODUCT_TYPE>);
			this._ORIGINAL_PRODUCT = default(EntityRef<ORIGINAL_PRODUCT>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Product_Type", DbType="Int")]
		public System.Nullable<int> Id_Product_Type
		{
			get
			{
				return this._Id_Product_Type;
			}
			set
			{
				if ((this._Id_Product_Type != value))
				{
					if (this._PRODUCT_TYPE.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_Product_TypeChanging(value);
					this.SendPropertyChanging();
					this._Id_Product_Type = value;
					this.SendPropertyChanged("Id_Product_Type");
					this.OnId_Product_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Original_Product", DbType="Int")]
		public System.Nullable<int> Id_Original_Product
		{
			get
			{
				return this._Id_Original_Product;
			}
			set
			{
				if ((this._Id_Original_Product != value))
				{
					if (this._ORIGINAL_PRODUCT.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_Original_ProductChanging(value);
					this.SendPropertyChanging();
					this._Id_Original_Product = value;
					this.SendPropertyChanged("Id_Original_Product");
					this.OnId_Original_ProductChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float")]
		public System.Nullable<double> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PRODUCT_TYPE_DERIVE_PRODUCT", Storage="_PRODUCT_TYPE", ThisKey="Id_Product_Type", OtherKey="Id", IsForeignKey=true)]
		public PRODUCT_TYPE PRODUCT_TYPE
		{
			get
			{
				return this._PRODUCT_TYPE.Entity;
			}
			set
			{
				PRODUCT_TYPE previousValue = this._PRODUCT_TYPE.Entity;
				if (((previousValue != value) 
							|| (this._PRODUCT_TYPE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PRODUCT_TYPE.Entity = null;
						previousValue.DERIVE_PRODUCT.Remove(this);
					}
					this._PRODUCT_TYPE.Entity = value;
					if ((value != null))
					{
						value.DERIVE_PRODUCT.Add(this);
						this._Id_Product_Type = value.Id;
					}
					else
					{
						this._Id_Product_Type = default(Nullable<int>);
					}
					this.SendPropertyChanged("PRODUCT_TYPE");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ORIGINAL_PRODUCT_DERIVE_PRODUCT", Storage="_ORIGINAL_PRODUCT", ThisKey="Id_Original_Product", OtherKey="Id", IsForeignKey=true)]
		public ORIGINAL_PRODUCT ORIGINAL_PRODUCT
		{
			get
			{
				return this._ORIGINAL_PRODUCT.Entity;
			}
			set
			{
				ORIGINAL_PRODUCT previousValue = this._ORIGINAL_PRODUCT.Entity;
				if (((previousValue != value) 
							|| (this._ORIGINAL_PRODUCT.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ORIGINAL_PRODUCT.Entity = null;
						previousValue.DERIVE_PRODUCT.Remove(this);
					}
					this._ORIGINAL_PRODUCT.Entity = value;
					if ((value != null))
					{
						value.DERIVE_PRODUCT.Add(this);
						this._Id_Original_Product = value.Id;
					}
					else
					{
						this._Id_Original_Product = default(Nullable<int>);
					}
					this.SendPropertyChanged("ORIGINAL_PRODUCT");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PRODUCT_TYPE")]
	public partial class PRODUCT_TYPE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<DERIVE_PRODUCT> _DERIVE_PRODUCT;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public PRODUCT_TYPE()
		{
			this._DERIVE_PRODUCT = new EntitySet<DERIVE_PRODUCT>(new Action<DERIVE_PRODUCT>(this.attach_DERIVE_PRODUCT), new Action<DERIVE_PRODUCT>(this.detach_DERIVE_PRODUCT));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PRODUCT_TYPE_DERIVE_PRODUCT", Storage="_DERIVE_PRODUCT", ThisKey="Id", OtherKey="Id_Product_Type")]
		public EntitySet<DERIVE_PRODUCT> DERIVE_PRODUCT
		{
			get
			{
				return this._DERIVE_PRODUCT;
			}
			set
			{
				this._DERIVE_PRODUCT.Assign(value);
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
		
		private void attach_DERIVE_PRODUCT(DERIVE_PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.PRODUCT_TYPE = this;
		}
		
		private void detach_DERIVE_PRODUCT(DERIVE_PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.PRODUCT_TYPE = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ORIGINAL_PRODUCT")]
	public partial class ORIGINAL_PRODUCT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private System.Nullable<double> _Price;
		
		private string _Description;
		
		private System.Data.Linq.Binary _image;
		
		private System.Nullable<int> _statut;
		
		private EntitySet<DERIVE_PRODUCT> _DERIVE_PRODUCT;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPriceChanging(System.Nullable<double> value);
    partial void OnPriceChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnimageChanging(System.Data.Linq.Binary value);
    partial void OnimageChanged();
    partial void OnstatutChanging(System.Nullable<int> value);
    partial void OnstatutChanged();
    #endregion
		
		public ORIGINAL_PRODUCT()
		{
			this._DERIVE_PRODUCT = new EntitySet<DERIVE_PRODUCT>(new Action<DERIVE_PRODUCT>(this.attach_DERIVE_PRODUCT), new Action<DERIVE_PRODUCT>(this.detach_DERIVE_PRODUCT));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float")]
		public System.Nullable<double> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NChar(3000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statut", DbType="Int")]
		public System.Nullable<int> statut
		{
			get
			{
				return this._statut;
			}
			set
			{
				if ((this._statut != value))
				{
					this.OnstatutChanging(value);
					this.SendPropertyChanging();
					this._statut = value;
					this.SendPropertyChanged("statut");
					this.OnstatutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ORIGINAL_PRODUCT_DERIVE_PRODUCT", Storage="_DERIVE_PRODUCT", ThisKey="Id", OtherKey="Id_Original_Product")]
		public EntitySet<DERIVE_PRODUCT> DERIVE_PRODUCT
		{
			get
			{
				return this._DERIVE_PRODUCT;
			}
			set
			{
				this._DERIVE_PRODUCT.Assign(value);
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
		
		private void attach_DERIVE_PRODUCT(DERIVE_PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.ORIGINAL_PRODUCT = this;
		}
		
		private void detach_DERIVE_PRODUCT(DERIVE_PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.ORIGINAL_PRODUCT = null;
		}
	}
}
#pragma warning restore 1591