using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance; // Singleton untuk akses global
    private Dictionary<Item.ItemType, int> itemDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Membawa Inventory ke scene berikutnya
            itemDictionary = new Dictionary<Item.ItemType, int>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Menambah item ke inventory
    public void AddItem(Item.ItemType itemType, int amount)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            itemDictionary[itemType] += amount;
        }
        else
        {
            itemDictionary[itemType] = amount;
        }
        Debug.Log("Item Ditambahkan: " + itemType + " | Jumlah: " + itemDictionary[itemType]);
    }

    // Mendapatkan jumlah item
    public int GetItemAmount(Item.ItemType itemType)
    {
        if (itemDictionary.ContainsKey(itemType))
        {
            return itemDictionary[itemType];
        }
        return 0;
    }

    // Cek apakah item ada di inventory
    public bool HasItem(Item.ItemType itemType)
    {
        return itemDictionary.ContainsKey(itemType) && itemDictionary[itemType] > 0;
    }

    // Contoh pengambilan data item untuk digunakan di scene berikutnya
    public Dictionary<Item.ItemType, int> GetAllItems()
    {
        return itemDictionary;
    }
}
