using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
    public float selfDestructTime = 2f;
    private float selfDestructTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (selfDestructTimer > selfDestructTime)
            selfDestruct();
        selfDestructTimer += Time.deltaTime;
    }

    void selfDestruct()
    {
        Destroy(gameObject);
    }
}
