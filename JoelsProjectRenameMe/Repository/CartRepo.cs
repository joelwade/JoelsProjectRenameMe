using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartModel;
using System.Data.Entity;

namespace JoelsProjectRenameMe.Repository
{
    public class CartRepo : ICartRepo
    {
        private CartModel.ModelCart db = new CartModel.ModelCart();

        public IEnumerable<Cart> Get(int? id = null)
        {
            if (id == null)
            {
                return db.Carts;
            }
            else
            {
                return db.Carts.Where(x => x.userId == id);
            }
        }

        public bool Delete(int cartId)
        {
            IEnumerable<CartModel.Cart> carts = db.Carts.Where(b => b.cartId == cartId);
            foreach (CartModel.Cart c in carts)
            {
                db.Carts.Remove(c);
            }
            db.SaveChanges();

            return true;
        }

        //When resource is unknown
        public bool Post(int userId, int giftBoxId, int? quantity)
        {
            db.Carts.Add(new Cart
            {
                userId = userId,
                giftBoxId = giftBoxId,
                quantity = quantity
            });
            db.SaveChanges();

            return true;
        }

        //When resource is known
        public bool Put(int userId, int giftBoxId, int quantity)
        {
            CartModel.Cart c = db.Carts.Where(a => a.userId == userId & a.giftBoxId == giftBoxId).FirstOrDefault();
            if (quantity <= 0)
            {
                db.Carts.Remove(c);
                db.Entry(c).State = EntityState.Modified;
            }
            else
            {
                c.quantity = quantity;
                db.Entry(c).State = EntityState.Modified;
            }
            db.SaveChanges();

            return true;
        }
    }
}