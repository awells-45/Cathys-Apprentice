using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// References:
//  https://zetcode.com/csharp/foreach/
//  https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/
//  https://www.codegrepper.com/tpc/unity+save+list+to+json
//  https://docs.unity3d.com/2020.1/Documentation/Manual/JSONSerialization.html

public struct PersistentInvenStruct
{
    public List<InventoryItemData> persistentInventory;
}

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    public InventorySystem InventorySystem => inventorySystem;

    public static UnityAction<InventorySystem> onDynamicInventoryDisplayRequested;

    public List<InventoryItemData> persistentInventory;

    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
        persistentInventory = new List<InventoryItemData>();
    }

    private void Start()
    {
        LoadInventory();
        inventorySystem.OnInventorySlotChanged += UpdatePerstInventory;
    }

    public void LoadInventory() // load persistentInventory from a file
    {
        if (PlayerPrefs.HasKey("inventoryJson"))
        {
            string inventoryJson = PlayerPrefs.GetString("inventoryJson");
            Debug.Log(inventoryJson);
            PersistentInvenStruct invenStruct = JsonUtility.FromJson<PersistentInvenStruct>(inventoryJson);
            persistentInventory = invenStruct.persistentInventory;
        }

        foreach (var invItem in persistentInventory)
        {
            inventorySystem.AddToInventory(invItem, 1);
        }
    }

    void SavePerInventoryToJson()
    {
        PersistentInvenStruct invenStruct = new PersistentInvenStruct();
        invenStruct.persistentInventory = persistentInventory;
        string inventoryJson = JsonUtility.ToJson(invenStruct);
        
        Debug.Log(inventoryJson);
        
        PlayerPrefs.SetString("inventoryJson", inventoryJson);
        PlayerPrefs.Save();
    }

    void UpdatePerstInventory(InventorySlot invenSlot)
    {
        while (persistentInventory.Remove(invenSlot.ItemData)) {}
        
        for (int i = 0; i < invenSlot.StackSize; ++i)
        {
            persistentInventory.Add(invenSlot.ItemData);
        }
        
        SavePerInventoryToJson();
    }
}
