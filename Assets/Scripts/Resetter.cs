using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    public PlayerMovement player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.ResetPos();
        }
    }
}
