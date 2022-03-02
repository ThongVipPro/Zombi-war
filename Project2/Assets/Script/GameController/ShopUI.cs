using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    Transform container;

    [SerializeField]
    Transform itemTemplate;

    private void Awake()
    {
        itemTemplate.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
