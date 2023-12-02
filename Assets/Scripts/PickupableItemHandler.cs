using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupableItemHandler : MonoBehaviour
{

    [Header("Item Properties")]
    [SerializeField] private ItemInfo _itemInfo;

    private SpriteRenderer _spriteRenderer;

    public ItemInfo ItemInfo {  
        get { return _itemInfo; }  
        set { _itemInfo = value; }
    }

    /// <summary>
    /// Deletes this item.
    /// </summary>
    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        Debug.Assert(_itemInfo != null, "Item info for object cannot be null!", this);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeSprite();
    }

    private void InitializeSprite()
    {
        _spriteRenderer.sprite = _itemInfo.ItemSprite;
    }

}
