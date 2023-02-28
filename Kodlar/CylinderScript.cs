using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CylinderScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Vector3 move;
    public int limit;
    public float high;

    [SerializeField]
    GameObject CylendirObject;
    GameObject moneyTowerObject;
    CollectMoney collectMoney;
    WomanSitAndBag womanSitAndBag;
    ObjectPoolingScript objectPoolingScript;
    CylinderBlendAnim cylinderBlendAnim;

    void Start()
    {
        move = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        limit = Random.Range(3,7);
        text.text = limit * 100 + "";
        high = 1.360f;
        CylendirObject.transform.position += (Vector3.up * 0.86f) * (limit-4);
        cylinderBlendAnim = transform.GetComponent<CylinderBlendAnim>();
        womanSitAndBag = transform.Find("WomanizerGirlRigged").GetComponent<WomanSitAndBag>();
        collectMoney = GameObject.Find("WomanizerNewMan").GetComponent<CollectMoney>();
        objectPoolingScript = GameObject.Find("GameManagerObject").GetComponent<ObjectPoolingScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (limit > 0)
            if (other.tag == "Taken")
            {
                cylinderBlendAnim.MouthOn();
                other.tag = "Untagged";
                MoneyIn();
            }
    }

    void MoneyIn()
    {
        limit--;
        moneyTower();
        womanSitAndBag.womanUp();
        moneyPop();
    }

    void moneyTower()
    {
        move.y += high;
        moneyTowerObject =objectPoolingScript.getPooledObject();
        moneyTowerObject.SetActive(true);
        moneyTowerObject.tag = "Untagged";
        moneyTowerObject.transform.position = move;
        moneyTowerObject.transform.SetParent(transform);
        high = 0.860f;
    }

    

    void moneyPop()
    {
        collectMoney.popMoney();
        collectMoney.setAllMoneyTaken();
    }
}
