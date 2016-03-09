#region License
// Copyright (c) 2016 Serge Rozentsvet
//
// This code is licensed on the same terms as the rest of Newtonsoft.Json project.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Serialization
{
    /// <summary>
    /// An implementation of DataContractAttribute, which is compatible with System.Runtime.Serialization.DataContractAttribute.
    /// Microsft SQL Server supports loading CLR Integration libraries that use only a limited subset of the .NET framework (https://msdn.microsoft.com/en-us/library/ms403279%28v=sql.110%29.aspx).
    /// The list of supported libraries does not include the System.Runtime.Serialization library.
    /// An implementation of the DataContractAttribute class here means that the System.Runtime.Serialization reference / dependency can be removed from the project.
    /// This implementation is inspired by Microsoft's reference implementation at https://github.com/Microsoft/referencesource/blob/master/System.Runtime.Serialization/System/Runtime/Serialization/DataContractAttribute.cs (Dot Net 4.6.1).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    public sealed class DataContractAttribute : Attribute
    {
        private string name;
        private string ns;
        private bool isReference;

        public DataContractAttribute()
        {
        }

        public bool IsReference
        {
            get { return isReference; }
            set { isReference = value; }
        }

        public string Namespace
        {
            get { return ns; }
            set { ns = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

#if !NODEPEND_DOTNETSERIALIZATION
        /// <summary>
        /// Method the implicitly converts the DataContractAttribute from System.Runtime.Serialization namespace.
        /// </summary>
        /// <param name="attribute"></param>
        public static implicit operator DataContractAttribute(System.Runtime.Serialization.DataContractAttribute attribute)
        {
            return new DataContractAttribute()
            {
                IsReference = attribute.IsReference,
                Namespace = attribute.Namespace,
                Name = attribute.Name
            };
        }
#endif
    }



    /// <summary>
    /// An implementation of DataMemberAttribute, which is compatible with System.Runtime.Serialization.DataMemberAttribute.
    /// Microsft SQL Server supports loading CLR Integration libraries that use only a limited subset of the .NET framework (https://msdn.microsoft.com/en-us/library/ms403279%28v=sql.110%29.aspx).
    /// The list of supported libraries does not include the System.Runtime.Serialization library.
    /// An implementation of the DataMemberAttribute class here means that the System.Runtime.Serialization reference / dependency can be removed from the project.
    /// This implementation is inspired by Microsoft's reference implementation at https://github.com/Microsoft/referencesource/blob/master/System.Runtime.Serialization/System/Runtime/Serialization/DataMemberAttribute.cs (Dot Net 4.6.1).
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DataMemberAttribute : Attribute
    {
        private string name;
        private int order = -1;
        private bool isRequired;
        private bool emitDefaultValue = true;

        public DataMemberAttribute()
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }
        public int Order
        {
            get { return order; }
            set
            {
                if (value < 0)
                    throw new Exception("Property 'Order' in DataMemberAttribute attribute cannot be a negative number.");
                order = value;
            }
        }

        public bool EmitDefaultValue
        {
            get { return emitDefaultValue; }
            set { emitDefaultValue = value; }
        }

#if !NODEPEND_DOTNETSERIALIZATION
        /// <summary>
        /// Method the implicitly converts the DataMemberAttribute from System.Runtime.Serialization namespace.
        /// </summary>
        /// <param name="attribute"></param>
        public static implicit operator DataMemberAttribute(System.Runtime.Serialization.DataMemberAttribute attribute)
        {
            return new DataMemberAttribute()
            {
                Name = attribute.Name,
                IsRequired = attribute.IsRequired,
                EmitDefaultValue = attribute.EmitDefaultValue
            };
        }
#endif
    }



    /// <summary>
    /// An implementation of IgnoreDataMemberAttribute, which is compatible with System.Runtime.Serialization.IgnoreDataMemberAttribute.
    /// Microsft SQL Server supports loading CLR Integration libraries that use only a limited subset of the .NET framework (https://msdn.microsoft.com/en-us/library/ms403279%28v=sql.110%29.aspx).
    /// The list of supported libraries does not include the System.Runtime.Serialization library.
    /// An implementation of the IgnoreDataMemberAttribute class here means that the System.Runtime.Serialization reference / dependency can be removed from the project.
    /// This implementation is inspired by Microsoft's reference implementation at https://github.com/Microsoft/referencesource/blob/master/System.Runtime.Serialization/System/Runtime/Serialization/IgnoreDataMemberAttribute.cs (Dot Net 4.6.1).
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreDataMemberAttribute : Attribute
    {
        public IgnoreDataMemberAttribute()
        {
        }

#if !NODEPEND_DOTNETSERIALIZATION
        /// <summary>
        /// Method the implicitly converts the IgnoreDataMemberAttribute from System.Runtime.Serialization namespace.
        /// </summary>
        /// <param name="attribute"></param>
        public static implicit operator IgnoreDataMemberAttribute(System.Runtime.Serialization.IgnoreDataMemberAttribute attribute)
        {
            return new IgnoreDataMemberAttribute();
        }
#endif
    }


    /// <summary>
    /// An implementation of EnumMemberAttribute, which is compatible with System.Runtime.Serialization.EnumMemberAttribute.
    /// Microsft SQL Server supports loading CLR Integration libraries that use only a limited subset of the .NET framework (https://msdn.microsoft.com/en-us/library/ms403279%28v=sql.110%29.aspx).
    /// The list of supported libraries does not include the System.Runtime.Serialization library.
    /// An implementation of the EnumMemberAttribute class here means that the System.Runtime.Serialization reference / dependency can be removed from the project.
    /// This implementation is inspired by Microsoft's reference implementation at https://github.com/Microsoft/referencesource/blob/master/System.Runtime.Serialization/System/Runtime/Serialization/EnumMemberAttribute.cs (Dot Net 4.6.1).
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class EnumMemberAttribute : Attribute
    {
        string value;
        bool isValueSetExplicitly;

        public EnumMemberAttribute()
        {
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; this.isValueSetExplicitly = true; }
        }

        public bool IsValueSetExplicitly
        {
            get { return this.isValueSetExplicitly; }
        }

#if !NODEPEND_DOTNETSERIALIZATION
        /// <summary>
        /// Method the implicitly converts the IgnoreDataMemberAttribute from System.Runtime.Serialization namespace.
        /// </summary>
        /// <param name="attribute"></param>
        public static implicit operator EnumMemberAttribute(System.Runtime.Serialization.EnumMemberAttribute attribute)
        {
            return new EnumMemberAttribute()
            {
                Value = attribute.Value,
                IsValueSetExplicitly = attribute.IsValueSetExplicitly
            };
        }
#endif
    }

}