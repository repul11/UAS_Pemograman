using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Kacang,
        Ayam,
        Cabe,
        Kecap,
        Gula
    }

    public ItemType itemType;
    public int amount;

    // Mengatur tipe dan jumlah item
    public Item(ItemType itemType, int amount)
    {
        this.itemType = itemType;
        this.amount = amount;
    }
}
