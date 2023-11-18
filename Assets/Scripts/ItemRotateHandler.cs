using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotateHandler : MonoBehaviour
{

    [Header("Object Assignments")]
    public Transform _targetTransform;

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(_targetTransform.position, Vector3.forward, 180 * Time.deltaTime);
    }

}
