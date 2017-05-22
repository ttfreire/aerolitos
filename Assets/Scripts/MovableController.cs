using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableController : MonoBehaviour {
    public float minThrustForce;
    public float maxThrustForce;
    Rigidbody2D movableRigidbody;
    Vector3 velocity;

    void Awake()
    {
        movableRigidbody = GetComponent<Rigidbody2D>();
        AddThrustForceToMovable();
        velocity = movableRigidbody.velocity;
    }
	
	void Update () {
        MakeVelocityConstant();
    }

    public void AddThrustForceToMovable()
    {
        float thrustForce = Random.Range(minThrustForce, maxThrustForce);
        movableRigidbody.AddForceAtPosition(transform.right * thrustForce, transform.position, ForceMode2D.Impulse);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void MakeVelocityConstant()
    {
        movableRigidbody.velocity = velocity;
    }
}
