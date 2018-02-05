using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Models.PandaModels;

namespace Zebra.Web.Controllers
{
    [RoutePrefix("panda/api")]
    public class PandaController : ApiController
    {
        private readonly IPandaService _pandaService;
        private readonly IDeliveryService _deliveryService;
        public PandaController(IPandaService pandaService, IDeliveryService deliveryService)
        {
            _pandaService = pandaService;
            _deliveryService = deliveryService;
        }

        [HttpPost]
        [Route("Product/GetProductDetails")]
        public HttpResponseMessage GetProductDetails([FromBody]List<int> ids)
        {
            try
            {
                ids.Add(1);ids.Add(2);
                var products = _pandaService.GetProductDetails(ids);
                return Request.CreateResponse(HttpStatusCode.OK, JsonResponse.CreateResponse<List<PandaProductDetails>>(products));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonResponse.CreateResponse<Exception>(exc));
            }
        }

        [HttpGet]
        [Route("Product/GetProductsIds")]
        public HttpResponseMessage GetProductsIds()
        {
            try
            {
                var productsId = _pandaService.GetProductsIds();
                return Request.CreateResponse(HttpStatusCode.OK, JsonResponse.CreateResponse<List<int>>(productsId));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonResponse.CreateResponse<Exception>(exc));
            }
        }

        [HttpGet]
        [Route("panda/GetShopInfo")]
        public HttpResponseMessage GetShopInfo()
        {
            try
            {
                var shopInfo = _pandaService.GetShopInfo();
                return Request.CreateResponse(HttpStatusCode.OK, JsonResponse.CreateResponse<PandaShopInfo>(shopInfo));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonResponse.CreateResponse<Exception>(exc));
            }
        }

        [HttpGet]
        [Route("panda/GetDeliveryInfo")]
        public HttpResponseMessage GetDeliveryInfo()
        {
            try
            {
                var deliveries = _deliveryService.GetDeliveries();
                return Request.CreateResponse(HttpStatusCode.OK, JsonResponse.CreateResponse<List<VMDelivery>>(deliveries));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonResponse.CreateResponse<Exception>(exc));
            }
        }
    }
}