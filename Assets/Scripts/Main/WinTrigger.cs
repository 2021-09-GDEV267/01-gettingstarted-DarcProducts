using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] float timeToTriggerWin;
    [SerializeField] UIController ui;
    
    void OnTriggerStay(Collider other)
    {
        timeToTriggerWin = timeToTriggerWin < 0 ? 0 : timeToTriggerWin -= Time.deltaTime;
        if (timeToTriggerWin.Equals(0))
            ui.UpdateWin();       
    }
}
 