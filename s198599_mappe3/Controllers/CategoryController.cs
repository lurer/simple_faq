using s198599_mappe3.Models.Domain;
using s198599_mappe3.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace s198599_mappe3.Controllers
{
    public class CategoryController : ApiController
    {

        IFaqDb<Category> db = new CategoryRepo();


        public HttpResponseMessage Get()
        {
            var liste = db.getList();
            var Json = new JavaScriptSerializer();

            string JsonString = Json.Serialize(liste);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }


        //PUT api/Category/
        public HttpResponseMessage Put([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                bool OK = db.edit(category);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke endre Category i DB")
            };
        }
    }


    
}