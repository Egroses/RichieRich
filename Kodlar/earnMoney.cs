using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class earnMoney : MonoBehaviour
{   
    [SerializeField]
    GameObject objectOfAmount;
    [SerializeField]
    TextMeshProUGUI amountOfMoney;
    int amount;
    private void Start()
    {
        amount = 0;
        amountOfMoney.text = amount+"";
        objectOfAmount.SetActive(false);
    }

    public void earnMoneySet()
    {
        objectOfAmount.SetActive(true);
        amount += 100;
        amountOfMoney.text = amount + "";
    }

}
