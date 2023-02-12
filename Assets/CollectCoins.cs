using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoins : MonoBehaviour
{
    public Canvas pickupText;
    public GameObject coins;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public LayerMask layerMask;
    public float pickupRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
    }

    bool inPickupRadius()
    {
        return Physics.CheckSphere(transform.position, pickupRadius, layerMask);
    }

    void OnMouseOver()
    {
        Debug.Log("mouseOver");

        //If your mouse hovers over the GameObject with the script attached, output this message
        if (inPickupRadius())
        {
            pickupText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E)) {
                Destroy(coins);
                pickupText.enabled = false;
                audioSource.PlayOneShot(audioClip);
            }
        }

    }

}
