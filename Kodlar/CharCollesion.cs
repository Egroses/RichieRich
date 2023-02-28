using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CharCollesion : MonoBehaviour
{
    CollectMoney collectMoney;
    StairScript stairScript;
    ManageGameScript manageGameScript;
    private void Start()
    {
        manageGameScript = GameObject.Find("GameManagerObject").GetComponent<ManageGameScript>();
        collectMoney = transform.GetComponent<CollectMoney>();
        stairScript = transform.GetComponent<StairScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectiable")
        {
            collectMoney.pushMoney(other.gameObject);
        }
        if (other.name == "finish")
        {
            manageGameScript.setFinish();
            stairScript.CoroutineStair();
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="DontTouch")
        {
            Vector3 bounce = other.gameObject.transform.position - transform.position;
            bounce.z = 0 ;
            bounce.y = 0;
            transform.DOMove(transform.position+bounce*-4+Vector3.forward*-3, 1.5f);
            if(collectMoney.moneyPool.Count>0)
                collectMoney.moneyPool[0].tag = "Collectiable";
            collectMoney.cutMoneyList();
        }
    }
}
