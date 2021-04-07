using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class SteerableBehaviour : MonoBehaviour
{
    public ThrustData td;

    private Rigidbody2D rb;

    private void Awake()
    {
       if (td == null)
        {
            throw new MissingReferenceException($"Nao encontrou {gameObject.name}");
            
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Thrust(float x, float y)
    {
        rb.MovePosition(rb.position + new Vector2(x * td.thrustIntensity.x, y * td.thrustIntensity.y) * Time.fixedDeltaTime);
    }

}
