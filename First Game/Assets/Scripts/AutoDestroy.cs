using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float aliveTime;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, aliveTime); // gameObject represente l'objet sur lequel le script est ataché Start se lancera des que l'object est instantie

    }

}
