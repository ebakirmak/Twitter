//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFTwitter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tweets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tweets()
        {
            this.MyFavorites = new HashSet<MyFavorites>();
        }
    
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Tweet { get; set; }
        public int FavoritesCount { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyFavorites> MyFavorites { get; set; }
        public virtual Users Users { get; set; }
    }
}
