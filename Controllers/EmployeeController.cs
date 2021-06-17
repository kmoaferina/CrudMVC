using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;
using System.Data.Entity;

namespace CrudMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
            return View(DbModels.EmployeeTables.ToList());
 
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
            {
                return View(DbModels.EmployeeTables.Where(x => x.EmpID == id).FirstOrDefault());
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeTable employeeTable)
        {
            
                try
            {
                  using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
                    {
                        employeeTable.EmpEncryptedString = CryptorEngine.Encrypt(employeeTable.EmpContactNumber, true);     
                        DbModels.EmployeeTables.Add(employeeTable);
                        DbModels.SaveChanges();
                    }
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
            using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
            {
                return View(DbModels.EmployeeTables.Where(x => x.EmpID == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeTable employeeTable)
        {
            try
            {
                using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
                {
                    DbModels.Entry(employeeTable).State = EntityState.Modified;
                    DbModels.SaveChanges();
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
            using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
            {
                return View(DbModels.EmployeeTables.Where(x => x.EmpID == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                using (EmployeeDBEntities DbModels = new EmployeeDBEntities())
                {
                    EmployeeTable employeeTable = DbModels.EmployeeTables.Where(x => x.EmpID == id).FirstOrDefault();
                    DbModels.EmployeeTables.Remove(employeeTable);
                    DbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
