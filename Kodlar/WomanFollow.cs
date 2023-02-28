using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WomanFollow : MonoBehaviour
{
    GameObject player;
    NavMeshAgent navMesh;
    Vector3 pos;
    WomanAnimation womanAnimation;
    void Start()
    {
        womanAnimation = transform.GetComponent<WomanAnimation>();
        player = GameObject.Find("WomanizerNewMan").gameObject;
        navMesh = GetComponent<NavMeshAgent>();
        pos = new Vector3((float)Random.Range(-10,10)/10, 0, (float)Random.Range(10, 20) / 10);
    }
    

    void FixedUpdate()
    {
        if(navMesh.enabled)
            navMesh.destination = player.transform.position - pos;
    }

    public void FollowerOn()
    {
        navMesh.enabled = true;
    }
    public void FollowerOff()
    {
        womanAnimation.danceWoman();
        navMesh.enabled = false;
    }
}
