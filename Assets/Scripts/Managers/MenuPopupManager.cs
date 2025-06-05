using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuPopupManager : MonoBehaviour
{
    public GameObject menuItemPrefab; // Prefab món ăn
    public Transform contentGrid; // Nơi hiển thị món ăn
    public Button btnCoffee;
    public Button btnDrink;
    public Button btnDessert;
    private int playerLevel => PlayerData.Instance.playerLevel;
     // Class lưu dữ liệu món ăn
    [System.Serializable]
    public class MenuItemData
    {
        public string itemName;   // Tên món ăn
        public Sprite icon;       // Hình ảnh món
        public int stars;         // Số sao đánh giá (1 - 5)
        public bool unlocked;     // Đã mở khóa hay chưa
        public string category;   // Coffee, Drink, Dessert
        public int unlockLevel;  // 🎯 Thêm: Level cần để unlock món
    }
    // Danh sách tất cả món
    public List<MenuItemData> allMenuItems = new List<MenuItemData>();
    void Awake()  // ⬅️ GỌI LOAD NGAY TRONG AWAKE
    {
        LoadMenuData();  
    }
    void Start()
    {
        btnCoffee.onClick.AddListener(() => FilterByCategory("Coffee"));
        btnDrink.onClick.AddListener(() => FilterByCategory("Drink"));
        btnDessert.onClick.AddListener(() => FilterByCategory("Dessert"));

        // Khi bật Popup, mặc định load món Coffee
        FilterByCategory("Coffee");
    }
    // Hàm load dữ liệu món ăn
    void LoadMenuData()
    {
        Sprite testSprite = Resources.Load<Sprite>("Food/Coffee/coffee_00");
        if (testSprite == null)
            Debug.LogError("Sprite coffee_00 not found!");
        else
            Debug.Log("Sprite coffee_00 loaded OK!");
        allMenuItems = new List<MenuItemData>()
        {
            // Coffee
            new MenuItemData()
            {
                itemName = "Coffee00",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_00"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 1
            },
            new MenuItemData()
            {
                itemName = "Coffee01",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_01"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 3
            },
            new MenuItemData()
            {
                itemName = "Coffee02",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_02"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 5
            },
            new MenuItemData()
            {
                itemName = "Coffee03",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_03"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 7
            },
            new MenuItemData()
            {
                itemName = "Coffee04",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_04"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 9
            },
            new MenuItemData()
            {
                itemName = "Coffee05",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_05"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 11
            },
            new MenuItemData()
            {
                itemName = "Coffee06",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_06"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 13
            },
            new MenuItemData()
            {
                itemName = "Coffee07",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_07"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 15
            },
            new MenuItemData()
            {
                itemName = "Coffee08",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_08"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 17
            },
            new MenuItemData()
            {
                itemName = "Coffee09",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_09"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 19
            },
            new MenuItemData()
            {
                itemName = "Coffee10",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_10"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 21
            },
            new MenuItemData()
            {
                itemName = "Coffee11",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_11"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 23
            },
            new MenuItemData()
            {
                itemName = "Coffee12",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_12"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 25
            },
            new MenuItemData()
            {
                itemName = "Coffee13",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_13"),
                stars = 1,
                unlocked = false,
                category = "Coffee",
                unlockLevel = 28
            },
            new MenuItemData()
            {
                itemName = "Coffee14",
                icon = Resources.Load<Sprite>("Food/Coffee/coffee_14"),
                stars = 1,
                unlocked = true,
                category = "Coffee",
                unlockLevel = 32
            },

            // Drink
            new MenuItemData()
            {
                itemName = "Drink00",
                icon = Resources.Load<Sprite>("Food/Drink/drink_00"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 2
            },
            new MenuItemData()
            {
                itemName = "Drink01",
                icon = Resources.Load<Sprite>("Food/Drink/drink_01"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 4
            },
            new MenuItemData()
            {
                itemName = "Drink02",
                icon = Resources.Load<Sprite>("Food/Drink/drink_02"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 6
            },
            new MenuItemData()
            {
                itemName = "Drink03",
                icon = Resources.Load<Sprite>("Food/Drink/drink_03"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 8
            },
            new MenuItemData()
            {
                itemName = "Drink04",
                icon = Resources.Load<Sprite>("Food/Drink/drink_04"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 10
            },
            new MenuItemData()
            {
                itemName = "Drink05",
                icon = Resources.Load<Sprite>("Food/Drink/drink_05"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 13
            },
            new MenuItemData()
            {
                itemName = "Drink06",
                icon = Resources.Load<Sprite>("Food/Drink/drink_06"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 16
            },
            new MenuItemData()
            {
                itemName = "Drink07",
                icon = Resources.Load<Sprite>("Food/Drink/drink_07"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 20
            },
            new MenuItemData()
            {
                itemName = "Drink08",
                icon = Resources.Load<Sprite>("Food/Drink/drink_08"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 24
            },
            new MenuItemData()
            {
                itemName = "Drink09",
                icon = Resources.Load<Sprite>("Food/Drink/drink_09"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 28
            },
            new MenuItemData()
            {
                itemName = "Drink10",
                icon = Resources.Load<Sprite>("Food/Drink/drink_10"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 31
            },
            new MenuItemData()
            {
                itemName = "Drink11",
                icon = Resources.Load<Sprite>("Food/Drink/drink_11"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 33
            },
            new MenuItemData()
            {
                itemName = "Drink12",
                icon = Resources.Load<Sprite>("Food/Drink/drink_12"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 36
            },
            new MenuItemData()
            {
                itemName = "Drink13",
                icon = Resources.Load<Sprite>("Food/Drink/drink_13"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 38
            },
            new MenuItemData()
            {
                itemName = "Drink14",
                icon = Resources.Load<Sprite>("Food/Drink/drink_14"),
                stars = 1,
                unlocked = true,
                category = "Drink",
                unlockLevel = 40
            },

            // Dessert
            new MenuItemData()
            {
                itemName = "Dessert00",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_00"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 3
            },
            new MenuItemData()
            {
                itemName = "Dessert01",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_01"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 6
            },
            new MenuItemData()
            {
                itemName = "Dessert02",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_02"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 9
            },
            new MenuItemData()
            {
                itemName = "Dessert03",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_03"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 12
            },
            new MenuItemData()
            {
                itemName = "Dessert04",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_04"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 15
            },
            new MenuItemData()
            {
                itemName = "Dessert05",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_05"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 18
            },
            new MenuItemData()
            {
                itemName = "Dessert06",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_06"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 21
            },
            new MenuItemData()
            {
                itemName = "Dessert07",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_07"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 25
            },
            new MenuItemData()
            {
                itemName = "Dessert08",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_08"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 29
            },
            new MenuItemData()
            {
                itemName = "Dessert09",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_09"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 33
            },
            new MenuItemData()
            {
                itemName = "Dessert10",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_10"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 36
            },
            new MenuItemData()
            {
                itemName = "Dessert11",
                icon = Resources.Load<Sprite>("Food/Dessert/drink_11"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 39
            },
            new MenuItemData()
            {
                itemName = "Dessert12",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_12"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 42
            },
            new MenuItemData()
            {
                itemName = "Dessert13",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_13"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 45
            },
            new MenuItemData()
            {
                itemName = "Dessert14",
                icon = Resources.Load<Sprite>("Food/Dessert/dessert_14"),
                stars = 1,
                unlocked = true,
                category = "Dessert",
                unlockLevel = 48
            },


            
        };
    }

    // Hàm lọc món theo loại
    void FilterByCategory(string category)
    {
        // Xóa hết item cũ
        foreach (Transform child in contentGrid)
        {
            Destroy(child.gameObject);
        }

        // Tạo mới item theo đúng category
        foreach (var item in allMenuItems)
        {
            if (item.category != category) continue;

            GameObject obj = Instantiate(menuItemPrefab, contentGrid);

            bool isUnlocked = playerLevel >= item.unlockLevel;  // 🎯 So sánh level mở khóa

            // ⭐ Set sao
            FoodStar foodStar = obj.transform.Find("StarGroup").GetComponent<FoodStar>();
            foodStar.UpdateStars(item.stars);

            // 🔒 Lock hoặc mở khoá
            obj.transform.Find("Lock_Icon").gameObject.SetActive(!isUnlocked);

            // 🎯 Set Icon chỉ nếu unlocked
            var iconImage = obj.transform.Find("Icon_Image").GetComponent<Image>();
            iconImage.enabled = isUnlocked;
            if (isUnlocked)
            {
                iconImage.sprite = item.icon;
            }
        }
    }
}
