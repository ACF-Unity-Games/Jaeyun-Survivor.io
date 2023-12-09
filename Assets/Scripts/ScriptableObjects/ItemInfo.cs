using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemModifiers
{
    [Tooltip("Speed increase this item grants when equipped")]
    public int PlayerSpdInc;
    [Tooltip("Size increase this item grants when equipped")]
    public int PlayerSizeInc;
    [Tooltip("Vision increase this item grants when equipped")]
    public int PlayerVsnInc;
}

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemInfo : ScriptableObject
{

    [Header("Item Metadata")]
    public string ItemName;
    public string ItemDescription;
    public Sprite ItemSprite;

    [Header("Item Statistics")]
    [Tooltip("How much damage the item deals")]
    public int ItemAtk;
    [Tooltip("How much damage the item can take before breaking")]
    public int ItemHp;
    [Tooltip("How fast until the item can attack again (in seconds)")]
    public float ItemDisableTime;
    [Tooltip("How fast until the item is able to be used after breaking (in seconds)")]
    public float ItemReloadTime;

    [Header("Item Modifiers")]
    public ItemModifiers ItemModifiers;

}