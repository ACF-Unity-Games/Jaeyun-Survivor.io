using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDamageHandler))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemRotateHandler))]
public class SpinningItemHandler : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private CollisionDamageHandler _collisionDamageHandler;
    private ItemRotateHandler _itemRotateHandler;
    private UISlotHandler _uiSlotHandler;

    private ItemInfo _currItem;

    /// <summary>
    /// Set the information for this current spinning item.
    /// </summary>
    /// <param name="item">Item data to set to.</param>
    /// <param name="transform">Transform to rotate around.</param>
    public void SetSpinningItem(ItemInfo item, Transform transform)
    {
        _currItem = item;
        _itemRotateHandler.SetSpinningItem(item, transform);
    }

    /// <summary>
    /// Set the transform offset of this spinning item.
    /// </summary>
    /// <param name="angle"></param>
    public void SetTransformOffset(float angle)
    {
        _itemRotateHandler.SetTransformOffset(angle);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _itemRotateHandler = GetComponent<ItemRotateHandler>();
        _collisionDamageHandler = GetComponent<CollisionDamageHandler>();
    }

    private void Start()
    {
        _collisionDamageHandler.OnDealDamage += () =>
        {
            StartCoroutine(DisableItemTemporarilyAfterUse());
        };
    }

    private IEnumerator DisableItemTemporarilyAfterUse()
    {
        _collisionDamageHandler.enabled = false;
        _spriteRenderer.color -= new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(_currItem.ItemDisableTime);
        _spriteRenderer.color += new Color(0, 0, 0, 0.8f);
        _collisionDamageHandler.enabled = true;
    }

}
