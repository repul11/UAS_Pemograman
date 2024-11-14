using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CALCULATED : MonoBehaviour
{
    public List<GameObject> itemObjects; // Daftar barang yang mungkin ada di scene
    public GameObject targetObject; // Objek target yang harus ditemui
    public GameObject PapanSkorObject;    // Nama scene berikutnya yang akan dimuat

    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    private void Start()
    {
        PapanSkorObject.SetActive(false );

        // Memastikan hanya barang yang aktif di scene yang akan diperiksa
        foreach (var item in itemObjects)
        {
            if (item.activeSelf)
            {
                collectedItems.Add(item);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("APa");
        // Memeriksa apakah item yang aktif bertabrakan dengan target
        if (collectedItems.Contains(other.gameObject))
        {
            collectedItems.Remove(other.gameObject); // Menghapus item dari daftar
            Debug.Log("Item bertemu dengan target: " + other.gameObject.name);

            // Cek apakah semua item sudah bertemu dengan target
            if (collectedItems.Count == 0)
            {
                LoadNextScene();
            }
        }
    }

    // Fungsi untuk memuat scene berikutnya
    private void LoadNextScene()
    {
        Debug.Log("Semua barang sudah bertemu dengan target. Memuat scene berikutnya...");
        PapanSkorObject.SetActive(true);
        //SceneManager.LoadScene(nextSceneName);
    }
}