﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4971
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 6/4/2012 4:32:41 PM
namespace ATB.Data
{
    
    /// <summary>
    /// There are no comments for atbEntities in the schema.
    /// </summary>
    public partial class atbEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new atbEntities object using the connection string found in the 'atbEntities' section of the application configuration file.
        /// </summary>
        public atbEntities() : 
                base("name=atbEntities", "atbEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new atbEntities object.
        /// </summary>
        public atbEntities(string connectionString) : 
                base(connectionString, "atbEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new atbEntities object.
        /// </summary>
        public atbEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "atbEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for units in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<units> units
        {
            get
            {
                if ((this._units == null))
                {
                    this._units = base.CreateQuery<units>("[units]");
                }
                return this._units;
            }
        }
        private global::System.Data.Objects.ObjectQuery<units> _units;
        /// <summary>
        /// There are no comments for units in the schema.
        /// </summary>
        public void AddTounits(units units)
        {
            base.AddObject("units", units);
        }
    }
    /// <summary>
    /// There are no comments for atbModel.units in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="atbModel", Name="units")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class units : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new units object.
        /// </summary>
        /// <param name="id">Initial value of id.</param>
        public static units Createunits(long id)
        {
            units units = new units();
            units.id = id;
            return units;
        }
        /// <summary>
        /// There are no comments for Property id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this.ReportPropertyChanging("id");
                this._id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("id");
                this.OnidChanged();
            }
        }
        private long _id;
        partial void OnidChanging(long value);
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for Property name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.OnnameChanging(value);
                this.ReportPropertyChanging("name");
                this._name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("name");
                this.OnnameChanged();
            }
        }
        private string _name;
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        /// <summary>
        /// There are no comments for Property attack in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> attack
        {
            get
            {
                return this._attack;
            }
            set
            {
                this.OnattackChanging(value);
                this.ReportPropertyChanging("attack");
                this._attack = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("attack");
                this.OnattackChanged();
            }
        }
        private global::System.Nullable<long> _attack;
        partial void OnattackChanging(global::System.Nullable<long> value);
        partial void OnattackChanged();
        /// <summary>
        /// There are no comments for Property defense in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> defense
        {
            get
            {
                return this._defense;
            }
            set
            {
                this.OndefenseChanging(value);
                this.ReportPropertyChanging("defense");
                this._defense = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("defense");
                this.OndefenseChanged();
            }
        }
        private global::System.Nullable<long> _defense;
        partial void OndefenseChanging(global::System.Nullable<long> value);
        partial void OndefenseChanged();
        /// <summary>
        /// There are no comments for Property damage_min in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> damage_min
        {
            get
            {
                return this._damage_min;
            }
            set
            {
                this.Ondamage_minChanging(value);
                this.ReportPropertyChanging("damage_min");
                this._damage_min = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("damage_min");
                this.Ondamage_minChanged();
            }
        }
        private global::System.Nullable<long> _damage_min;
        partial void Ondamage_minChanging(global::System.Nullable<long> value);
        partial void Ondamage_minChanged();
        /// <summary>
        /// There are no comments for Property damage_max in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> damage_max
        {
            get
            {
                return this._damage_max;
            }
            set
            {
                this.Ondamage_maxChanging(value);
                this.ReportPropertyChanging("damage_max");
                this._damage_max = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("damage_max");
                this.Ondamage_maxChanged();
            }
        }
        private global::System.Nullable<long> _damage_max;
        partial void Ondamage_maxChanging(global::System.Nullable<long> value);
        partial void Ondamage_maxChanged();
        /// <summary>
        /// There are no comments for Property hit_points in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> hit_points
        {
            get
            {
                return this._hit_points;
            }
            set
            {
                this.Onhit_pointsChanging(value);
                this.ReportPropertyChanging("hit_points");
                this._hit_points = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("hit_points");
                this.Onhit_pointsChanged();
            }
        }
        private global::System.Nullable<long> _hit_points;
        partial void Onhit_pointsChanging(global::System.Nullable<long> value);
        partial void Onhit_pointsChanged();
        /// <summary>
        /// There are no comments for Property speed in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> speed
        {
            get
            {
                return this._speed;
            }
            set
            {
                this.OnspeedChanging(value);
                this.ReportPropertyChanging("speed");
                this._speed = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("speed");
                this.OnspeedChanged();
            }
        }
        private global::System.Nullable<long> _speed;
        partial void OnspeedChanging(global::System.Nullable<long> value);
        partial void OnspeedChanged();
        /// <summary>
        /// There are no comments for Property initiative in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<decimal> initiative
        {
            get
            {
                return this._initiative;
            }
            set
            {
                this.OninitiativeChanging(value);
                this.ReportPropertyChanging("initiative");
                this._initiative = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("initiative");
                this.OninitiativeChanged();
            }
        }
        private global::System.Nullable<decimal> _initiative;
        partial void OninitiativeChanging(global::System.Nullable<decimal> value);
        partial void OninitiativeChanged();
        /// <summary>
        /// There are no comments for Property mana in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> mana
        {
            get
            {
                return this._mana;
            }
            set
            {
                this.OnmanaChanging(value);
                this.ReportPropertyChanging("mana");
                this._mana = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("mana");
                this.OnmanaChanged();
            }
        }
        private global::System.Nullable<long> _mana;
        partial void OnmanaChanging(global::System.Nullable<long> value);
        partial void OnmanaChanged();
        /// <summary>
        /// There are no comments for Property morale in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> morale
        {
            get
            {
                return this._morale;
            }
            set
            {
                this.OnmoraleChanging(value);
                this.ReportPropertyChanging("morale");
                this._morale = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("morale");
                this.OnmoraleChanged();
            }
        }
        private global::System.Nullable<long> _morale;
        partial void OnmoraleChanging(global::System.Nullable<long> value);
        partial void OnmoraleChanged();
        /// <summary>
        /// There are no comments for Property shots in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> shots
        {
            get
            {
                return this._shots;
            }
            set
            {
                this.OnshotsChanging(value);
                this.ReportPropertyChanging("shots");
                this._shots = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("shots");
                this.OnshotsChanged();
            }
        }
        private global::System.Nullable<long> _shots;
        partial void OnshotsChanging(global::System.Nullable<long> value);
        partial void OnshotsChanged();
        /// <summary>
        /// There are no comments for Property range in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> range
        {
            get
            {
                return this._range;
            }
            set
            {
                this.OnrangeChanging(value);
                this.ReportPropertyChanging("range");
                this._range = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("range");
                this.OnrangeChanged();
            }
        }
        private global::System.Nullable<long> _range;
        partial void OnrangeChanging(global::System.Nullable<long> value);
        partial void OnrangeChanged();
    }
}
