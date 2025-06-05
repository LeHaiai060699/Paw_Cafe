using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StaffPopupManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject staffItemPrefab;      // Prefab 1 staff
    public Transform contentGrid;           // Grid/Content trong ScrollView

    public Button btnWaiter;
    public Button btnChef;
    public Button btnCashier;
    public Button btnGreeter;

    [Header("Staff Data")]
    public List<StaffData> allStaffs = new List<StaffData>();  // Danh sách staff

    // Class mô tả thông tin Staff
    [System.Serializable]
    public class StaffData
    {
        public string staffName;
        public Sprite avatar;
        public int level;
        public string category;
        public StaffStatus status; // Enum trạng thái
    }

    public enum StaffStatus
    {
        Idle,
        Working,
        Resting,
        Locked
    }

    void OnEnable() // Khi bật Popup, load staff
    {
        LoadStaffList();
    }
    void Start()
    {
        btnWaiter.onClick.AddListener(() => FilterByCategory("Waiter"));
        btnChef.onClick.AddListener(() => FilterByCategory("Chef"));
        btnCashier.onClick.AddListener(() => FilterByCategory("Cashier"));
        btnGreeter.onClick.AddListener(() => FilterByCategory("Greeter"));

        // Khi bật Popup, mặc định load Waiter
        FilterByCategory("Waiter");
    }
    void Awake()
    {
        allStaffs = new List<StaffData>()
        {
            new StaffData()
            {
                staffName = "Deer",
                avatar = Resources.Load<Sprite>("Staffs/staff_deer"),
                level = 3,
                status = StaffStatus.Working,
                category = "Waiter"
            },
            new StaffData()
            {
                staffName = "Duck",
                avatar = Resources.Load<Sprite>("Staffs/staff_duck"),
                level = 2,
                status = StaffStatus.Resting,
                category = "Waiter"
            },
            new StaffData()
            {
                staffName = "?",
                avatar = Resources.Load<Sprite>("Staffs/staff_lock"),
                level = 1,
                status = StaffStatus.Locked,
                category = "Waiter"
            },
        };
    }
    void LoadStaffList()
    {
        // Xóa sạch item cũ trước
        foreach (Transform child in contentGrid)
        {
            Destroy(child.gameObject);
        }

        // Tạo mới các Staff Item
        foreach (var staff in allStaffs)
        {
            GameObject item = Instantiate(staffItemPrefab, contentGrid);

            // Set Icon_Image
            item.transform.Find("Icon_Image").GetComponent<Image>().sprite = staff.avatar;

            // Set Name
            item.transform.Find("Name").GetComponent<TMP_Text>().text = staff.staffName;

            // Set Level
            item.transform.Find("Level").GetComponent<TMP_Text>().text = "Lv " + staff.level;

            // Set status text và đổi màu nếu muốn
            var statusText = item.transform.Find("Status").GetComponent<TMP_Text>();
            switch (staff.status)
            {
                case StaffStatus.Idle:
                    statusText.text = "Idle";
                    statusText.color = Color.gray;
                    break;
                case StaffStatus.Working:
                    statusText.text = "Working";
                    statusText.color = new Color(0.2f, 0.7f, 0.2f); // Màu xanh lá nhạt
                    break;
                case StaffStatus.Resting:
                    statusText.text = "Resting";
                    statusText.color = new Color(0.2f, 0.5f, 1.0f); // Màu xanh dương nhạt
                    break;
                case StaffStatus.Locked:
                    statusText.text = "Locked";
                    statusText.color = Color.black;
                    break;
            }
        }
    }
    void FilterByCategory(string category)
    {
        // Xóa hết item cũ
        foreach (Transform child in contentGrid)
        {
            Destroy(child.gameObject);
        }
        // Tạo mới item theo đúng category
        foreach (var staff in allStaffs)
        {
        if (staff.category != category) continue; // 🛑 chỉ lấy staff đúng loại

        GameObject item = Instantiate(staffItemPrefab, contentGrid);

        // Set Icon_Image
        item.transform.Find("Icon_Image").GetComponent<Image>().sprite = staff.avatar;

        // Set Name
        item.transform.Find("Name").GetComponent<TMP_Text>().text = staff.staffName;

        // Set Level
        item.transform.Find("Level").GetComponent<TMP_Text>().text = "Lv " + staff.level;

        // Set status text
        var statusText = item.transform.Find("Status").GetComponent<TMP_Text>();
        switch (staff.status)
            {
                case StaffStatus.Idle:
                    statusText.text = "Idle";
                    statusText.color = Color.gray;
                    break;
                case StaffStatus.Working:
                    statusText.text = "Working";
                    statusText.color = new Color(0.2f, 0.7f, 0.2f); // Xanh lá nhạt
                    break;
                case StaffStatus.Resting:
                    statusText.text = "Resting";
                    statusText.color = new Color(0.2f, 0.5f, 1.0f); // Xanh dương nhạt
                    break;
                case StaffStatus.Locked:
                    statusText.text = "Locked";
                    statusText.color = Color.black;
                    break;
            }
        }
    }
}
