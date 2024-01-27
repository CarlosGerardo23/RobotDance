using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesInformation
{
    private BoxCollider2D[] handsColliders = new BoxCollider2D[4];
    private BoxCollider2D[] legsColliders = new BoxCollider2D[4];

    public void SetHands(GameObject hand1, GameObject hand2, GameObject hand3, GameObject hand4)
    {
        handsColliders[0] = hand1.GetComponent<BoxCollider2D>();
        handsColliders[1] = hand2.GetComponent<BoxCollider2D>();
        handsColliders[2] = hand3.GetComponent<BoxCollider2D>();
        handsColliders[3] = hand4.GetComponent<BoxCollider2D>();
    }

    public void SetLegs(GameObject leg1, GameObject leg2, GameObject leg3, GameObject leg4)
    {
        legsColliders[0] = leg1.GetComponent<BoxCollider2D>();
        legsColliders[1] = leg2.GetComponent<BoxCollider2D>();
        legsColliders[2] = leg3.GetComponent<BoxCollider2D>();
        legsColliders[3] = leg4.GetComponent<BoxCollider2D>();
    }

    public void Comparison(BonesInformation poseToCompare)
    {
        BoxCollider2D[] otherHands = poseToCompare.GetHands();
        BoxCollider2D[] otherLegs = poseToCompare.GetLegs();
        float[] handDistances = new float[4];
        float[] legsDistances = new float[4];

        for (byte i = 0; i < 4; i++)
        {
            handDistances[i] = (handsColliders[i].Distance(otherHands[i])).distance;
            legsDistances[i] = (legsColliders[i].Distance(otherLegs[i])).distance;
        }
    }

    public BoxCollider2D[] GetHands()
    {
        return handsColliders;
    }
    
    public BoxCollider2D[] GetLegs()
    {
        return legsColliders;
    }
}
