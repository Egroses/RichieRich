using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyEffectRandomJump : MonoBehaviour
{
    float farOfLocation = 3f;

    public void dropMoney(GameObject go)
    {
        float xLocation = Random.Range(-farOfLocation, farOfLocation);
        float yLocation = 0f;
        float zLocation = 0f;

        Vector3 randomLocation = new Vector3(xLocation, yLocation, zLocation);

        go.transform.DOJump(go.transform.position + randomLocation, 1f, 0, 0.5f, false);
    }
}
