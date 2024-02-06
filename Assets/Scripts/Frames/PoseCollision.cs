using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseCollision : MonoBehaviour
{
    [SerializeField] private PoseType _poseType;
    [SerializeField] private PosesCheckerSO _posesChecker;
   private void OnTriggerEnter2D(Collider2D col)
   {
        //Check if collide, if so set rauslt to good
   }
   private void OnTriggerExit2D(Collider2D col)
   {
        //Check if collide, if so set rauslt to good
   }
   private void OnTriggerStay2D(Collider2D col)
   {
        //Check if collide, if so set rauslt to good
   }
   //Do en trigger exit
}
