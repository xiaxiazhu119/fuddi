using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fuddi.Configuration
{
    public class BaseSiteMapCfg : BaseConfig
    {
    }

    public class CMSSiteMapModel
    {
        public string Module { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public bool HasViews { get; set; }
        public CMSViewModel CurrentView { get; set; }
        public IList<CMSViewModel> Views { get; set; }
    }

    public class CMSViewModel
    {
        public string Title { get; set; }
        public bool InMenu { get; set; }
        public string Action { get; set; }
    }
}
