using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBoxController : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float gravity = -9.81f;     // 중력 계수
    public bool reverseGravity = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        reserveGravity();
    }

    public void reserveGravity()
    {
        if (reverseGravity == true)
        {
            rigidbody.useGravity = false;
            rigidbody.AddForce(new Vector3(0, -gravity, 0));
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            rigidbody.useGravity = true;
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
