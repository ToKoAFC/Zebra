using System.Runtime.Serialization;

namespace Zebra.Global
{
    [DataContract]
    public enum MimeEnum
    {
        [EnumMember]
        Other = 0,
        [EnumMember]
        Pdf = 1,
        [EnumMember]
        Word = 2,
        [EnumMember]
        Txt = 3,
        [EnumMember]
        Odt = 4,
        [EnumMember]
        Image = 5
    }
}
