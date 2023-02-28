using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanSitAndBag : MonoBehaviour
{
    public float high=0.86f;
    WomanFollow womanScript;
    public Vector3 move;
    WomanAnimation womanAnimation;
    Collider colliderCylinder;
    StairScript levelEndSystem;
    WomanWasDropped womanWasDropped;

    GameObject womanizerMan;
    GameObject CylinderObject;

    
    void Start()
    {
        transform.eulerAngles = new Vector3(-180, 0, 180);
        womanAnimation = transform.GetComponent<WomanAnimation>();
        womanScript = transform.GetComponent<WomanFollow>();
        womanizerMan = GameObject.Find("WomanizerNewMan");
        levelEndSystem = womanizerMan.GetComponent<StairScript>();
        womanWasDropped = womanizerMan.GetComponent<WomanWasDropped>();
        CylinderObject = transform.parent.gameObject;
        colliderCylinder = CylinderObject.GetComponent<BoxCollider>();
    }


    public void womanUp()
    {
        womanAnimation.takeMoney();
        transform.position+=Vector3.up*high;
    }

    IEnumerator happyWoman()
    {
        womanAnimation.getEvolve();
        colliderCylinder.isTrigger = true;
        levelEndSystem.CountOfWomanUp(transform.gameObject);
        womanWasDropped.womanDropped();

        yield return new WaitForSeconds(1.05f);

        CylinderObject = transform.parent.gameObject;
        transform.parent = null;
        CylinderObject.SetActive(false);
        womanScript.FollowerOn();
    }

    public void bagTakenFromWoman()
    {
        StartCoroutine(happyWoman());
    }

    
}
