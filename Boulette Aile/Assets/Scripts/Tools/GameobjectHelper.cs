using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameobjectHelper
{
    public static bool TryGetComponent<T>(GameObject objectToCheck, out T component) where T : MonoBehaviour
    {
        component = objectToCheck.GetComponent<T>();
        if (component != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool TryGetComponent<T>(GameObject objectToCheck) where T : MonoBehaviour
    {
        T component = objectToCheck.GetComponent<T>();
        if (component != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
