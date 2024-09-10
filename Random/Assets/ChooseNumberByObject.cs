using UnityEngine;
using TMPro; // สำหรับ TextMeshPro

public class ChooseNumberByObject : MonoBehaviour
{
    public GameObject objectZero; // วัตถุสำหรับเลือก 0
    public GameObject objectOne;  // วัตถุสำหรับเลือก 1
    public TMP_Text resultText;   // ช่องสำหรับแสดงผลลัพธ์ที่เลือก (TextMeshPro)

    void Update()
    {
        // ตรวจสอบการคลิกซ้ายของเมาส์
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ยิง ray จากตำแหน่งเมาส์
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // ตรวจสอบว่าชนวัตถุใด
            {
                // ถ้าคลิกที่วัตถุ "Zero"
                if (hit.collider.gameObject == objectZero)
                {
                    OnObjectClick(0); // เรียกฟังก์ชันคลิกสำหรับเลข 0
                }
                // ถ้าคลิกที่วัตถุ "One"
                else if (hit.collider.gameObject == objectOne)
                {
                    OnObjectClick(1); // เรียกฟังก์ชันคลิกสำหรับเลข 1
                }
            }
        }
    }

    void OnObjectClick(int number)
    {
        // แสดงตัวเลขที่เลือกใน TextMeshPro
        resultText.text = "Select: " + number;

        // หรือแสดงใน Console
        Debug.Log("Select: " + number);
    }
}
