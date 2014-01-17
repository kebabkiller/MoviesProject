//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movies.Mappings
{
    using System;
    using System.Collections.Generic;
    
    public partial class person
    {
        public person()
        {
            this.casts = new HashSet<cast>();
            this.comments = new HashSet<comment>();
            this.images = new HashSet<image>();
            this.image_relation = new HashSet<image_relation>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string birth_place { get; set; }
    
        public virtual ICollection<cast> casts { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<image> images { get; set; }
        public virtual ICollection<image_relation> image_relation { get; set; }
    }
}
