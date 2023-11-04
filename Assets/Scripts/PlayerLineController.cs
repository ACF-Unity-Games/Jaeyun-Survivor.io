using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerLineController : MonoBehaviour
{

    private LineRenderer _lr;
    private Vector3[] _linePoints = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera c = Camera.main;
        Vector2 p = c.ScreenToWorldPoint(Input.mousePosition);
        _linePoints[0] = transform.position;
        _linePoints[1] = p;
        _lr.SetPositions(_linePoints);
    }
}
