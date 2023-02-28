using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameScript : MonoBehaviour
{
    bool finish=false;

    public bool isFinish()
    {
        return finish;
    }

    public bool setFinish()
    {
        return finish = true;
    }

}
