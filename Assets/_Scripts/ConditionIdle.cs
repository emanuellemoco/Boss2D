using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionIdle : Condition
{
   Transform agent;
   Transform target;
   float maxDist;

   public ConditionIdle(Transform ag, Transform ta, float dist)
   {
       agent = ag;
       target = ta;
       maxDist = dist;
   }

   public override bool Test()
   {
       if (target == null) {return false;}
       return Vector2.Distance(agent.position, target.position) >= maxDist;
   }
}