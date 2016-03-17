using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * thrust);
    }
}