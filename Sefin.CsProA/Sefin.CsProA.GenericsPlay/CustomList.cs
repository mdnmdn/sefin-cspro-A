using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public class CustomList<T> where T: class
    {

        T[] _container = new T[1000];
        int _lastIndex = 0;

        public void Add(T newItem){
            _container[_lastIndex] = newItem;
            _lastIndex++;
        }

        public void Remove(int index) {
            //_container[index] = default(T);
            _container[index] = null;
        }

        public void Update(int index, T item) {
            _container[index] = item;
        }
    }
}
