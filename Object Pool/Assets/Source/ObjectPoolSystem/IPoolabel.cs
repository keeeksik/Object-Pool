using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolSystem
{
    public interface IPoolabel<T> where T : Object, IPoolabel<T>
    {
        void Init(ObjectPool<T> obj);
    }
}
