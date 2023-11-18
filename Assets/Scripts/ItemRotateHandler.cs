using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotateHandler : MonoBehaviour
{

    [Header("Object Assignments")]
    [SerializeField] private Transform _targetTransform;
    
    private SpriteRenderer _itemSpriteRenderer;

    private void Awake()
    {
        _itemSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Set the information for this current spinning item.
    /// </summary>
    /// <param name="item">Item data to set to.</param>
    /// <param name="transform">Transform to rotate around.</param>
    public void SetSpinningItem(Item item, Transform transform)
    {
        _itemSpriteRenderer.sprite = item.ItemSprite;
        _targetTransform = transform;
    }

    public void SetTransformOffset(float angle)
    {
        transform.RotateAround(_targetTransform.position, Vector3.forward, angle);
    }

    private void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(_targetTransform.position, Vector3.forward, 180 * Time.deltaTime);
    }

}
