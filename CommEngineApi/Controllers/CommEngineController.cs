using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommEngineApi.Models;

namespace CommEngineApi.Controllers
{
    public class CommEngineController : ApiController
    {
        private CommEngineModel _context;

        public CommEngineController()
        {
            _context = new CommEngineModel();
        }

        ////// GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetProduct(int id)
        {
            var product = _context.Product.FirstOrDefault(d => d.Id == id);
            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product was not found");
        }

        ////// GET api/<controller>
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            var products = _context.Product.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        
        public HttpResponseMessage GetCategories()
        {
            var categories = _context.Categories.OrderBy(d => d.CategoryName).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        ////// POST api/<controller>
        public HttpResponseMessage PostProduct([FromBody]Product model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                _context.Product.Add(model);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, ex.Message);
            }
            
        }

        ////// PUT api/<controller>/5
        public HttpResponseMessage PutProduct(int id, [FromBody]Product model)
        {
            var updateModel = _context.Product.FirstOrDefault(d => d.Id == id);
            if (updateModel != null)
            {
                updateModel.CategoryId = model.CategoryId;
                updateModel.ImageUrl = model.ImageUrl;
                updateModel.Title = model.Title;
                updateModel.Price = model.Price;
                _context.Product.AddOrUpdate(updateModel);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, updateModel);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product was not found");
        }

        ////// DELETE api/<controller>/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            var delModel = _context.Product.FirstOrDefault(d => d.Id == id);
            if (delModel != null)
            {
                _context.Product.Remove(delModel);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product was not found.");
        }
    }
}