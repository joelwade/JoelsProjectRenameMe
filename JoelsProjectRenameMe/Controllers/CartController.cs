using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CartModel;

namespace JoelsProjectRenameMe.Controllers
{
    public class CartController : ApiController
    {
        private readonly Repository.ICartRepo repo;

        public CartController(Repository.ICartRepo repo)
        {
            this.repo = repo;
        }
        
        public IEnumerable<Cart> Get(int? id = null)
        {
            return repo.Get(id);
        }

        public HttpResponseMessage Delete(int cartId)
        {
            bool result = repo.Delete(cartId);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

        //When resource is unknown
        public HttpResponseMessage Post(int userId, int giftBoxId, int quantity)
        {
            bool result = repo.Post(userId, giftBoxId, quantity);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

        //When resource is known
        public HttpResponseMessage Put(int userId, int giftBoxId, int quantity)
        {
            bool result = repo.Put(userId, giftBoxId, quantity);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}