using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDBContent db = null;
        public ContentDao()
        {
            db = new OnlineShopDBContent();
        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
      
    }
}
