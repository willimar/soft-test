using System;
using System.Collections.Generic;
using System.Text;

namespace Soft.CalculateInterest.Domain.interfaces
{
    public interface INavigator
    {
        decimal Get(string url);
    }
}
