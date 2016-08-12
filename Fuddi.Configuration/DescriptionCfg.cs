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
        public readonly string RESPONSE_OPERATION_SUCCESS = "操作成功";

        public readonly string RESPONSE_SIGNIN_FAILED = "登录失败";

        #region category
        public readonly string RESPONSE_ADD_CATEGORY_SUCCESS = "添加分类成功";
        public readonly string RESPONSE_UPDATE_CATEGORY_SUCCESS = "更新分类成功";
        public readonly string RESPONSE_DELETE_CATEGORY_SUCCESS = "删除分类成功";
        public readonly string RESPONSE_ADD_CATEGORY_GROUP_SUCCESS = "添加分类组成功";
        public readonly string RESPONSE_UPDATE_CATEGORY_GROUP_SUCCESS = "更新分类组成功";
        public readonly string RESPONSE_DELETE_CATEGORY_GROUP_SUCCESS = "删除分类组成功";
        public readonly string RESPONSE_ADD_CATEGORY_FAILED = "添加分类失败";
        public readonly string RESPONSE_UPDATE_CATEGORY_FAILED = "更新分类失败";
        public readonly string RESPONSE_DELETE_CATEGORY_FAILED = "删除分类失败";
        public readonly string RESPONSE_ADD_CATEGORY_GROUP_FAILED = "添加分类组失败";
        public readonly string RESPONSE_UPDATE_CATEGORY_GROUP_FAILED = "更新分类组失败";
        public readonly string RESPONSE_DELETE_CATEGORY_GROUP_FAILED = "删除分类组失败";
        #endregion

        #endregion

    }

}
