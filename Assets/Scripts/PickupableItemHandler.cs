using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupableItemHandler : MonoBehaviour
{

    [Header("Item Properties")]
    [SerializeField] private Item _itemInfo;

    private SpriteRenderer _spriteRenderer;

    public Item ItemInfo {  
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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeSprite();
    }

    private void InitializeSprite()
    {
        _spriteRenderer.sprite = _itemInfo.ItemSprite;
    }

}
