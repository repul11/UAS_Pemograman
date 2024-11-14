using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Scoremanager : MonoBehaviour
{
    public Text scoreText; // Referensi ke UI Text untuk menampilkan skor
    private int totalScore;

    // Nilai poin per jenis item
    private Dictionary<Item.ItemType, int> itemValues = new Dictionary<Item.ItemType, int>
    {
        { Item.ItemType.Kacang, 20 },
        { Item.ItemType.Ayam, 20 },
        { Item.ItemType.Cabe, 20 },
        { Item.ItemType.Kecap, 20 },
        { Item.ItemType.Gula, 20 },
        { Item.ItemType.Kemangi, 20 },
        { Item.ItemType.Kunyit, 20 },
        { Item.ItemType.Jahe, 20 },
        { Item.ItemType.Garam, 20 }

    };

    private void Start()
    {

        CalculateScore();
        UpdateScoreText();
    }

    // Menghitung skor total berdasarkan jumlah dan nilai setiap item
    private void CalculateScore()
    {
        totalScore = 0;

        foreach (var item in itemValues)
        {
            if (Inventory.Instance.HasItem(item.Key))
            {
                int itemAmount = Inventory.Instance.GetItemAmount(item.Key);
                totalScore += itemAmount * item.Value; // Menghitung nilai item berdasarkan jumlah dan nilainya
            }
        }
    }

    // Memperbarui teks skor di UI
    private void UpdateScoreText()
    {
        scoreText.text = " " + totalScore;
    }
}