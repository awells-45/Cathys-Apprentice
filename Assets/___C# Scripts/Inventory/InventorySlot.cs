using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //can see inspector
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData; //serializeField is used to see in the inspector
    [SerializeField] private int stackSize; //how many itemData player has access to

    /*dont want to accidentally modify ^^^^ that, so this part of code is used for reference*/
    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    //making a constructor
    public InventorySlot(InventoryItemData source, int amount) //this gets source data (ScriptableObjects Items)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        //itemData = null;
        //stackSize = -1;
        //^^^ slots are ready to go but have nothing in it to begin with
        ClearSlot(); // setting it to empty well duh
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining) //passes out how many remaining
    {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd) //make sure they have the same constructor name
    {
        if (stackSize + amountToAdd <= itemData.MaxStackSize) return true;
        else return false; //not enough room
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        if (stackSize >= amount)
        {
            // call function about using n = amount items of type itemData???
            Debug.Log("Consumed " + amount + " of " + itemData.DisplayName);
            stackSize -= amount;
            if (stackSize < 1)
            {
                ClearSlot();
            }
        }
        else
        {
            if (itemData != null)
            {
                // call function about using n = stackSize items of type itemData???
                Debug.Log("Consumed " + stackSize + " of " + itemData.DisplayName);
            }
            ClearSlot();
        }
        
    }

}
