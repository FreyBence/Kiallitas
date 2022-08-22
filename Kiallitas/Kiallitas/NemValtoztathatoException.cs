using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class NemValtoztathatoException : Exception
    {
        public NemValtoztathatoException() : base("Ez a dátum nem változtatható")
        {
        }
    }
}
