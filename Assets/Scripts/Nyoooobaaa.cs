using UnityEngine;

public class PUQIMAY : MonoBehaviour
{
    public GameObject kacangObject;
    public GameObject kecapObject;
    public GameObject cabeObject;
    public GameObject gulaObject;
    public GameObject ayamObject;

    private void Start()
    {
        if (Inventory.Instance.HasItem(Item.ItemType.Kacang))
        {
            kacangObject.SetActive(true); 
            Debug.Log("Kacang tersedia di scene ini dengan jumlah: " + Inventory.Instance.GetItemAmount(Item.ItemType.Kacang));
        }
        else
        {
            kacangObject.SetActive(false); 
        }


        if (Inventory.Instance.HasItem(Item.ItemType.Kecap))
        {
            kecapObject.SetActive(true); 
            Debug.Log("Kecap tersedia di scene ini dengan jumlah: " + Inventory.Instance.GetItemAmount(Item.ItemType.Kecap));
        }
        else
        {
            kecapObject.SetActive(false); 
        }


        if (Inventory.Instance.HasItem(Item.ItemType.Cabe))
        {
            cabeObject.SetActive(true); 
            Debug.Log("Ca tersedia di scene ini dengan jumlah: " + Inventory.Instance.GetItemAmount(Item.ItemType.Cabe));
        }
        else
        {
            cabeObject.SetActive(false); 
        }
        

        if (Inventory.Instance.HasItem(Item.ItemType.Ayam))
        {
            ayamObject.SetActive(true); 
            Debug.Log("Kacang tersedia di scene ini dengan jumlah: " + Inventory.Instance.GetItemAmount(Item.ItemType.Ayam));
        }
        else
        {
            ayamObject.SetActive(false); 
        }

        if (Inventory.Instance.HasItem(Item.ItemType.Gula))
        {
            gulaObject.SetActive(true);
            Debug.Log("Kacang tersedia di scene ini dengan jumlah: " + Inventory.Instance.GetItemAmount(Item.ItemType.Gula));
        }
        else
        {
            gulaObject.SetActive(false);
        }
    }
}
