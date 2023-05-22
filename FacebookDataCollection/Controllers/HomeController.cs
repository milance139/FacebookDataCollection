using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using DataCollectionTask.Wrappers;
using Newtonsoft.Json;
using FacebookDataCollection.Interfaces;
using FacebookDataCollection.Models;
using FacebookDataCollection.Models.FacebookModels;
using FacebookDataCollection.Models.FacebookModels.PostModels;

namespace FacebookDataCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _appID;
        private readonly string _appSecret;
        private readonly IFacebookApiClient _facebookApiClient;

        public HomeController()
        {
            _appID = ConfigurationManager.AppSettings["Facebook:AppID"];
            _appSecret = ConfigurationManager.AppSettings["Facebook:AppSecret"];
            _facebookApiClient = new FacebookApiClientWrapper(_appID, _appSecret);
        }

        private Uri RedirectUri
        {
            get
            {
                UriBuilder uriBuilder = new UriBuilder(Request.UrlReferrer.ToString())
                {
                    Query = null,
                    Fragment = null,
                    Path = Url.Action("FacebookCallback")
                };
                return uriBuilder.Uri;
            }
        }

        public ActionResult Facebook()
        {
            var loginUrl = _facebookApiClient.GetLoginUrl(RedirectUri);
            return Redirect(loginUrl);
        }

        public ActionResult FacebookCallback(string code)
        {
            var accessToken = _facebookApiClient.GetAccessToken(code, RedirectUri);
            FacebookData facebookData = _facebookApiClient.GetFacebookData(accessToken);

            TempData["FacebookData"] = facebookData;

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            FacebookData model = TempData["FacebookData"] as FacebookData;
            if (model != null)
            {
                model.Posts.Posts = model.Posts.Posts.Where(post => !string.IsNullOrEmpty(post.Message)).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DownloadJson(FacebookData model)
        {
            if (model != null)
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var fileName = "facebook_data.json";
                var fileBytes = Encoding.UTF8.GetBytes(jsonData);

                return File(fileBytes, "application/json", fileName);
            }

            return File(new byte[0], "application/json", "empty.json");
        }
    }
}
