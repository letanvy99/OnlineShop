using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDBContent db = null;
        public ProductDao()
        {
            db = new OnlineShopDBContent();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        /// <summary>
        /// Get list product by category- join nhiều bảng với nhau
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<ProductViewModel> ListByCategoryID(long categoryID, ref int toatalRecord, int pageIndex=1, int pageSize = 2)
        {
            toatalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = from a in db.Products
                    join b in db.ProductCategories on a.CategoryID equals b.ID
                    where a.CategoryID == categoryID
                    select new ProductViewModel()
                    {
                        CateMetaTitle = b.MetaTitle,
                        CateName = b.Name,
                        CreateDate = a.CreatedDate,
                        ID= a.ID,
                        Images = a.Images,
                        Name = a.Name,
                        MetaTitle = a.MetaTitle,
                        Price = a.Price
                    };

            model.OrderByDescending(x=> x.CreateDate).Skip((pageIndex - 1)*pageIndex).Take(pageSize);
            return model.ToList();
        }
        /// <summary>
        /// List feature in Product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x=>x.TopHot!=null && x.TopHot> DateTime.Now ).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public List<Product> ListRelatedProduct(long productID)
        {
            var products = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.CategoryID == products.CategoryID).Take(4).ToList();
        }
    }
}
