using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UISlotHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [Header("Object Assignments")]
    [SerializeField] private GameObject _tooltipObject;
    [SerializeField] private TextMeshProUGUI _tooltipName;
    [SerializeField] private TextMeshProUGUI _tooltipDesc;
    [SerializeField] private Image _slotImage;

    /// <summary>
    /// Sets the current slot handler's data to work with a new item.
    /// </summary>
    /// <param name="itemInfo">The information of the item to newly set.</param>
    public void SetItem(Item itemInfo)
    {
        _slotImage.sprite = itemInfo.ItemSprite;
        _tooltipName.text = itemInfo.ItemName;
        _tooltipDesc.text = itemInfo.ItemDescription;
        HideTooltip();
    }

    public void ShowTooltip()
    {
        _tooltipObject.SetActive(true);
    }

    public void HideTooltip()
    {
        _tooltipObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }

}
