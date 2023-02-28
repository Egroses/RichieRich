using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WomanWasDropped : MonoBehaviour
{
    [SerializeField]
    Image fillOfImage;
    [SerializeField]
    TextMeshProUGUI situation;
    CharAnimation charAnimation;
    Color colorNow;
    void Start()
    {
        charAnimation = transform.GetComponent<CharAnimation>();
    }

    public void womanDropped()
    {
        fillOfImage.fillAmount += 0.2f;

        if (fillOfImage.fillAmount == 0.2f)
        {
            situation.text = "STAG";
        }
        else if (fillOfImage.fillAmount == 0.4f)
        {
            colorNow= Color.Lerp(Color.red, Color.yellow, 0.8f);
            fillOfImage.color = colorNow;
            situation.color = colorNow;
            charAnimation.flirtyWithMan();
            situation.text = "FLIRTY";
        }
        else if (fillOfImage.fillAmount == 0.6f)
        {
            colorNow = Color.Lerp(Color.red, Color.green, 0.8f);
            fillOfImage.color = colorNow;
            situation.color = colorNow;
            situation.text = "PLAYBOY";
        }
        else if (fillOfImage.fillAmount == 0.8f)
        {
            colorNow = Color.Lerp(Color.red, Color.blue, 0.6f);
            fillOfImage.color = colorNow;
            situation.color = colorNow;
            charAnimation.womanizerWithMan();
            situation.text = "WOMANIZER";
        }
        else if (fillOfImage.fillAmount == 1f)
        {
            colorNow = Color.Lerp(Color.red, Color.blue, 1f);
            fillOfImage.color = colorNow;
            situation.color = colorNow;
            charAnimation.masterWithMan();
            situation.text = "GOAT";
        }
    }
}
