using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.DAL;
using Fuddi.Models;

namespace Fuddi.BLL
{
    public class ValueBLL
    {
        ValueDAL dal;
        public ValueBLL()
        {
            dal = new ValueDAL();
        }

        /// <summary>
        /// 获取所有价值类型
        /// </summary>
        /// <returns></returns>
        public IList<OD_ValueType> GetAllValueType()
        {
            return dal.GetAllValueType();
        }

        /// <summary>
        /// 添加价值类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddValueType(OD_ValueType model)
        {
            model.DelFlag = false;
            model.CreateTime = DateTime.Now;
            return dal.AddValueType(model);
        }

        /// <summary>
        /// 更新价值类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateValueType(OD_ValueType model)
        {
            return dal.UpdateValueType(model);
        }

        /// <summary>
        /// 删除价值类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteValueType(int id)
        {
            return dal.DeleteValueType(id);
        }

        /// <summary>
        /// 根据条件获取价值商品关联列表
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<v_value_product_relation> GetValueProductRelationListByCondition(int vid, int pageIndex, int pageSize, out int total)
        {
            return dal.GetValueProductRelationListByCondition(vid, pageIndex, pageSize, out total);
        }

        /// <summary>
        /// 根据价值类型ID删除与之相关联商品关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteValueProductRelationByValueID(int id)
        {
            return dal.DeleteValueProductRelationByValueID(id);
        }

        /// <summary>
        /// 删除价值商品对应信息
        /// </summary>
        /// <param name="relationid"></param>
        /// <returns></returns>
        public int DeleteValueProductRelationByRelationID(int relationid)
        {
            return dal.DeleteValueProductRelationByRelationID(relationid);
        }

    }
}
