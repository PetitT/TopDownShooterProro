using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance { get; private set; }

        protected virtual void Awake()
        {
            if(instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this as T;
            }
        }
    }
}
