using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Mvc;
using QLSV_TEST.Models;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace QLSV_TEST.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var employees = new DBcontextQLNV().Employees.ToList();

            ViewBag.Employees = employees;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Delete(string employeeID)
        {      
            try
            {
                using (var context = new DBcontextQLNV())
                {
                    // Tìm Employee cần xóa bằng EmployeeID
                    var employeeToDelete = context.Employees.Find(employeeID);

                    if (employeeToDelete != null)
                    {
                        // Xóa Employee khỏi database
                        context.Employees.Remove(employeeToDelete);
                        context.SaveChanges();
                    }
                }

                // Đã xóa thành công, bạn có thể thực hiện các xử lý khác nếu cần
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi xóa Employee: " + ex.Message);
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            try
            {
                using (var context = new DBcontextQLNV())
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

            
                return RedirectToAction("Home", "Index");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi them Employee: " + ex.Message);
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult CheckEmployeeIDExists(string employeeID)
        {
            using (var context = new DBcontextQLNV())
            {
                // Kiểm tra xem EmployeeID đã tồn tại hay chưa
                bool exists = context.Employees.Any(e => e.EmployeeID == employeeID);

                return Json(exists);
            }
        }

        [HttpPost]
        public ActionResult Put(Employee employee)
        {

            using (var context = new DBcontextQLNV())
            {
                // Tìm nhân viên cần sửa bằng ID
                var new_Employee = context.Employees.Find(employee.EmployeeID);

                if (new_Employee != null)
                {
                    // Cập nhật thông tin của nhân viên từ dữ liệu gửi lên
                    new_Employee.EmployeeID = employee.EmployeeID;
                    new_Employee.EmployeeName = employee.EmployeeName;
                    new_Employee.Email = employee.Email;
                    new_Employee.IdentifyCardNo = employee.IdentifyCardNo;
                    new_Employee.Birthday = employee.Birthday;
                    new_Employee.IdentifyDate = employee.IdentifyDate;
                    new_Employee.IndentifyPlace = employee.IndentifyPlace;
                    new_Employee.Address = employee.Address;
                    new_Employee.Phone = employee.Phone;

                    context.Entry(new_Employee).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index"); 
                }
                else
                {
                    // Xử lý khi không tìm thấy nhân viên
                    return HttpNotFound();
                }
            }


        }
    }
}