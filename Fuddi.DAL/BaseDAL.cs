using Fuddi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.DAL
{
    public class BaseDAL
    {

        private static OneDreamEntities _entityInstance;
        protected internal static OneDreamEntities entityInstance
        {
            get
            {
                if (_entityInstance == null)
                    _entityInstance = new OneDreamEntities();
                return _entityInstance;
            }
        }

    }
}
