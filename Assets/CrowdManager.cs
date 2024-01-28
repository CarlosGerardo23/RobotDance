using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public int morale = 2;
    public SpawnManager _tomatoSpawner;
    public SpawnManager _roseSpawner;

    private float timer = 0;
    public float frequency = 3f; 


    public void SetAudienceAngry()
    {
        morale = 0;
    }

    public void SetAudienceNeutral()
    {
        morale = 1;
    }

    public void SetAudienceHappy()
    {
        morale = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            timer = 0;
            switch (morale)
            {
                case 0:
                    _tomatoSpawner.SpawnObject();
                    break;
                case 1:
                    break;
                case 2:
                    _roseSpawner.SpawnObject();
                    break;
            }
        }
    }
}
