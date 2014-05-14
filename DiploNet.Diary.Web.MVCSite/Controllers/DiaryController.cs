using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiploNet.Diary.Domains;
using DiploNet.Diary.Web.MVCSite.Models;

namespace DiploNet.Diary.Web.MVCSite.Controllers
{
    public class DiaryController : Controller
    {
        //
        // GET: /Diary/

        private IDiaryPageDomain _diaryPageDomain;

        public DiaryController(IDiaryPageDomain diaryPageDomain)
        {
            _diaryPageDomain = diaryPageDomain;
        }

        public ViewResult Index()
        {
            var diaryPageModel = new DiaryModel();
            diaryPageModel.DiaryPages = _diaryPageDomain.GetAll();
            
            return View(diaryPageModel);
        }
    }
}
