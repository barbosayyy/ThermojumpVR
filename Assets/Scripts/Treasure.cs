using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<PlayerPickup>().Score();
        }
    }
}
