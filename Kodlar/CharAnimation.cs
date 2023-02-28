using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    Animator playerAnimator;
    void Start()
    {
        playerAnimator = transform.GetComponent<Animator>();
    }

    public void DanceWithMan()
    {
        playerAnimator.SetTrigger("danceMan");
    }

    public void idleWithMan()
    {
        playerAnimator.SetTrigger("idleMan");
    }

    public void flirtyWithMan()
    {
        playerAnimator.SetTrigger("flirty");
    }
    public void womanizerWithMan()
    {
        playerAnimator.SetTrigger("womanizer");
    }
    public void masterWithMan()
    {
        playerAnimator.SetTrigger("master");
    }

}
