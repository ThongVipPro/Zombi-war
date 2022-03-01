using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoinControl : MonoBehaviour
{
    static Text MoneyCount;
    static int amount;

    // Start is called before the first frame update
    void Start()
    {
        MoneyCount = GameObject.FindGameObjectWithTag("MoneyCount").GetComponent<Text>();
        MoneyCount.text = amount.ToString();
        EventManager.AddCoinPickupEventListener(SetMoney);
    }

    // Update is called once per frame
    void Update() { }

    public void SetMoney(int money)
    {
        amount = money;
        MoneyCount.text = amount.ToString();
    }
}
