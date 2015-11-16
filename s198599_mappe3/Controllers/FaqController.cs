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
    public class FaqController : ApiController
    {
        IFaqDb<Question> db = new QuestionRepo();

        //GET: api/Faq
        public HttpResponseMessage Get()
        {
            

            var liste = db.getList().Where(x => x.Answer != null);
            var Json = new JavaScriptSerializer();

            string JsonString = Json.Serialize(liste);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }


        //GET: api/Faq/5
        public HttpResponseMessage Get(int id)
        {
            Question q = db.get(id);
            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(q);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        //POST: /api/Faq
        public HttpResponseMessage Post([FromBody]Question question)
        {
            if (ModelState.IsValid)
            {

            
                bool Ok = db.save(question);

                if (Ok)
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
                Content = new StringContent("The question could not be saved")
            };
        }


        //PUT: /api/faq
        public HttpResponseMessage Put(int id, [FromBody]Question question)
        {
            if (ModelState.IsValid)
            {
                bool Ok = db.edit(question);
                if (Ok)
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
                Content = new StringContent("The question could not be edited")
            };
        }




        public HttpResponseMessage Delete(int id)
        {
            bool Ok = db.delete(id);
            if (!Ok)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("The question could not be deleted")
                };

            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

    }
}