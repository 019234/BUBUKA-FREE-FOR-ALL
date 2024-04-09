using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePressButton : MonoBehaviour
{
    public GameObject playerCounter;

    void Start()
    {
        playerCounter.SetActive(true);
    }
}
