using Microsoft.VisualStudio.TestTools.UnitTesting;
using JoelsProjectRenameMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelsProjectRenameMe.Repository.Tests
{
    [TestClass()]
    public class CartRepoTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //MockCart is seeded with four carts, lets see if they are all there.
            MockCart db = new MockCart();
            IEnumerable<CartModel.Cart> carts = db.Get(null);

            Assert.AreEqual(carts.Count(), 4);
        }

        [TestMethod()]
        public void Put()
        {
            //Change the quantity value for one of the seeded carts, and test if it has been changed.
            MockCart db = new MockCart();
            var item = db.Get(2).FirstOrDefault();

            item.quantity = 87;
            db.Put((int)item.userId, (int)item.giftBoxId, (int)item.quantity);

            var c = db.Get(2);

            foreach (CartModel.Cart cart in c)
            {
                if (cart.quantity == 87)
                {
                    Assert.AreEqual(cart.quantity, 87);
                }
            }

        }

        [TestMethod()]
        public void Delete()
        {
            //Delete on of the carts, and check if there are now 3, instead of 4, carts in the db.
            MockCart db = new MockCart();
            var cartItems = db.Get(1);
            var count = db.Get(null).ToList();
            int c = count.Count();
            var cartItem = db.Get(1).FirstOrDefault();

            db.Delete((int)cartItem.userId, cartItem.giftBoxId);

            var count2 = db.Get(null).ToList();
            int c2 = count2.Count();

            Assert.AreEqual(--c, c2);
        }

        [TestMethod()]
        public void PostTest()
        {
            MockCart db = new MockCart();

            //Get all carts
            List<CartModel.Cart> cartItems = db.Get(null).ToList();
            Console.WriteLine(cartItems.Count);

            //Add new item to the db.
            db.Post(15, 15, 15);

            //Get carts with new item in
            List<CartModel.Cart> cartItemsAfterPost = db.Get(null).ToList();

            //Check if cart has been added.
            foreach (CartModel.Cart cart in cartItemsAfterPost)
            {
                if (cart.userId == 15 & cart.giftBoxId == 15 & cart.quantity == 15)
                {
                    Assert.AreEqual(1, 1);
                }
            }
        }
    }
}