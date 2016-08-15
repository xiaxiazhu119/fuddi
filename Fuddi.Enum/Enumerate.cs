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
        ApplicationError = -0x9999999,
        OperationSuccess = 0x9999001,

        SignInFailed = 0x9001099,

        #region category

        AddCategorySuccess = 0x1002001,
        UpdateCategorySuccess = 0x1002002,
        DeleteCategorySuccess = 0x1002003,
        AddCategoryFailed = -0x1002099,
        UpdateCategoryFailed = -0x1002098,
        DeleteCategoryFailed = -0x1002097,

        AddCategoryGroupSuccess = 0x1003001,
        UpdateCategoryGroupSuccess = 0x1003002,
        DeleteCategoryGroupSuccess = 0x1003003,
        AddCategoryGroupFailed = -0x1003099,
        UpdateCategoryGroupFailed = -0x1003098,
        DeleteCategoryGroupFailed = -0x1003097,

        #endregion

        #region value type

        AddValueTypeSuccess = 0x1004001,
        UpdateValueTypeSuccess = 0x1004002,
        DeleteValueTypeSuccess = 0x1004003,
        AddValueTypeFailed = -0x1004099,
        UpdateValueTypeFailed = -0x1004098,
        DeleteValueTypeFailed = -0x1004097,

        #endregion

        AAA = 99999999
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

}
