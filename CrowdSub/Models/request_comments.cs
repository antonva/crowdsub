//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrowdSub.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class request_comments
    {
        public int id { get; set; }
        public int rc_request_id { get; set; }
        public int rc_user_id { get; set; }
        public string rc_comment { get; set; }
    
        public virtual request request { get; set; }
        public virtual user user { get; set; }
    }
}