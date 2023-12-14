using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDamageHandler))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemRotateHandler))]
[RequireComponent(typeof(HealthHandler))]
public class SpinningItemHandler : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private CollisionDamageHandler _collisionDamageHandler;
    private ItemRotateHandler _itemRotateHandler;
    private HealthHandler _healthHandler;
    private UISlotHandler _uiSlotHandler;

    private ItemInfo _currItem;

    /// <summary>
    /// Set the information for this current spinning item.
    /// </summary>
    /// <param name="item">Item data to set to.</param>
    /// <param name="uiSlot">UI slot this corresponds to.</param>
    /// <param name="transform">Transform to rotate around.</param>
    public void SetSpinningItem(ItemInfo item, UISlotHandler uiSlotHandler, Transform transform)
    {
        _currItem = item;
        _uiSlotHandler = uiSlotHandler;
        _itemRotateHandler.SetSpinningItem(item, transform);
        _healthHandler.Initialize(_currItem.ItemHp);
        _healthHandler.OnUpdate = () =>
        {
            uiSlotHandler.UpdateBGHealth(_healthHandler.GetHealthRatio());
        };
        _healthHandler.OnUpdate.Invoke();
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
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void Start()
    {
        _healthHandler.OnDeath = (gameObject) =>
        {
            StartCoroutine(DisableItemTemporarilyAfterDestroyed());
        };
    }

    private IEnumerator DisableItemTemporarilyAfterDestroyed()
    {
        _collisionDamageHandler.IsActive = false;
        _spriteRenderer.color -= new Color(0, 0, 0, 0.8f);
        _healthHandler.ResetToMaxHealth();
        float currTime = 0;
        float timeToWait = _currItem.ItemReloadTime;
        while (currTime < timeToWait)
        {
            currTime += Time.deltaTime;
            _uiSlotHandler.UpdateBGHealth(currTime / timeToWait);
            yield return null;
        }
        _spriteRenderer.color += new Color(0, 0, 0, 0.8f);
        _collisionDamageHandler.IsActive = true;
    }

}
