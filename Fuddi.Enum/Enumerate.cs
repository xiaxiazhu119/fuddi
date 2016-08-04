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

    public enum ActionEnum
    { 
        SignIn,
        SignUp,
        SignOut
    }
}
