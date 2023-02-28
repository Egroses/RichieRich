using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StairScript : MonoBehaviour
{
    Vector3 firstStep = new Vector3(0, 2.2f, 105);
    Vector3 secondStep = new Vector3(0, 4.7f, 110);
    Vector3 thirdStep = new Vector3(0, 7.3f, 115);
    List<Vector3> StairListVector = new List<Vector3>();
    List<GameObject> StairListWoman = new List<GameObject>();

    CharAnimation charAnimation;
    CollectMoney collectMoney;
    CameraScript cameraScript;
    
    float sideLocation=4.5f;
    int womanCount;
    void Start()
    {
        cameraScript = GameObject.Find("GameManagerObject").GetComponent<CameraScript>();
        collectMoney = transform.GetComponent<CollectMoney>();
        charAnimation = transform.GetComponent<CharAnimation>();
        womanCount = 0;
        StairListVector.Add(firstStep);
        StairListVector.Add(secondStep);
        StairListVector.Add(thirdStep);
    }

    public void CountOfWomanUp(GameObject go)
    {
        womanCount++;
        StairListWoman.Add(go); 
    }

    public void CoroutineStair()
    {
        StartCoroutine(charWinStair());
    }

    IEnumerator charWinStair()
    {
        cameraScript.endOfGame();
        collectMoney.clearListAll();
        charAnimation.idleWithMan();
        for(int i=0;i<womanCount;i++)
        {
            transform.DOMove(StairListVector[i],0.5f);
            StairListWoman[i].transform.GetComponent<WomanFollow>().FollowerOff();
            StairListWoman[i].transform.DOMove(StairListVector[i] + Vector3.right*sideLocation,0.5f);
            sideLocation *= -1;
            yield return new WaitForSeconds(0.5f);
        }
        charAnimation.DanceWithMan();
    }
}
