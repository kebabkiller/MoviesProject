//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movies
{
    using System;
    using System.Collections.Generic;
    
    public partial class movie_relation
    {
        public movie_relation()
        {
            this.users_vote = new HashSet<users_vote>();
        }
    
        public int id { get; set; }
        public int movie_1_id { get; set; }
        public int movie_2_id { get; set; }
    
        public virtual movie movie { get; set; }
        public virtual movie movie1 { get; set; }
        public virtual ICollection<users_vote> users_vote { get; set; }
    }
}
