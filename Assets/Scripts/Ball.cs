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
    public GameObject playerReference;
    public float kickingDistance = 4.7f;
    public float movementSpeed = 5f;
    bool setForKick = false;
    Vector3 lastPlayerPosition;
    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
        Debug.Log(Vector3.Distance(transform.position, playerReference.transform.position));

        if(Input.GetKeyDown(KeyCode.R)){
            Animator playerAnimator = playerReference.GetComponent<Animator>();
            run = !run;
            playerAnimator.applyRootMotion = false;
            playerAnimator.SetBool("Running", run);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            setForKick = true;
            lastPlayerPosition = playerReference.transform.position;
            Animator playerAnimator = playerReference.GetComponent<Animator>();

            if(playerAnimator != null){
                playerAnimator.applyRootMotion = false;
                playerAnimator.SetBool("Running", false);
                playerAnimator.applyRootMotion = true;
                playerAnimator.SetTrigger("Kick");
            }
        }

        if(setForKick){
            if(Vector3.Distance(transform.position, lastPlayerPosition)<4.7){
                 transform.position += transform.forward * Time.deltaTime * movementSpeed;
            }else{
                setForKick = false;
            }
        }
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
