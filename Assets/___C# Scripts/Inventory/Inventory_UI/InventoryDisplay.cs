using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.tutorialsteacher.com/csharp/csharp-event
// https://www.infoworld.com/article/2996770/how-to-work-with-delegates-in-csharp.html

public delegate void ItemDelegate(InventoryItemData removedItemData);

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlots_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public GameObject potionBrewer;
    public event ItemDelegate ItemUsed;

    public Dictionary<InventorySlots_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignedSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot) // Slot value - the "under the hood" inventory slot
            {
                slot.Key.UpdateUISlot(updatedSlot); // Slot key - the UI representation of the value
            }
        }
    }

    public void SlotClicked(InventorySlots_UI clickedSlot)
    {
        if (potionBrewer != null)
        {
            if (potionBrewer.activeSelf)
            {
                InventoryItemData removedItemData = clickedSlot.AssignedInventorySlot.ItemData;
                inventorySystem.RemoveFromInventoryOnClick(clickedSlot.AssignedInventorySlot, 1);
                if (removedItemData != null)
                {
                    ItemUsed?.Invoke(removedItemData); // send out event with the item data for what was removed
                }
            }
        }
    }
}
