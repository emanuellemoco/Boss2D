using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionAttack : Condition
{
   Transform agent;
   Transform target;
   float minDist;

   public ConditionAttack(Transform ag, Transform ta, float dist)
   {
       agent = ag;
       target = ta;
       minDist = dist;
   }

   public override bool Test()
   {
       if (target == null) {return false;}
       return Vector2.Distance(agent.position, target.position) <= minDist;
   }
}