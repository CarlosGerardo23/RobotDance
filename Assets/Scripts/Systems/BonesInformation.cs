using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesInformation : MonoBehaviour
{
    [SerializeField] private Transform[] hands;
    [SerializeField] private Transform[] legs;

    public float[] Comparison(BonesInformation poseToCompare)
    {
        Transform[] otherHands = poseToCompare.GetHands();
        Transform[] otherLegs = poseToCompare.GetLegs();
        float[] handDistances = new float[hands.Length];
        float[] legsDistances = new float[legs.Length];

        for (int i = 0; i < hands.Length; i++)
        {
            handDistances[i] = (hands[i].position - otherHands[i].position).magnitude;
        }

        for (int i = 0; i < legs.Length; i++)
        {
            legsDistances[i] = (legs[i].position - otherHands[i].position).magnitude;
        }

        float[] totalDistances = new float[handDistances.Length + legsDistances.Length];
        Array.Copy(handDistances, totalDistances, handDistances.Length);
        Array.Copy(legsDistances, 0, totalDistances, handDistances.Length, legsDistances.Length);


        return totalDistances;
    }

    public Transform[] GetHands()
    {
        return hands;
    }
    
    public Transform[] GetLegs()
    {
        return legs;
    }
}
