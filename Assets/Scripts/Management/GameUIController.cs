using UnityEngine;
// Cần thêm dòng này nếu bạn dùng UI.Text
using UnityEngine.UI; 
// Cần thêm dòng này nếu bạn dùng TextMeshPro
// using TMPro; 

public class GameUIController : MonoBehaviour
{
    // Kéo thả đối tượng Text từ Inspector vào đây
    public Text enemyCountText; 
    public Text rubbyCountText;
    
    // Nếu dùng TextMeshPro, thay đổi kiểu dữ liệu thành:
    // public TMPro.TextMeshProUGUI enemyCountText;
    // public TMPro.TextMeshProUGUI rubbyCountText;

    private int currentEnemies = 0;
    private int currentRubby = 0;
    
    // --- KHỞI TẠO BAN ĐẦU ---
    void Start()
    {
        // Khởi tạo hiển thị ban đầu
        UpdateEnemyCountUI();
        UpdateRubbyCountUI();
    }

    // --- CÁC HÀM CẬP NHẬT GIAO DIỆN ---
    
    // Hàm này dùng để cập nhật số quái
    private void UpdateEnemyCountUI()
    {
        // Hiển thị text: "Enemy: [số hiện tại]"
        enemyCountText.text = "Enemy: " + currentEnemies.ToString(); 
    }

    // Hàm này dùng để cập nhật điểm Rubby
    private void UpdateRubbyCountUI()
    {
        // Hiển thị text: "RUBBY: [số hiện tại]"
        rubbyCountText.text = "RUBBY: " + currentRubby.ToString();
    }
    
    // --- CÁC HÀM ĐỂ GỌI KHI CÓ SỰ KIỆN ---

    // Gọi hàm này khi quái vật bị tiêu diệt
    public void EnemyKilled()
    {
        currentEnemies++; // Tăng số đếm
        UpdateEnemyCountUI(); // Cập nhật Text UI
    }

    // Gọi hàm này khi người chơi nhặt được điểm Rubby
    public void AddRubby(int amount)
    {
        currentRubby += amount; // Cộng điểm
        UpdateRubbyCountUI(); // Cập nhật Text UI
    }
}