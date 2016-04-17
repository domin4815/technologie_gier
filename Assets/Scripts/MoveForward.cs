using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{
    public float thrust;
    void Update()
    {
		transform.position += transform.forward * Time.deltaTime * thrust;
    }
}