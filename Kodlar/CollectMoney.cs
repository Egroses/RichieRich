using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectMoney : MonoBehaviour
{
    [SerializeField] 
    public List<GameObject> moneyPool = new List<GameObject>();
  
    [SerializeField]
    Vector3 angleMoneyF = new Vector3(90, 0, 0);
    Vector3 angleMoneyL = new Vector3(0f, 0f, 135f);

    MoneyEffectRandomJump moneyEffectRandomJump;
    MoneyEffectJiggle moneyEffectJiggle;

    int cut=-1;

    private void Start()
    {
        DOTween.Init();
        moneyEffectRandomJump = transform.GetComponent<MoneyEffectRandomJump>();
        moneyEffectJiggle = transform.GetComponent<MoneyEffectJiggle>();
    }

    public void pushMoney(GameObject go)
    {
        go.tag = "Taken";
        go.transform.eulerAngles = angleMoneyF;
        moneyPool.Add(go.gameObject);

        moneyEffectJiggle.startJiggleEffect();
    }

    public void popMoney()
    {
        moneyPool[moneyPool.Count-1].SetActive(false);
        moneyPool[moneyPool.Count-1].transform.parent = null;
        moneyPool.RemoveAt(moneyPool.Count-1);
    }

    public void setAllMoneyTaken()
    {
        for (int i = 1; i < moneyPool.Count; i++)
        {
            moneyPool[i].tag = "Taken";
        }
    }  

    public void clearListAll()
    {
        for (int i = moneyPool.Count; i > 0; i--)
        {
            moneyPool[i-1].SetActive(false);
            moneyPool[i-1].transform.parent = null;
            moneyPool.RemoveAt(i-1);
        }
    }

    public void cutMoneyList()
    {
        cut = moneyPool.Count;
        for (int i = 0; i < moneyPool.Count; i++)
        {
            if (moneyPool[i].tag.Equals("Collectiable"))
            {
                cut = i;
                break;
            }
        }
        for (int i = moneyPool.Count; i > cut;i--)
        {
            moneyEffectRandomJump.dropMoney(moneyPool[i-1]);
            moneyPool[i - 1].tag = "Collectiable";
            moneyPool[i - 1].transform.eulerAngles = angleMoneyL;
            moneyPool.RemoveAt(i - 1);
        }
    }
}
