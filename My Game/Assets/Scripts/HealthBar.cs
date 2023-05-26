using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image bar;
    public float fill = 1f;

    void Update()
    {
        Health health = GetComponent<Health>();
         
         if (health.hp == null)
         {
            Destroy(bar);
         }
         else
         {
            fill = health.hp;
            bar.fillAmount = fill;
         }
    }
}
