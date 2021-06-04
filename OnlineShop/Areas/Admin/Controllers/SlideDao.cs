using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideDao
    {
        OnlineShopDBContent db = null;
        public SlideDao()
        {
            db = new OnlineShopDBContent();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}