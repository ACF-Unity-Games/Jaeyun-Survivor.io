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

    private bool _isEmpty;
    public bool IsEmpty
    {
        get { return _isEmpty; }
        private set { _isEmpty = value; }
    }

    /// <summary>
    /// Sets the current slot handler's data to work with a new item.
    /// If null, just initializes without setting information.
    /// </summary>
    /// <param name="itemInfo">The information of the item to newly set.</param>
    public void SetItem(ItemInfo itemInfo)
    {
        // This slot is empty if there is no supplied item info.
        _isEmpty = itemInfo == null;
        // Set this information if not empty.
        if (!_isEmpty)
        {
            _slotImage.sprite = itemInfo.ItemSprite;
            _tooltipName.text = itemInfo.ItemName;
            _tooltipDesc.text = itemInfo.ItemDescription;
        }
        HideTooltip();
    }

    /// <summary>
    /// Shows the tooltip to describe the item's information.
    /// If the slot is empty (no item info is stored), does nothing.
    /// </summary>
    public void ShowTooltip()
    {
        if (IsEmpty) { return; }
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
