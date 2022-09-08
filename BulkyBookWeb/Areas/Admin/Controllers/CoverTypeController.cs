using BukyBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Authorize]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //GET

        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            //CUSTOM VALIDATION

            //SERVER VALIDATION
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"]="CoverType created succesfully";
                return RedirectToAction("Index");
            }

            //VALIDATION FAILED
            return View(obj);

        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           // var CoverTypeFromDb = _db.Categories.Find(id);
             var CoverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id == id);
            // var CoverTypeFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            //CUSTOM VALIDATION

            //SERVER VALIDATION
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                  TempData["success"]="CoverType updated succesfully";
                return RedirectToAction("Index");
            }

            //VALIDATION FAILED
            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CoverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id == id);
            // var CoverTypeFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            // var CoverTypeFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(CoverTypeFromDb);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
              TempData["success"]="CoverType deleted succesfully";
            return RedirectToAction("Index");

        }
    }
}
