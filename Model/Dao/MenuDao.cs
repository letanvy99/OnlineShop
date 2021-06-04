﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineShopDBContent db = null;

        public MenuDao()
        {
            db = new OnlineShopDBContent();
        }
        public List<Menu> ListByGroupId(int group)
        {
            return db.Menus.Where(x => x.TypeID == group && x.Status == true).OrderBy(x=> x.DisplayOrder).ToList();
        }
    }
}
