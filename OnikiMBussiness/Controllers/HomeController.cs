using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnikiMBussiness.Models;

namespace OnikiMBussiness.Controllers
{
    public class HomeController : Controller
    {
        TestContext db = new TestContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetByProduct()
        {
            return View();
        }

        [Obsolete]
        public IActionResult GetProduct(string value,DateTime baslangic,DateTime bitis)
        {
            Stk entity = db.Stk.FirstOrDefault(x => x.MalAdi == value || x.MalKodu == value);
            
            var kod = new SqlParameter("@malKodu", value);
            var startParam = new SqlParameter("@baslangicTarihi", Convert.ToInt32(baslangic.ToOADate()));
            var endParam = new SqlParameter("@bitisTarihi", Convert.ToInt32(bitis.ToOADate()));

            var liste = db.Query<spModel>().FromSqlRaw("execute dbo.stok @malKodu,@baslangicTarihi,@bitisTarihi", kod,startParam,endParam).ToList();

            decimal stok = 0;
            foreach (var item in liste)
            {
                if (item.IslemTur == "Giris")
                {
                    stok += item.GirisMiktar;
                }
                else
                {
                    stok -= item.CikisMiktar;
                }
                item.StokMiktar = stok;

            }

            return Json(liste.OrderBy(x=>x.Tarih));



        }

    }
}
