using BukyBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;     

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
          //  IEnumerable<Company> objCompanyList = _unitOfWork.Company.GetAll();
            return View();
        }

        //GET

        public IActionResult Create()
        {
            return View();
        }
        //POST


        //GET
        public IActionResult Upsert(int? id)
        {
            /* Approach to access data from controller to view model
             * Company Company = new Company();
             IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Name,
                     Value = u.Id.ToString(),
                 });
             Another Approach to access data from controller to view model
             IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
            */
            Company Company = new();
            
            if (id == null || id == 0)
            {
                
                return View(Company);
            }
            else
            {
                Company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(Company);
                //update
            }
             
            return View(Company);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {

            //SERVER VALIDATION
            if (ModelState.IsValid)
            {
               
                if(obj.Id==0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company created succesfully";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company updated succesfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //VALIDATION FAILED
            return View(obj);

        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var CompanyList = _unitOfWork.Company.GetAll();
            return Json(new { data = CompanyList });
        }
        [HttpDelete]
       // [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(x => x.Id == id);   
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Company deleted  succesfully" });
        }
        #endregion
    }

}
