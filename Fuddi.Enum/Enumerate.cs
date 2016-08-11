﻿using System;
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
        AddCategoryGroupSuccess = 0x1002003,
        UpdateCategoryGroupSuccess = 0x1002004,
        AddCategoryFailed = 0x1002099,
        UpdateCategoryFailed = 0x1002098,
        AddCategoryGroupFailed = 0x1002097,
        UpdateCategoryGroupFailed = 0x1002096

        #endregion
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

}
