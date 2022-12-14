using API_DragonSushi.Metodos;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class DeliveryApiController : ApiController
    {
        [HttpPost]
        public void Post([FromBody] DeliveryViewModel vmDelivery)
        {
            if (vmDelivery == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            DAO dao = new DAO();
            dao.cadastrarDelivery(vmDelivery);
        }
    }
}
