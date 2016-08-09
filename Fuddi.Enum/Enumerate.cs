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
        SignInFailed = 0x9001001,
    }

    public enum ActionEnum
    {
        Add,
        Edit
    }

}
