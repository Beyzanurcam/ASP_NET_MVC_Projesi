//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STAJORNEKCALISMA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_HATSATIS
    {
        public int ID { get; set; }
        public Nullable<System.Guid> SIFRELIID { get; set; }
        public Nullable<System.DateTime> SATISTARIH { get; set; }
        public int HATSATISKULLANICIID { get; set; }
        public int HATSATISHATID { get; set; }
        public Nullable<byte> HAT_DURUM { get; set; }
        public string KULLANICI_ADI_SOYADI { get; set; }
        public string HAT_NO { get; set; }
        public Nullable<byte> HATSATIS_DURUM { get; set; }
    }
}