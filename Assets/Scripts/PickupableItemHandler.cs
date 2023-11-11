using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupableItemHandler : MonoBehaviour
{

    [Header("Item Properties")]
    [SerializeField] private Item _itemInfo;

    private SpriteRenderer _spriteRenderer;

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
