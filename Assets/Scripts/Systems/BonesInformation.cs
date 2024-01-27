using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesInformation
{
    private BoxCollider2D[] handsColliders = new BoxCollider2D[2];
    private BoxCollider2D[] legsColliders = new BoxCollider2D[2];

    public void SetHands(GameObject hand1, GameObject hand2)
    {
        handsColliders[0] = hand1.GetComponent<BoxCollider2D>();
        handsColliders[1] = hand2.GetComponent<BoxCollider2D>();
    }

    public void SetLegs(GameObject leg1, GameObject leg2)
    {
        legsColliders[0] = leg1.GetComponent<BoxCollider2D>();
        legsColliders[1] = leg2.GetComponent<BoxCollider2D>();
    }

    public void Comparison(BonesInformation poseToCompare)
    {
        BoxCollider2D[] otherHands = poseToCompare.GetHands();
        BoxCollider2D[] otherLegs = poseToCompare.GetLegs();

        for(byte i = 0; i < 2; i++)
        {
            ColliderDistance2D distance = handsColliders[i].Distance(otherHands[i]);
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
