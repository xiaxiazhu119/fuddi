using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;

namespace Fuddi.DAL
{
    public class ValueDAL : BaseDAL
    {
        /// <summary>
        /// 获取所有价值类型
        /// </summary>
        /// <returns></returns>
        public IList<OD_ValueType> GetAllValueType()
        {
            var list = entityInstance.OD_ValueType.Where(m => !m.DelFlag).ToList();
            return list;
        }

        /// <summary>
        /// 添加价值类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddValueType(OD_ValueType model)
        {
            entityInstance.OD_ValueType.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        /// <summary>
        /// 更新价值类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateValueType(OD_ValueType model)
        {
            var a = entityInstance.OD_ValueType.First(m => m.ID.Equals(model.ID));
            a.Name = model.Name;
            a.Value = model.Value;
            int rst = entityInstance.SaveChanges();
            return rst;
        }

        /// <summary>
        /// 删除价值类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteValueType(int id)
        {
            var a = entityInstance.OD_ValueType.First(m => m.ID.Equals(id));
            a.DelFlag = true;
            int rst = entityInstance.SaveChanges();
            if (rst > 0)
            {
                rst += DeleteValueProductRelationByValueID(id);
            }
            return rst;
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
            var list = entityInstance.v_value_product_relation as IQueryable<v_value_product_relation>;
            if (vid != 0)
                list = list.Where(m => m.ValueID.Equals(vid));
            total = list.Count();
            if (total > 0)
                list = list.OrderByDescending(m => m.RelationID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return list.ToList();
        }

        /// <summary>
        /// 根据价值类型ID删除与之相关联商品关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteValueProductRelationByValueID(int id)
        {
            int rst = 0;
            entityInstance.OD_ValueProductRelation.RemoveRange(entityInstance.OD_ValueProductRelation.Where(m => m.ValueID.Equals(id)));
            rst = entityInstance.SaveChanges();
            return rst;
        }

        /// <summary>
        /// 删除价值商品对应信息
        /// </summary>
        /// <param name="relationid"></param>
        /// <returns></returns>
        public int DeleteValueProductRelationByRelationID(int relationid)
        {
            int rst = 0;
            entityInstance.OD_ValueProductRelation.RemoveRange(entityInstance.OD_ValueProductRelation.Where(m => m.ID.Equals(relationid)));
            rst = entityInstance.SaveChanges();
            return rst;
        }
    }
}
