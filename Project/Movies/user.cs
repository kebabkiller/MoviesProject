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
    
    public partial class user
    {
        public user()
        {
            this.comment = new HashSet<comment>();
            this.comment_answer = new HashSet<comment_answer>();
            this.users_vote = new HashSet<users_vote>();
        }
    
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<comment> comment { get; set; }
        public virtual ICollection<comment_answer> comment_answer { get; set; }
        public virtual ICollection<users_vote> users_vote { get; set; }
    }
}
