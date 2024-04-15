using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diving : MonoBehaviour
{

    [Header("Objects")]
    public Animator _anim;
    public Rigidbody _mover;



    [Header("Input Names")]
    [SerializeField] private string _inputNameDive;

    private bool isDiving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown(_inputNameDive))
        {
            StartDive();

        }
        else if (Input.GetButtonUp(_inputNameDive))
        {
            EndDive();
        }
    }

    void StartDive()
    {
        isDiving = true;
        _anim.SetBool("IsDiving", true);
    }

    void EndDive()
    {
        isDiving = false;
        _anim.SetBool("IsDiving", false);
    }
}
