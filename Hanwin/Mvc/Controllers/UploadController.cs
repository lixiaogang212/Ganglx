using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UploadFile()
        {
            //byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(aContext.Request["fileStrings"]);
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(aContext.Request["fileStrings"]);
            
            //byte[] bytes = System.Text.Encoding.Default.GetBytes(fileStrings);
           
            FileStream fs = new FileStream("E:\\ak.pdf", FileMode.Create);
            //fs.Write(bytes, 0, bytes.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            return Json(new { });
        }
        //
        // GET: /Upload/Details/5
        
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Upload/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Upload/Create

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

        //
        // GET: /Upload/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Upload/Edit/5

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

        //
        // GET: /Upload/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Upload/Delete/5

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
