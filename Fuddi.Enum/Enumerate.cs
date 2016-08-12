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
        ApplicationError = 0x9999999,
        OperationSuccess = 0x9999001,

        SignInFailed = 0x9001099,

        #region category

        AddCategorySuccess = 0x1002001,
        UpdateCategorySuccess = 0x1002002,
        DeleteCategorySuccess = 0x1002003,
        AddCategoryGroupSuccess = 0x1003001,
        UpdateCategoryGroupSuccess = 0x1003002,
        DeleteCategoryGroupSuccess = 0x1003003,
        AddCategoryFailed = 0x1002099,
        UpdateCategoryFailed = 0x1002098,
        DeleteCategoryFailed = 0x1002097,
        AddCategoryGroupFailed = 0x1003099,
        UpdateCategoryGroupFailed = 0x1003098,
        DeleteCategoryGroupFailed = 0x1003097

        #endregion
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

}
