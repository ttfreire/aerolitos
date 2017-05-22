using UnityEngine;
using System.Collections;

public class AstronautController : MonoBehaviour {
    public float minThrustForce;
    public float maxThrustForce;
    float rotationSpeed = 10f;
    Rigidbody2D astronaultRigidbody;
    float currentOxygen;
    public float maxOxygen;
    public float oxygenUseRate;

	void Awake () {
        astronaultRigidbody = GetComponent<Rigidbody2D>();
        currentOxygen = maxOxygen;
    }
	
	void Update () {
        ActivateTestCheatTools();
    }

    void ActivateTestCheatTools()
    {
        if (Input.GetKey(KeyCode.O))
        {
            currentOxygen = maxOxygen;
        }
    }

    public void Rotate(float direction) {
        transform.Rotate(Vector3.forward * -direction * rotationSpeed);
    }

    public void Move() {
        UseOxygen();
        float thrustForce = Random.Range(minThrustForce, maxThrustForce);
        astronaultRigidbody.AddForceAtPosition(transform.right * thrustForce, transform.position);
    }

    public float GetCurrentOxygen()
    {
        return currentOxygen;
    }

    void UseOxygen()
    {
        currentOxygen -= oxygenUseRate;
    }

    public bool IsDead()
    {
        return currentOxygen <= 0;
    }
}
