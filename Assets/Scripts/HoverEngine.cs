using UnityEngine;
using System.Collections;

public class HoverEngine : MonoBehaviour {
    public float speed = 100f;
    public float turnSpeed = .2f;
    public float hoverForce = 65f;
    public float hoverHeight = 0.5f;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;


    public void fireEngine(float distance) {

        float proportionalHeight = (hoverHeight - distance) / hoverHeight;
        if(proportionalHeight <= 0)
        {
            proportionalHeight = 0;
        }
        Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
        carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
    }

    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        /*Ray ray = new Ray(transform.position, (-transform.up+(transform.forward*1.5f)));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }*/

        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

    }



}
