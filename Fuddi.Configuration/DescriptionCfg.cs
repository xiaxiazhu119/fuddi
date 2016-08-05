using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Configuration
{
    public class DescriptionCfg : BaseConfig
    {
        static DescriptionCfg _instance;
        public static DescriptionCfg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DescriptionCfg();
                return _instance;
            }
        }

        #region account status

        public readonly string ACCOUNT_STATUS_UNDEFINED = "未定义";
        public readonly string ACCOUNT_STATUS_UACTIVATED = "未激活";
        public readonly string ACCOUNT_STATUS_NORMAL = "正常";
        public readonly string ACCOUNT_STATUS_DISABLED = "已禁用";
        public readonly string ACCOUNT_STATUS_DELETED = "已删除";

        #endregion

        #region response

        public readonly string RESPONSE_APPLICATION_ERROR = "应用程序错误";
        public readonly string RESPONSE_SIGNIN_FAILED = "登录失败";

        #endregion

    }

}
