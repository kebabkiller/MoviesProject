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
    
    public partial class image_movie
    {
        public image_movie()
        {
            this.image_relation = new HashSet<image_relation>();
        }
    
        public int movie_id { get; set; }
        public bool is_poster { get; set; }
        public string source { get; set; }
        public System.Guid id { get; set; }
    
        public virtual movie movie { get; set; }
        public virtual ICollection<image_relation> image_relation { get; set; }
    }
}