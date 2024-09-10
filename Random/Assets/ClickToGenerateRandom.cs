using UnityEngine;
using TMPro; // สำหรับ TextMeshPro
using UnityEngine.UI; // สำหรับ Button

public class ObjectSelector : MonoBehaviour
{
    public GameObject objectZero; // วัตถุสำหรับเลือก 0
    public GameObject objectOne;  // วัตถุสำหรับเลือก 1
    public TMP_Text resultText;   // ช่องสำหรับแสดงผลลัพธ์ที่เลือก (TextMeshPro)
    public Button generateButton; // ปุ่มสำหรับสุ่มตัวเลข

    private GameObject selectedObject; // วัตถุที่ถูกเลือกตามผลสุ่ม

    void Start()
    {
        // กำหนดให้ปุ่มสุ่มตัวเลขเรียกฟังก์ชัน GenerateRandomAndSelect
        generateButton.onClick.AddListener(GenerateRandomAndSelect);
    }

    void Update()
    {
        // ตรวจสอบการคลิกซ้ายของเมาส์
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ยิง ray จากตำแหน่งเมาส์
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // ตรวจสอบว่าชนวัตถุใด
            {
                Debug.Log("คลิกที่วัตถุ: " + hit.collider.gameObject.name);
                // ถ้าคลิกที่วัตถุที่ถูกเลือก
                if (hit.collider.gameObject == selectedObject)
                {
                    Debug.Log("Right!");
                    resultText.text = "Right!";
                }
                else
                {
                    Debug.Log("Wrong!");
                    resultText.text = "Wrong!";
                }
            }
        }
    }

    void GenerateRandomAndSelect()
    {
        // สุ่มตัวเลขระหว่าง 0 และ 1
        int randomNumber = Random.Range(0, 2);

        // เลือกวัตถุตามตัวเลขสุ่ม
        if (randomNumber == 0)
        {
            selectedObject = objectZero;
        }
        else
        {
            selectedObject = objectOne;
        }

        // แสดงผลลัพธ์ใน TextMeshPro
        //resultText.text = "Number: " + randomNumber;

        // แสดงใน Console สำหรับการตรวจสอบ
        Debug.Log("selectedObj: " + selectedObject.name);
    }
}
