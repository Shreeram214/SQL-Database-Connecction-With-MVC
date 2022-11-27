using ConnectionOfSql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectionOfSql.Controllers
{
    public class PeopleListController : Controller
    {
        PeopleDAL people = new PeopleDAL();
        // GET: PeopleList
        public ActionResult Index()
        {
            try
            {
                var PeopleList = people.GetPeopleList();
                return View(PeopleList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}