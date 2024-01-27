using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float score = 0;
    float rango = 0;


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
    }
}