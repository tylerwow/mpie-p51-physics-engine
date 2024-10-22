using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed = 0.0f;
    public float spin = 0.0f;
    public bool spaceDown = false;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceDown == false) {
            spaceDown = true;
            SpinBall();
            PushBall();
        }
        else if (spaceDown == false) {
            float translation = Input.GetAxis("Horizontal");
            Transform t = gameObject.transform;
            t.Translate(-translation * 0.1f, 0.0f, 0.0f);

            speed += Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Q)) {
                spin += 10.0f;
            }
            else if (Input.GetKeyDown(KeyCode.E)) {
                spin -= 10.0f;
            }
        }
    }

    private void PushBall() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f, 0.0f, -speed));
    }

    private void SpinBall() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0.0f, 0.0f, -spin));
    }
}
