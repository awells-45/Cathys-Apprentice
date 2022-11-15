using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlots_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;

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
        Debug.Log("Slot clicked");
    }
}
