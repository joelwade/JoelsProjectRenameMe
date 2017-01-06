using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartModel;

namespace JoelsProjectRenameMe.Repository
{
    public class MockCart : ICartRepo
    {
        IEnumerable<Cart> cart;
        public MockCart()
        {
            cart = CreateCart();
        }

        public IEnumerable<Cart> CreateCart()
        {
            List<Cart> list = new List<Cart>();
            list.Add(new Cart
            {
                cartId = 1,
                userId = 1,
                giftBoxId = 5,
                quantity = 3
            });

            list.Add(new Cart
            {
                cartId = 2,
                userId = 1,
                giftBoxId = 3,
                quantity = 1
            });

            list.Add(new Cart
            {
                cartId = 3,
                userId = 2,
                giftBoxId = 1,
                quantity = 2
            });

            list.Add(new Cart
            {
                cartId = 4,
                userId = 3,
                giftBoxId = 3,
                quantity = 3
            });

            return list;
        }
        
        public bool Delete(int cartId)
        {
            IEnumerable<CartModel.Cart> carts = cart.Where(b => b.cartId == cartId);

            List<Cart> db = cart.ToList();
            foreach (CartModel.Cart c in carts)
            {
                db.Remove(c);
            }
            cart = db.AsEnumerable();

            return true;
        }

        public IEnumerable<Cart> Get(int? userId)
        {
            if (userId != null)
            {
                return cart.Where(b => b.userId == userId);
            } else
            {
                return cart;
            }
        }

        public bool Post(int userId, int giftBoxId, int? quantity)
        {
            List<Cart> tempCart = (List<Cart>) cart;
            tempCart.Add(new Cart
            {
                userId = userId,
                giftBoxId = giftBoxId,
                quantity = quantity
            });
            cart = tempCart.AsEnumerable();

            return true;
        }

        public bool Put(int userId, int giftBoxId, int quantity)
        {
            Cart c = cart.Where(b => b.userId == userId & b.giftBoxId == giftBoxId & b.quantity == quantity).FirstOrDefault();

            return true;
        }
    }
}