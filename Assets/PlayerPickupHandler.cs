using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupHandler : MonoBehaviour
{

    [Header("Player Properties")]
    [SerializeField] private float _pickupRange;

    private void Update()
    {
        GameObject[] pickupableObj = GameObject.FindGameObjectsWithTag("Pickupable");
        foreach (GameObject obj in pickupableObj)
        {
            // TODO: Make stuff pickup-able here!
        }
    }

}
