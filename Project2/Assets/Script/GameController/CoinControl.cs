using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoinControl : MonoBehaviour
{
    [SerializeField]
    GameObject counter;
    static Text moneyCount;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        moneyCount = counter.GetComponent<Text>();
        moneyCount.text = amount.ToString();
        EventManager.AddCoinPickupEventListener(SetMoney);
        EventManager.AddPurchaseEventListener(SetMoney);
    }

    // Update is called once per frame
    void Update() { }

    public void SetMoney(int money)
    {
        amount = money;
        moneyCount.text = amount.ToString();
    }
}
