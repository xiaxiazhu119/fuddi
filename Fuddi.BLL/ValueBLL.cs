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
        public IList<OD_ValueType> GetAllValueTypeList()
        {
            return dal.GetAllValueTypeList();
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
        /// 根据价值类型ID删除与之相关联商品关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteValueRelationByValueID(int id)
        {
            return dal.DeleteValueRelationByValueID(id);
        }

    }
}
