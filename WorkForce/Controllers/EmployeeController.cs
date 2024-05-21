using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using WorkForce.Models;

namespace WorkForce.Controllers
{
    public class EmployeeController : Controller
    {
        private const string BaseApi = "http://localhost:7075";

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
               httpClient.BaseAddress = new System.Uri( "https://localhost:7075/");
               httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("api/employees");

                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response and deserialize it into a list of employees
                    var content = await response.Content.ReadAsStringAsync();
                    var employees = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);
                    return View(employees);
                }
                    return View();
            }
        }

        // GET: Employee/Details/id
        public async Task<ActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("https://localhost:7075/");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("api/employees/"+id);

                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response and deserialize it into a list of employees
                    var content = await response.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<Employee>(content);
                    return View(employee);
                }
                return View();
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}