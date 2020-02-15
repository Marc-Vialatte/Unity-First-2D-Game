using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public void ObjectDestroy()
    {
        Destroy(gameObject, 0.2f);
    }
}
