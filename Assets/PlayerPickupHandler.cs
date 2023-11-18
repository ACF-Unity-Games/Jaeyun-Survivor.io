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
            float distToObject = Vector3.Distance(transform.position, obj.transform.position);
            if (distToObject < _pickupRange)
            {
                PickupableItemHandler pih = obj.GetComponent<PickupableItemHandler>();
                if (pih == null) { continue; }  // If item doesn't have PIH, skip.
                pih.PickUpItem();
            }
        }
    }

}
