using Book_UI.Models;
using DAL;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Book_UI.Controllers
{
    public class BookController : Controller
    {
      
        private ReadRackDbContext _context { get; set; }
        string apiUrl = string.Empty;
       
        public BookController()
        {
            apiUrl = ConfigurationManager.AppSettings["apiUrl"]?.ToString();
            _context = new ReadRackDbContext();
        }

        public ActionResult Index()
        {
            List<Book> books = new List<Book>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            HttpResponseMessage response =
                client.GetAsync("book").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseContent =
                    response.Content.ReadAsStringAsync().Result; // json content
                // deserialize
                books = JsonConvert.
                    DeserializeObject<List<Book>>(responseContent);
            }
            else
            {
                ViewBag.Message = "Categories not available";
            }


            return View(books);
        }


    }
}