using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModels;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
			return View(CompanyList);
		}

		public IActionResult Upsert(int? id)
		{
			if (id == null || id == 0)
			{
				//create
				return View(new Company());
			}
			else
			{
				//update
				Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
				return View(companyObj);
			}
		}

		[HttpPost]
		public IActionResult Upsert(Company company, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				if (company.Id == 0)
				{
					_unitOfWork.Company.Add(company);
				}
				else
				{
					_unitOfWork.Company.Update(company);
				}
				_unitOfWork.Save();
				TempData["success"] = "Company created successfully";
				return RedirectToAction("Index");
			}
			else
			{
				return View(company);
			}
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAll()
		{
			List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
			return Json(new { data = CompanyList });
		}

		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
			if (CompanyToBeDeleted == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.Company.Remove(CompanyToBeDeleted);
			_unitOfWork.Save();

			return Json(new { success = true, message = "Delete Successful" });
		}

		#endregion
	}
}
