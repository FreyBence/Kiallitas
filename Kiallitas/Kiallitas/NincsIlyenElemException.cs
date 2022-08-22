using System;
using System.Collections.Generic;
using System.Text;

namespace Kiallitas
{
    class NincsIlyenElemException : Exception
    {
        public NincsIlyenElemException() : base("Nincs ilyen esemény")
        {
        }
    }
}
