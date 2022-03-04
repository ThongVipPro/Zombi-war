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

    GameObject item;

    [SerializeField]int money;

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
            shopItem.owned = true;
        }
    }

    // Change this method's name so that it will be called in GameController.Update() instead.
    public void HandleUpdate()
    {
        foreach (ShopItems shopItem in shopItems)
        {
            if (shopItem.owned)
            {
                shopItem.itemRef.SetActive(false);
            }
            else
            {
                shopItem.itemRef.SetActive(true);
            }
        }
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
    public string name;
    public int cost;
    public Sprite image;

    [HideInInspector]
    public bool owned;

    [HideInInspector]
    public GameObject itemRef;
}
