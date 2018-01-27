using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zebra.Services;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.Models.PandaModels;

namespace Zebra.Web.Controllers
{
    [RoutePrefix("panda/api")]
    public class PandaController : ApiController
    {
        private readonly IPandaService _pandaService;
        public PandaController(IPandaService pandaService)
        {
            _pandaService = pandaService;
        }


        [HttpPost]
        [Route("Product/GetProductDetails")]
        public HttpResponseMessage GetProductDetails(List<int> ids)
        {
            try
            {
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
        [HttpPost]
        [Route("panda/GetShopInfo")]
        public HttpResponseMessage GetShopInfo()
        {
            try
            {
                var productsId = _pandaService.GetShop();
                return Request.CreateResponse(HttpStatusCode.OK, JsonResponse.CreateResponse<List<PandaShopInfo>>(productsId));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonResponse.CreateResponse<Exception>(exc));
            }


        }
        [HttpPost]
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
    }
}