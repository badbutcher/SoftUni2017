namespace ProductsShop.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int Id { get; set; }

        public User()
        {
            this.MyFriends = new HashSet<User>();
            this.FriendsWithMe = new HashSet<User>();
            this.ProductsBought = new HashSet<Product>();
            this.ProductsSold = new HashSet<Product>();
        }

        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> MyFriends { get; set; }

        public virtual ICollection<User> FriendsWithMe { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSold { get; set; }
    }
}
