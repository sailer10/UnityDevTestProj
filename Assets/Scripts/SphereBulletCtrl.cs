using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBulletCtrl : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float speed = 10000.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // 로컬좌표 기준으로 앞으로 향하게 발사
        rigidbody.AddRelativeForce(Vector3.forward * speed);

        Destroy(gameObject, 2.0f);
    }
}
