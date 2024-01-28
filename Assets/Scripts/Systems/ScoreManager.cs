using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Score
    float score = 0;
    float rango = 0;

    //Audience Bar
    float maxAudienceAmount;
    float pastAudienceAmount;

    public static Action happyAudience;
    public static Action angryAudience;
    public static Action tomatoLaunch;

    [SerializeField] Image AudienceBar;

    void calculatescore(float[] distancia)
    {
        for (int i = 0; i < 8; i++)
        {
            //Primer if es perfecto, segundo if rango mas un poco hacia arriba y tercer if un poco hacia abajo
            if (distancia[i] == 0)
            {
                score += 100;
            }
            else if (distancia[i] < rango)
            {
                score += 50;
            }
            else if (distancia[i] > rango)
            {

                score += 0;
            }
        }

        SetAudienceBar(score);
    }

    void SetAudienceBar(float audienceAmount)
    {
        pastAudienceAmount += audienceAmount;

        float fillAmount = audienceAmount / maxAudienceAmount;
        AudienceBar.fillAmount = fillAmount;

        pastAudienceAmount = audienceAmount;
    }
}