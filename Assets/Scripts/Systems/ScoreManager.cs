using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Score
    [SerializeField]float score = 0;
    float range = 1.0f;

    //Audience Bar
    float maxAudienceAmount;
    float pastAudienceAmount;

    public static Action happyAudience;
    public static Action angryAudience;
    public static Action tomatoLaunch;

    [SerializeField] Image AudienceBar;

    public void calculatescore(float[] distances)
    {
        for (int i = 0; i < distances.Length; i++)
        {
            //Primer if es perfecto, segundo if rango mas un poco hacia arriba y tercer if un poco hacia abajo
            if (distances[i] == 0)
            {
                score += 100;
            }
            else if (distances[i] < range)
            {
                score += 50;
            }
            else if (distances[i] > range)
            {

                score += 0;
            }
        }

        //SetAudienceBar(score);
    }

    void SetAudienceBar(float audienceAmount)
    {
        pastAudienceAmount += audienceAmount;

        float fillAmount = audienceAmount / maxAudienceAmount;
        AudienceBar.fillAmount = fillAmount;

        pastAudienceAmount = audienceAmount;
    }
}