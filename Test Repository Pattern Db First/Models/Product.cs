//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_Repository_Pattern_Db_First.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }

        public static explicit operator Product(List<IGrouping<int, Product>> v)
        {
            throw new NotImplementedException();
        }
    }
}
