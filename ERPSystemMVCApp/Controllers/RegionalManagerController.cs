using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPSystemMVCApp.EF;
using ERPSystemMVCApp.Models;

namespace ERPSystemMVCApp.Controllers
{
    public class RegionalManagerController : Controller
    {
        private readonly ERPSystemDBEntities1 db = new ERPSystemDBEntities1();
        // GET: RegionalManager
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(BranchCreateRMModel _branch)
        {
            ViewBag.Regions = this.db.Regions.ToList();

            if (!ModelState.IsValid)
            {
                return View(_branch);
            }

            Branch branch = new Branch();

            if (_branch.Name != null)
            {
                if (db.Branches.Where(b => b.Name == _branch.Name).Count() != 0)
                {
                    TempData["error_message"] = "Another Branch found";
                    return RedirectToAction("CreateBranch", "RegionalManager");
                }

                branch.Name = _branch.Name;
            }

            if (_branch.RegionId != 0)
            {
                if(db.Regions.Where(r => r.Id == _branch.RegionId).Count() == 0)
                {
                    TempData["error_message"] = "Region not found";
                    return RedirectToAction("CreateBranch", "RegionalManager");
                }

                branch.RegionId = _branch.RegionId;
            }

            Address address = new Address
            {
                LocalAddress = _branch.LocalAddress,
                PoliceStation = _branch.PoliceStation,
                City = _branch.City,
                Country = _branch.Country,
                ZipCode = _branch.ZipCode,
            };

            db.Addresses.Add(address);

            db.SaveChanges();

            branch.AddressId = address.Id;

            db.Branches.Add(branch);

            db.SaveChanges();

            TempData["success_message"] = "Successfully created branch";

            return RedirectToAction("CreateBranch", "RegionalManager");
        }
        [HttpGet]
        public ActionResult CreateRegion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRegion(RegionCreateRMModel _region)
        {
            ViewBag.Regions = this.db.Regions.ToList();

            if (!ModelState.IsValid)
            {
                return View(_region);
            }

            Region region = new Region();

            if (_region.Name != null)
            {
                if (db.Regions.Where(r => r.Name == _region.Name).Count() != 0)
                {
                    TempData["error_message"] = "Another Region found";
                    return RedirectToAction("CreateRegion", "RegionalManager");
                }

                region.Name = _region.Name;
            }

            Address address = new Address
            {
                LocalAddress = _region.LocalAddress,
                PoliceStation = _region.PoliceStation,
                City = _region.City,
                Country = _region.Country,
                ZipCode = _region.ZipCode,
            };

            db.Addresses.Add(address);

            db.SaveChanges();

            region.AddressId = address.Id;

            db.Regions.Add(region);

            db.SaveChanges();

            TempData["success_message"] = "Successfully created Region";

            return RedirectToAction("CreateRegion", "RegionalManager");
        }
        public ActionResult ShowAllBranch()
        {
            ViewBag.Branches = this.db.Branches.ToList();
            ViewBag.Regions = this.db.Regions.ToList();
            ViewBag.Addresses = this.db.Addresses.ToList();

            return View();
        }
    }
}