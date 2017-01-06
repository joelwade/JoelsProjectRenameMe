namespace CartModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int cartId { get; set; }

        public int? userId { get; set; }

        public int? giftBoxId { get; set; }

        public int? quantity { get; set; }
    }
}
