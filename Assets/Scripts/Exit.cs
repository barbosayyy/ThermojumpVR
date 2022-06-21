using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public GameObject exitImage;
    public GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<InputManager>().Disable();
        exitImage.SetActive(true);
        text.SetActive(true);
    }
}
