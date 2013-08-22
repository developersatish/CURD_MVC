using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlyMvc.BAL;
using OnlyMvc.DAL;
using OnlyMvc.Domain;
using OnlyMvc.Infrastructure;
using OnlyMvc.Models;

namespace OnlyMvc.Controllers
{
    public class CurdMvcController : Controller
    {
        //
        // GET: /CurdMVC/
        private ICurdRepository repository;

        public CurdMvcController()
        {
            this.repository = new CurdRepository(new MyContext());
        }
        public ActionResult CurdMvc(int? id)
        {


            return View(Model(id));
        }

        [HttpPost]
        public ActionResult CurdMvc(NewUserModel model, HttpPostedFileBase ImageName)
        {
            if (ModelState.IsValid)
            {
                bool skip = false;
                NewUser user = null;
                if (!repository.IsExist(model))
                {
                    user = new NewUser();
                    skip = true;
                }
                if (model.ID != 0)
                {
                    user = repository.GetById(model.ID);

                }


                string fileName = null;
                if (ImageName != null && ImageName.ContentLength > 0)
                {

                    string extension = Path.GetExtension(ImageName.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Server.MapPath("~/Assets/UserImage"), fileName);
                    ImageName.SaveAs(path);
                    user.ImageName = fileName;
                }


                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.HomeCity = model.HomeCity;

                if (skip)
                {
                    repository.Create(user);
                }
                else
                {
                    repository.Update(user);
                }
                repository.Save();
            }
            else
            {
                return View(Model(null));
            }
            return RedirectToAction("CurdMvc", "CurdMvc", new { id = UrlParameter.Optional });
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("CurdMvc");
        }

        private string GetFile(string file)
        {
            string actualPath = "/Assets/Signup.jpg";
            if (!String.IsNullOrEmpty(file))
            {
                string path = Server.MapPath("~/Assets/UserImage/" + file);
                if (System.IO.File.Exists(path))
                {
                    actualPath = "/Assets/UserImage/" + file;
                }
            }

            return actualPath;
        }

        private NewUserModel Model(int? id)
        {
            NewUserModel userModel = new NewUserModel();
            if (id != null)
            {
                NewUser newUser = repository.GetById((int)id);
                userModel.FirstName = newUser.FirstName;
                userModel.LastName = newUser.LastName;
                userModel.UserName = newUser.UserName;
                userModel.Email = newUser.Email;
                userModel.HomeCity = newUser.HomeCity;
                userModel.ImageName = GetFile(newUser.ImageName);
                userModel.IsEdit = true;
            }
            IEnumerable<NewUser> users = repository.GetAll();
            foreach (NewUser user in users)
            {
                userModel.NewUserModels.Add(new NewUserModel()
                {
                    ID = user.ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    HomeCity = user.HomeCity ?? user.HomeCity,
                    ImageName = GetFile(user.ImageName)
                });
            }

            IList<SelectListItem> list = Enum.GetValues(typeof(CityType)).Cast<CityType>().Select(x => new SelectListItem()
           {
               Text = EnumHelper.GetDescription(x),
               Value = ((int)x).ToString(),
           }).ToList();
            
            int city=0;
            if (userModel.HomeCity != null) city= (int)userModel.HomeCity;
            ViewData["HomeCity"] = new SelectList(list, "Value", "Text", city);
            

            return userModel;
        }
    }
}
