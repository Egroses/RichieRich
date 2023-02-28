using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyTouchMoney: MonoBehaviour
{
    CollectMoney collectMoney = new CollectMoney();
    earnMoney earn;
    private void Start()
    {
        collectMoney = GameObject.Find("WomanizerNewMan").GetComponent<CollectMoney>();
        earn = GameObject.Find("GameManagerObject").GetComponent<earnMoney>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectiable")
        {
            TouchOtherMoney(other.gameObject);
        }
        if(other.tag == "DontTouch")
        {
            TouchCylinder(other.gameObject);
        }
        if (other.name == "finish")
        {
            TouchFinish(other.gameObject);
        }
    }

    void TouchOtherMoney(GameObject other)
    {
        collectMoney.pushMoney(other.gameObject);
    }

    void TouchCylinder(GameObject other)
    {
        transform.tag = "Collectiable";
        for (int i = 0; i < collectMoney.moneyPool.Count; i++)
        {
            if (collectMoney.moneyPool[i].tag == "Collectiable")
            {
                transform.tag = "Taken";
                if (i + 1 < collectMoney.moneyPool.Count)
                    collectMoney.moneyPool[i + 1].tag = "Collectiable";
            }
        }
        collectMoney.cutMoneyList();
    }

    void TouchFinish(GameObject other)
    {
        transform.tag = "Collectiable";
        collectMoney.cutMoneyList();
        transform.tag = "Untagged";
        earn.earnMoneySet();
        transform.gameObject.SetActive(false);
    }
}
