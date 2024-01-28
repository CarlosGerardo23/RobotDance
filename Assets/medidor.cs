using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class medidor : MonoBehaviour
{
   
    public float maxima = 10f;
    public const float zerom = 1f;
    public Transform punterovelocidad;
    public float speed;
    private bool isgood;
    private bool isbad;
    private void Awake()
    {
        punterovelocidad = transform.Find("puntero");
        speed = 0f;
        maxima = 10f;

    }
    private void OnEnable()
    {
        ScoreManager.happyAudience += goodscore;
        ScoreManager.angryAudience += badscore;
        ScoreManager.tomatoLaunch += tomatoscore;
    }
    private void OnDisable()
    {

        ScoreManager.happyAudience -= goodscore;
        ScoreManager.angryAudience -= badscore;
        ScoreManager.tomatoLaunch -= tomatoscore;
    }
    private void goodscore()
    {
        isgood = true;
    }
     private void badscore()
    {
        isbad = true;
    }
    private void tomatoscore()
    {
        
    }
    void Update()
    {
        punterovelocidad.eulerAngles = new Vector3(0,0, rotacionagu());
        if (isgood )
        {
            float aceleracion = 0.2f;
            speed += aceleracion + Time.deltaTime;
            isgood = false;

        }
        if(isbad)
        {
            float frenar = 10f;
            speed -= frenar * Time.deltaTime;
            isbad = false;
        }
        speed = Mathf.Clamp(speed, 0f, maxima);

       

    }
    public float rotacionagu()
    {
        float totalAngle = zerom - maxima;
        float speednormal = speed / maxima;
        return zerom - speednormal * totalAngle;
    }

}
