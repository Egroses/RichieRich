using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTaken : MonoBehaviour
{
    ManageGameScript manageGameScript;
    WomanSitAndBag womanSitAndBag;
    Vector3 bagPosition = new Vector3(-0.15f, 1.675f, -0.1f);
    Vector3 bagAngle = new Vector3(291.663f, 134.966f, -134.956f);
    void Start()
    {
        manageGameScript = GameObject.Find("GameManagerObject").GetComponent<ManageGameScript>();
        womanSitAndBag = transform.parent.GetComponent<WomanSitAndBag>();
    }
    private void Update()
    {
        if (manageGameScript.isFinish())
            bagActiveFalse();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bag")
        {
            takeBagForWoman(other.gameObject);
            womanSitAndBag.bagTakenFromWoman();
        }
    }

    void takeBagForWoman(GameObject go)
    {
        go.tag = "Untagged";
        
        go.transform.localScale = Vector3.one * 0.5f;
        go.transform.position = transform.position+ bagPosition;
        go.transform.eulerAngles = bagAngle;
        go.transform.SetParent(transform);
    }

    public void bagActiveFalse()
    {
        try
        {
            transform.Find("bag").gameObject.SetActive(false);
        }catch
        {
        }
       
    }
}
