using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Configuration;

namespace Fuddi.Enum
{
    public class EnumClass
    {
        static DescriptionCfg cfg = DescriptionCfg.Instance;

        public static string GetAccountStatusDesc(AccountStatusEnum ase)
        {
            switch (ase)
            {
                case AccountStatusEnum.Unactivated:
                    return cfg.ACCOUNT_STATUS_UACTIVATED;
                case AccountStatusEnum.Normal:
                    return cfg.ACCOUNT_STATUS_NORMAL;
                case AccountStatusEnum.Disabled:
                    return cfg.ACCOUNT_STATUS_DISABLED;
                case AccountStatusEnum.Deleted:
                    return cfg.ACCOUNT_STATUS_DELETED;
                default:
                    return cfg.ACCOUNT_STATUS_UNDEFINED;
            }
        }
        public static string GetResponseDesc(ResponseEnum re)
        {
            switch (re)
            {
                case ResponseEnum.ApplicationError:
                    return cfg.RESPONSE_APPLICATION_ERROR;
                case ResponseEnum.OperationSuccess:
                    return cfg.RESPONSE_OPERATION_SUCCESS;
                case ResponseEnum.SignInFailed:
                    return cfg.RESPONSE_SIGNIN_FAILED;

                case ResponseEnum.AddCategorySuccess:
                    return cfg.RESPONSE_ADD_CATEGORY_SUCCESS;
                case ResponseEnum.UpdateCategorySuccess:
                    return cfg.RESPONSE_UPDATE_CATEGORY_SUCCESS;
                case ResponseEnum.DeleteCategorySuccess:
                    return cfg.RESPONSE_DELETE_CATEGORY_SUCCESS;
                case ResponseEnum.AddCategoryFailed:
                    return cfg.RESPONSE_ADD_CATEGORY_FAILED;
                case ResponseEnum.UpdateCategoryFailed:
                    return cfg.RESPONSE_UPDATE_CATEGORY_FAILED;
                case ResponseEnum.DeleteCategoryFailed:
                    return cfg.RESPONSE_DELETE_CATEGORY_FAILED;

                case ResponseEnum.AddCategoryGroupSuccess:
                    return cfg.RESPONSE_ADD_CATEGORY_GROUP_SUCCESS;
                case ResponseEnum.UpdateCategoryGroupSuccess:
                    return cfg.RESPONSE_UPDATE_CATEGORY_GROUP_SUCCESS;
                case ResponseEnum.DeleteCategoryGroupSuccess:
                    return cfg.RESPONSE_DELETE_CATEGORY_GROUP_SUCCESS;
                case ResponseEnum.AddCategoryGroupFailed:
                    return cfg.RESPONSE_ADD_CATEGORY_GROUP_FAILED;
                case ResponseEnum.UpdateCategoryGroupFailed:
                    return cfg.RESPONSE_UPDATE_CATEGORY_GROUP_FAILED;
                case ResponseEnum.DeleteCategoryGroupFailed:
                    return cfg.RESPONSE_DELETE_CATEGORY_GROUP_FAILED;

                case ResponseEnum.AddValueTypeSuccess:
                    return cfg.RESPONSE_ADD_VALUE_TYPE_SUCCESS;
                case ResponseEnum.UpdateValueTypeSuccess:
                    return cfg.RESPONSE_UPDATE_VALUE_TYPE_SUCCESS;
                case ResponseEnum.DeleteValueTypeSuccess:
                    return cfg.RESPONSE_DELETE_VALUE_TYPE_SUCCESS;
                case ResponseEnum.AddValueTypeFailed:
                    return cfg.RESPONSE_ADD_VALUE_TYPE_FAILED;
                case ResponseEnum.UpdateValueTypeFailed:
                    return cfg.RESPONSE_UPDATE_VALUE_TYPE_FAILED;
                case ResponseEnum.DeleteValueTypeFailed:
                    return cfg.RESPONSE_DELETE_VALUE_TYPE_FAILED;

                default:
                    return cfg.RESPONSE_OPERATION_SUCCESS;
            }
        }
    }
}
