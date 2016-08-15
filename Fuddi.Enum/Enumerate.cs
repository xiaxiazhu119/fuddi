using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Enum
{
    public enum Enumerate
    {
    }

    public enum AccountStatusEnum
    {
        Undefined,
        Unactivated,
        Normal,
        Disabled,
        Deleted
    }

    public enum LogActionEnum
    { 
        SignIn,
        SignUp,
        SignOut
    }

    public enum ResponseEnum
    { 
        ApplicationError = -9999999,
        OperationSuccess = 9999001,

        SignInFailed = 9001099,

        #region category

        AddCategorySuccess = 1002001,
        UpdateCategorySuccess = 1002002,
        DeleteCategorySuccess = 1002003,
        AddCategoryFailed = -1002099,
        UpdateCategoryFailed = -1002098,
        DeleteCategoryFailed = -1002097,

        AddCategoryGroupSuccess = 1003001,
        UpdateCategoryGroupSuccess = 1003002,
        DeleteCategoryGroupSuccess = 1003003,
        AddCategoryGroupFailed = -1003099,
        UpdateCategoryGroupFailed = -1003098,
        DeleteCategoryGroupFailed = -1003097,

        #endregion

        #region value type

        AddValueTypeSuccess = 1004001,
        UpdateValueTypeSuccess = 1004002,
        DeleteValueTypeSuccess = 1004003,
        DeleteValueProductRelationSuccess = 1004004,
        AddValueTypeFailed = -1004099,
        UpdateValueTypeFailed = -1004098,
        DeleteValueTypeFailed = -1004097,
        DeleteValueProductRelationFailed = -1004096,

        #endregion

        AAA = 99999999
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

}
