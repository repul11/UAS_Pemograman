using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // Menghitung offset antara posisi mouse dan posisi objek
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Berikan nilai z yang cukup agar transformasi tetap stabil
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        // Mengubah posisi objek mengikuti posisi mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Sama dengan z di OnMouseDown
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
    }
}
