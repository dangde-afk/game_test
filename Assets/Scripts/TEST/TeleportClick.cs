using UnityEngine;
// hỗ trợ test game bằng click chuột trái.
public class TeleportClick : MonoBehaviour
{   
    public Transform player;
    private bool teleportEnabled = false; 

    void Update()
    {
        // Nhấn phím P để bật/tắt chế độ teleport
        if (Input.GetKeyDown(KeyCode.P))
        {
            teleportEnabled = !teleportEnabled;
            Debug.Log("Teleport mode: " + (teleportEnabled ? "ON" : "OFF"));
        }

        // Nếu teleport đang bật thì click chuột mới có tác dụng
        if (teleportEnabled && Input.GetMouseButtonDown(0)) // click chuột trái
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // giữ nhân vật ở mặt phẳng 2D
            player.position = mousePos;
        }
    }
}
