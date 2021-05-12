using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager gm;
    void OnTriggerEnter()
    {
        gm.CompleteLevel();
    }
}
