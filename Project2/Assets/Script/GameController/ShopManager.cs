using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    GameObject shopUI;

    [SerializeField]
    CoinControl coinControl;

    [SerializeField]
    ShopItems[] shopItems;

    [SerializeField]
    GameObject itemPrefab;

    [SerializeField]
    Transform shopContent;

    [SerializeField]
    PlayerControl playerControl;

    GameObject item;

    [SerializeField]
    int money;

    [SerializeField]
    int moveSpeedMax;

    public event Action OnOpenShop;
    public event Action OnCloseShop;
    CoinPickupEvent purchaseEvent = new CoinPickupEvent();

    public static ShopManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddPurchaseEventInvoker(this);
        foreach (ShopItems shopItem in shopItems)
        {
            item = Instantiate(itemPrefab, shopContent);
            shopItem.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = shopItem.name;
                }
                else if (child.gameObject.name == "Price")
                {
                    child.gameObject.GetComponent<Text>().text = "$" + shopItem.cost.ToString();
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = shopItem.image;
                }
            }

            item.GetComponent<Button>()
                .onClick.AddListener(
                    () =>
                    {
                        BuyItem(shopItem);
                    }
                );
        }
    }

    public void BuyItem(ShopItems shopItem)
    {
        if (money >= shopItem.cost)
        {
            money -= shopItem.cost;
            purchaseEvent.Invoke(money);
            if (shopItem.type == ItemType.Heal)
            {
                playerControl.UpdateHealth(shopItem.value);
            }
            else if (shopItem.type == ItemType.Speed)
            {
                if (playerControl.moveSpeed + shopItem.value <= moveSpeedMax)
                {
                    playerControl.moveSpeed += shopItem.value;
                }
                else
                {
                    playerControl.moveSpeed = moveSpeedMax;
                }
            }
        }
    }

    // Change this method's name so that it will be called in GameController.Update() instead.
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloseShop();
        }
    }

    public void OpenShop()
    {
        OnOpenShop?.Invoke();
        shopUI.SetActive(true);
        money = coinControl.amount;
    }

    public void CloseShop()
    {
        OnCloseShop?.Invoke();
        shopUI.SetActive(false);
    }

    void UpdatePrice(int money)
    {
        coinControl.amount = money;
    }

    /// <summary>
    /// Add listener for purchase
    /// </summary>
    /// <param name="listener"></param>
    public void AddPurchaseEventListener(UnityAction<int> listener)
    {
        purchaseEvent.AddListener(listener);
    }
}

[System.Serializable]
public class ShopItems
{
    public ItemType type;
    public string name;
    public int cost;
    public Sprite image;
    public int value;

    [HideInInspector]
    public GameObject itemRef;
}

public enum ItemType
{
    Heal,
    Speed
}
