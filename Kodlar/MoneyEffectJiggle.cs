using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyEffectJiggle : MonoBehaviour
{
    CollectMoney collectMoney;
    List<GameObject> moneyPool = new List<GameObject>();

    Vector3 punch = new Vector3(1f, 1f, 1f);
    private void Start()
    {
        collectMoney = transform.GetComponent<CollectMoney>();
        moneyPool = collectMoney.moneyPool;
    }

    public void startJiggleEffect()
    {
        StartCoroutine(scaleSpecialEffect());
    }

    IEnumerator scaleSpecialEffect()
    {
        for (int i = 0; i < moneyPool.Count; i++)
        {
            moneyPool[i].transform.DOComplete();
            if (moneyPool[i].transform.localScale == Vector3.one)
                moneyPool[i].transform.DOPunchScale(punch, .3f, 1, 0);
            else
            {
                moneyPool[i].transform.localScale = punch;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}
