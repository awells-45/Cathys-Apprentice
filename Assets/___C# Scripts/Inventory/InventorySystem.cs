using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => inventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            InventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        /* //to visualize it
         * inventorySlots[0] = new InventorySlot(itemToAdd, amountToAdd);
        return true;
        */

        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot)) //Check whether item exists in inventory
        {
            foreach (var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    Debug.Log("Added " + amountToAdd + " of " + itemToAdd.DisplayName);
                    return true;
                }
            }

        }

        if (HasFreeSlot(out InventorySlot freeSlot)) // gets the first available slot
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            Debug.Log("Added " + amountToAdd + " of " + itemToAdd.DisplayName);
            return true;
        }

        return false;
    }

    public void RemoveFromInventoryOnClick(InventorySlot slotToTakeFrom, int amountToRemove)
    {
        slotToTakeFrom.RemoveFromStack(amountToRemove);
        OnInventorySlotChanged?.Invoke(slotToTakeFrom);
    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot)
    {
        /*without list
         * invSlot = null;
        return false;
        */
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();
        //return invSlot.Count > 1 ? true : false;
        if (invSlot.Count > 0)
        {
            Debug.Log("Have " + itemToAdd.DisplayName);
        }
        else
        {
            Debug.Log("Don't have " + itemToAdd.DisplayName);
        }
        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
