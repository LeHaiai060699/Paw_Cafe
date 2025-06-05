using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildPopupManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject categoryBlockPrefab;
    public GameObject buildItemPrefab;
    public Transform contentGrid;

    public Button btnLobby;
    public Button btnKitchen;
    public Button btnOutside;

    [Header("Build Data")]
    public List<BuildCategoryData> allBuildCategories = new List<BuildCategoryData>();

    [System.Serializable]
    public class BuildCategoryData 
    {
        public string categoryName; // "Table 1, "Second Counter"
        public string tabType; // Tabs
        public List<BuildItemData> items; // iteamtable_01....
    }
    public class BuildItemData
    {
        public string itemName;
        public Sprite icon;
        public int price;
        public bool unlocked;
        public bool inUse;
        public string category; // Lobby / Kitchen / Outside
    }
    void Start()
    {
        btnLobby.onClick.AddListener(() => FilterByTab("Lobby"));
        btnKitchen.onClick.AddListener(() => FilterByTab("Kitchen"));
        btnOutside.onClick.AddListener(() => FilterByTab("Outside"));

        FilterByTab("Lobby"); // Mặc định load Lobby
    }

    void FilterByTab(string tabType)
    {
        // Clear hết các CategoryBlock cũ
        foreach (Transform child in contentGrid)
        {
            Destroy(child.gameObject);
        }

        // Tạo các CategoryBlock mới theo tab
        foreach (var category in allBuildCategories)
        {
            if (category.tabType != tabType) continue;
            
            // Instantiate CategoryBlock
            GameObject block = Instantiate(categoryBlockPrefab, contentGrid);

            // Set Title
            TMP_Text titleText = block.transform.Find("TitleText").GetComponent<TMP_Text>();
            titleText.text = category.categoryName;

            // ScrollView Horizontal Content
            Transform horizontalContent = block.transform.Find("ScrollView/Viewport/Content");

            // Instantiate từng BuildItem trong Category
            foreach (var item in category.items)
            {
                GameObject itemObj = Instantiate(buildItemPrefab, horizontalContent);

                //Set Icon
                itemObj.transform.Find("Icon_Image").GetComponent<Image>().sprite = item.icon;
                if (item.unlocked)
                {
                    if (item.inUse)
                    {
                        // Đang sử dụng
                        itemObj.transform.Find("InUseText").gameObject.SetActive(true);
                        itemObj.transform.Find("PriceGroup").gameObject.SetActive(false);
                        itemObj.transform.Find("Lock_Icon").gameObject.SetActive(false);
                    }
                    else
                    {
                        // Chưa sử dụng nhưng đã mở
                        itemObj.transform.Find("InUseText").gameObject.SetActive(false);
                        itemObj.transform.Find("PriceGroup").gameObject.SetActive(true);
                        itemObj.transform.Find("Lock_Icon").gameObject.SetActive(false);

                        // Price
                        itemObj.transform.Find("PriceGroup/PriceText").GetComponent<TMP_Text>();
                    }
                }
                else
                {
                    // Khoá
                    itemObj.transform.Find("InUseText").gameObject.SetActive(false);
                    itemObj.transform.Find("PriceGroup").gameObject.SetActive(false);
                    itemObj.transform.Find("Lock_Icon").gameObject.SetActive(true);
                }
            }
        }
    }
    void Awake()
    {
        allBuildCategories = new List<BuildCategoryData>()
        {
            new BuildCategoryData()
            {
                categoryName = "Table 1",
                tabType = "Lobby",
                items = new List<BuildItemData>()
                {
                new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_0"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_1"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_2"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_3"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_4"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    }
                }
            },

            new BuildCategoryData()
            {
                categoryName = "Table 2",
                tabType = "Lobby",
                items = new List<BuildItemData>()
                {
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_0"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_1"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_2"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_3"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Table/table_4"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    }
                }
            },

            new BuildCategoryData()
            {

                categoryName = "Second Counter",
                tabType = "Lobby",
                items = new List<BuildItemData>()
                {
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Counter/countertable_0"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Counter/countertable_1"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Counter/countertable_2"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Counter/countertable_3"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    },
                    new BuildItemData()
                    {
                        itemName = "Normal Table",
                        icon = Resources.Load<Sprite>("Builds/Ingame_1/Counter/countertable_4"),
                        price = 3500,
                        unlocked = true,
                        inUse = true
                    }
                }
            }
        };
    }
}
