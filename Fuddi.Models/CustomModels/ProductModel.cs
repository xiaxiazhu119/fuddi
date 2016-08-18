using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Models
{
    public class ProductModel
    {
        public OD_Product Info { get; set; }
        public IList<OD_ProductImage> ImageList { get; set; }
        public IList<OD_Dictionary> TagList { get; set; }
    }

    public class ProductSearchConditionModel
    {
        public string Keyword { get; set; }
        public int CategoryID { get; set; }
    }
}
