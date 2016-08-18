using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;
using Fuddi.Enum;

namespace Fuddi.DAL
{
    public class ProductDAL : BaseDAL
    {
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModel GetProductInfoByID(int id)
        {
            ProductModel model = new ProductModel();
            model.Info = entityInstance.OD_Product.FirstOrDefault(m => !m.DelFlag && m.ID.Equals(id));
            model.Info = model.Info == null ? new OD_Product() : model.Info;
            model.ImageList = entityInstance.OD_ProductImage.Where(m => m.ProductID.Equals(id)).OrderBy(m => m.Sort).ToList();
            return model;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="sc"></param>
        /// <param name="se"></param>
        /// <param name="oe"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<od_v_term> GetProductListByCondition(ProductSearchConditionModel sc, SortEnum se, OrderByEnum oe, int pageIndex, int pageSize, out int total)
        {
            var list = entityInstance.od_v_term as IQueryable<od_v_term>;
            if (sc.CategoryID > 0)
            {
                list = list.Where(m => m.CategoryID.Equals(sc.CategoryID));
            }
            if (!string.IsNullOrEmpty(sc.Keyword))
            {
                var contactProductIdList = entityInstance.od_v_product_dictionary.Where(m => m.Type.Equals((int)DictionaryTypeEnum.Tag) && m.Value.Contains(sc.Keyword)).Select(m => m.ProductID).ToList();
                list = list.Where(m => m.ProductName.Contains(sc.Keyword) || contactProductIdList.Contains(m.ProductID));
            }
            total = list.Count();
            switch (se)
            {
                case SortEnum.Popular:
                    list = list.OrderByDescending(m => m.TotalSell);
                    break;
                case SortEnum.Rest:
                    list = list.OrderBy(m => m.Rest);
                    break;
                case SortEnum.Latest:
                    list = list.OrderByDescending(m => m.CreateTime);
                    break;
                case SortEnum.Total:
                    if (oe == OrderByEnum.ASC)
                        list = list.OrderBy(m => m.Total);
                    else
                        list = list.OrderByDescending(m => m.Total);
                    break;
                default:
                    list = list.OrderByDescending(m => m.TotalSell);
                    break;
            }

            var rst = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return rst;
        }
    }
}
