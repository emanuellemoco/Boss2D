using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionFollow : Condition
{
   Transform agent;
   Transform target;
   float maxDist;
   float minDist;

   public ConditionFollow(Transform ag, Transform ta, float _maxDist, float _minDist)
   {
       agent = ag;
       target = ta;
       maxDist = _maxDist;
       minDist = _minDist;
   }

   public override bool Test()
   {
    //    Debug.Log(Vector2.Distance(agent.position, target.position));
       if (target == null) {return false;}
       return Vector2.Distance(agent.position, target.position) >= minDist && Vector2.Distance(agent.position, target.position) <= maxDist;
   }
}