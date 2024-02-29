using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2
{
    static class Enumerator
    {
        public static GenericEnumeratorAdapter<T> AsGeneric<T>(this IEnumerator source)
        {
            return new GenericEnumeratorAdapter<T>(source);
        }
    }
}
