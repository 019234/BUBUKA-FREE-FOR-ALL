using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDontDestroyScript : MonoBehaviour
{
    private static SimpleDontDestroyScript instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }
}
