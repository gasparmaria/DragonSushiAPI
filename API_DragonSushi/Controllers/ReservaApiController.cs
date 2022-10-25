﻿using API_DragonSushi.Metodos;
using API_DragonSushi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DragonSushi.Controllers
{
    public class ReservaApiController : ApiController
    {
        [HttpPost]
        public void Post([FromBody] ReservaViewModel vmReserva)
        {
            if (vmReserva == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            ReservaDAO dao = new ReservaDAO();
            dao.cadastrarReserva(vmReserva);
        }
    }
}
