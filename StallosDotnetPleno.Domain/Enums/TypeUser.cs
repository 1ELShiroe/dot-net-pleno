using System.ComponentModel;
using System.Runtime.Serialization;

namespace StallosDotnetPleno.Domain.Enums
{
    public enum TypeUser
    {
        [EnumMember(Value = "Pessoa Física")]
        [Description("Pessoa Física")]
        PF,

        [EnumMember(Value = "Pessoa Jurídica")]
        [Description("Pessoa Jurídica")]
        PJ,
    }
}