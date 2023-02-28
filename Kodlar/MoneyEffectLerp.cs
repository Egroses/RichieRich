using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEffectLerp : MonoBehaviour
{
    CollectMoney collectMoney;
    List<GameObject> moneyPool = new List<GameObject>();

    Vector3 moneyListVector;
    private void Start()
    {
        collectMoney = transform.GetComponent<CollectMoney>();
        moneyPool = collectMoney.moneyPool;
    }

    private void FixedUpdate()
    {
        moveMoneysWithLerp();
    }

    void moveMoneysWithLerp()
    {
        for (int i = 0; i < moneyPool.Count; i++)
        {
            bool isFirstChild = i == 0 ? true : false;
            if (isFirstChild)
            {
                moneyListVector = transform.position + transform.forward * 2 + Vector3.up * 1.5f;
            }
            else
            {
                moneyListVector = moneyPool[i - 1].transform.position + transform.forward * 1.2f;
            }

            moneyPool[i].transform.position = Vector3.Lerp(moneyPool[i].transform.position, moneyListVector, Time.deltaTime * 15f);
        }
    }
}
