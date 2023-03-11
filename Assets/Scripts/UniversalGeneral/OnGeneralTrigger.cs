using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnGeneralTrigger : MonoBehaviour
{
    [SerializeField]UnityEvent OnTrigExecute;
    bool Executed=false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!Executed) { OnTrigExecute.Invoke(); Executed = true; }
    }
}
