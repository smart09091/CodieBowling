using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1000,5000)]
    public float ballForce;
    private Rigidbody rigidbody;
    private bool thrown = false;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
    }

    void BallMovement(){
        if(!thrown){
            float xMovement = Input.GetAxis("Horizontal");
            Vector3 position = transform.position;
            position.x += xMovement * horizontalSpeed;
            transform.position = position;
        }
    }

    public void PerformKick(){
        Debug.Log("PerformKick");
        if(!thrown){
           thrown = true;
           rigidbody.isKinematic = false;
           //rigidbody.velocity = new Vector3(0,0,speed);
           rigidbody.AddForce(transform.forward * ballForce);
        }
    }
}
