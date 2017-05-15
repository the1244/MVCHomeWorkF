using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWorkF.Models;

namespace MVCHomeWorkF.Controllers
{
    public abstract class BaseController :Controller
    {
        public 客戶資料Repository 客戶資料Repository = RepositoryHelper.Get客戶資料Repository();
        public 客戶銀行資訊Repository 客戶銀行資訊Repository = RepositoryHelper.Get客戶銀行資訊Repository();
        public 客戶聯絡人Repository 客戶聯絡人Repository = RepositoryHelper.Get客戶聯絡人Repository();

    }
}