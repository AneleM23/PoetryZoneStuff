using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        // Don't destroy this object when loading new scenes
        DontDestroyOnLoad(this.gameObject);
    }
}
