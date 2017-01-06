using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoelsProjectRenameMe.Repository
{
    public interface ICartRepo
    {
        IEnumerable<CartModel.Cart> Get(int? id);
        bool Put(int userId, int giftBoxId, int quantity);
        bool Post(int userId, int giftBoxId, int? quantity);
        bool Delete(int cartId);
    }
}