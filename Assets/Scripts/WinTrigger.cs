using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gm;
    void OnTrigger()
    {
        //Winnning Text not showing need to fix.
        gm.CompleteLevel();
    }
}
