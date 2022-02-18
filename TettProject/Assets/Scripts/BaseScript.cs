using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public static Vector3 a = Vector3.zero;

    public virtual Vector3 GetA()
    {
        return a;
    }

}
