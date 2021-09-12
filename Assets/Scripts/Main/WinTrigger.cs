using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] float timeToTriggerWin;
    [SerializeField] UIController ui;
    
    void OnTriggerStay(Collider other)
    {
        timeToTriggerWin -= Time.fixedDeltaTime;
        if (timeToTriggerWin.Equals(0))
            ui.UpdateWin();
    }
}
 