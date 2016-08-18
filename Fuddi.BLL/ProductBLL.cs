using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;
using Fuddi.DAL;
using Fuddi.Enum;

namespace Fuddi.BLL
{
    public class ProductBLL
    {
        ProductDAL dal;

        public ProductBLL()
        {
            dal = new ProductDAL();
        }
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModel GetProductInfoByID(int id)
        {
            return dal.GetProductInfoByID(id);
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="sc"></param>
        /// <param name="se"></param>
        /// <param name="oe"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<od_v_term> GetProductListByCondition(ProductSearchConditionModel sc, SortEnum se, OrderByEnum oe, int pageIndex, int pageSize, out int total)
        {
            return dal.GetProductListByCondition(sc, se, oe, pageIndex, pageSize, out total);
        }
    }
}
