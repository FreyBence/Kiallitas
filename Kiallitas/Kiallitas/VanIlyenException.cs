using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class VanIlyenException : Exception
    {
        public VanIlyenException() : base("Ez a dátum már foglalt")
        {
        }
    }
}
