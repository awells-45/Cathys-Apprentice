using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBrewingRunner : MonoBehaviour
{
    public StaticInventoryDisplay inventoryDisplay;

    private void Start()
    {
        inventoryDisplay.ItemUsed -= ConsumeItem; // initially disable
    }

    void OnEnable()
    {
        inventoryDisplay.ItemUsed += ConsumeItem;
    }
    
    void OnDisable()
    {
        inventoryDisplay.ItemUsed -= ConsumeItem;
    }

    void ConsumeItem(InventoryItemData consumedItem)
    {
        Debug.Log("Put " + consumedItem.DisplayName + " into the Cauldron");
        // TODO - do stuff here !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
