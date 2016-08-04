using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Configuration;

namespace Fuddi.Enum
{
    public class EnumClass
    {

        public static string GetAccountStatusName(AccountStatusEnum ase)
        {
            DescriptionCfg _descCfgInstance = (DescriptionCfg)Config.GetInstace(Config.ConfigEnum.Description);
            switch (ase)
            {
                case AccountStatusEnum.Unactivated:
                    return _descCfgInstance.ACCOUNT_STATUS_UACTIVATED;
                case AccountStatusEnum.Normal:
                    return _descCfgInstance.ACCOUNT_STATUS_NORMAL;
                case AccountStatusEnum.Disabled:
                    return _descCfgInstance.ACCOUNT_STATUS_DISABLED;
                case AccountStatusEnum.Deleted:
                    return _descCfgInstance.ACCOUNT_STATUS_DELETED;
                default:
                    return _descCfgInstance.ACCOUNT_STATUS_UNDEFINED;
            }
        }
    }
}
