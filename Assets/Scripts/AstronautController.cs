using UnityEngine;
using System.Collections;

public class AstronautController : MonoBehaviour {
    public float m_MinThrustForce;
    public float m_MaxThrustForce;
    float m_RotationSpeed = 10f;
    Rigidbody2D m_rigidbody;
    float m_CurrentOxygen;
    public float m_MaxOxygen;
    public float m_OxygenUseRate;
    bool m_isDead = false;
	// Use this for initialization
	void Awake () {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_CurrentOxygen = m_MaxOxygen;
    }
	
	// Update is called once per frame
	void Update () {
        ActivateTestCheatTools();


    }

    void FixedUpdate() {


    }

    void ActivateTestCheatTools()
    {
        if (Input.GetKey(KeyCode.O))
        {
            m_CurrentOxygen = m_MaxOxygen;
        }
    }


    public void Rotate(float direction) {
        transform.Rotate(Vector3.forward * -direction * m_RotationSpeed);
    }


    public void Move() {
        UseOxygen();
        float thrustForce = Random.Range(m_MinThrustForce, m_MaxThrustForce);
        m_rigidbody.AddForceAtPosition(transform.right * thrustForce, transform.position);
    }

    public float GetCurrentOxygen()
    {
        return m_CurrentOxygen;
    }

    void UseOxygen()
    {
        m_CurrentOxygen -= m_OxygenUseRate;
    }

    public bool IsDead()
    {
        if(m_CurrentOxygen <= 0)
            return true;
        else
            return false;
    }
}
