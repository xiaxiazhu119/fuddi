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
}
