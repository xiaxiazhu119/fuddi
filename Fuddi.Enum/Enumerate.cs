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

        #endregion

        AAA = 99999999
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

    public enum DictionaryTypeEnum
    {
        Value = 1,
        Tag = 2,
        QuickTimes = 3
    }

    public enum SortEnum
    {
        Popular,
        Rest,
        Latest,
        Total
    }

    public enum OrderByEnum
    {
        DESC,
        ASC
    }

}
