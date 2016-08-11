using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Models
{
    public class CategoryModel : OD_Category
    {
        public IList<CategoryModel> CategoryList { get; set; }
    }

    public class CategoryGroupRelationModel
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
