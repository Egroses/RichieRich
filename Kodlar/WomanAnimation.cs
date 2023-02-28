using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanAnimation : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void takeMoney()
    {
        anim.SetTrigger("moneyPlus");
    }

    public void getEvolve()
    {
        anim.SetTrigger("evolveOn");
    }

    public void setFollowOn()
    {
        anim.SetTrigger("followOn");
    }
    
    public void danceWoman()
    {
        anim.SetTrigger("danceWoman");
    }
}
