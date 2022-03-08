using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PeopleCounter : MonoBehaviour
{
    [SerializeField]
    GameObject counter;
    static Text peopleCount;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = counter.GetComponent<Text>();
        peopleCount.text = number.ToString();
        EventManager.AddPeopleSavedEventListener(SetCounter);
    }

    // Update is called once per frame
    void Update() { }

    public void SetCounter(int people)
    {
        number = people;
        peopleCount.text = number.ToString();
    }
}
