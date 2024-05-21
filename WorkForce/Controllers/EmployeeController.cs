using Newtonsoft.Json;
using System;
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
        private const string BaseApi = "https://localhost:7075/";

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri(BaseApi);
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
                var response = await httpClient.GetAsync("api/employees/" + id);

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
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(BaseApi);
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Serialize the employee object to JSON
                    var jsonContent = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    // Send the POST request
                    var response = await httpClient.PostAsync("api/employees/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Extract the response content (the newly created employee)
                        var responseData = await response.Content.ReadAsStringAsync();
                        var createdEmployee = JsonConvert.DeserializeObject<Employee>(responseData);

                        // Redirect to the Index action or another suitable action
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle the error response here if needed
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return the view with error message
                ModelState.AddModelError(string.Empty, $"Exception: {ex.Message}");
            }

            // If we got this far, something failed, re-display form
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("https://localhost:7075/");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("api/employees/" + id);

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

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(BaseApi);
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonContent = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync($"api/employees/{employee.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
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