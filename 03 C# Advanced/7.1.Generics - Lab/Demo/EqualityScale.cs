using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }
        public T Left { get; private set; }
        public T Right { get; private set; }

        public bool AreEqual()
        {
            return Left.Equals(Right);
        }
    }
}
