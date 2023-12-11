using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientContext _Db;
        public ClientController(ClientContext Db)
        {
            _Db = Db;
        }

        public IActionResult ClientList()
        {
            try
            {
                //var stdList = _Db.tbl_Student.ToList();

                var stdList = from a in _Db.tbl_Student1



                              select new Client
                              {
                                  ID = a.ID,
                                  Firstname = a.Firstname,
                                  Lastname = a.Lastname,
                                  Phone_Number = a.Phone_Number,
                                  Email = a.Email,
                                  Country_code = a.Country_code,
                                  Gender = a.Gender,
                                  Balance = a.Balance
                              };


                return View(stdList);
            }
            catch (Exception)
            {
                return View();
            }
        }



        public IActionResult Create(Client obj)
        {
            loadDDL();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        object value = _Db.tbl_Student1.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("ClientList");
                }

                return View(obj);
            }
            catch (Exception)
            {

                return RedirectToAction("ClientList");
            }
        }



        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.tbl_Student1.FindAsync(id);
                if (std != null)
                {
                    _Db.tbl_Student1.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("ClientList");
            }
            catch (Exception)
            {

                return RedirectToAction("ClientListt");
            }
        }



        private void loadDDL()
        {
            try
            {
                List<Departments> depList = new List<Departments>();
                depList = _Db.tbl_Departments.ToList();

                depList.Insert(0, new Departments { ID = 0, Department = "Please Select" });

                ViewBag.DepList = depList;

            }
            catch (Exception)
            {


            }
        }
    }

    public class Customer1
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        // Add other properties as needed
    }
}