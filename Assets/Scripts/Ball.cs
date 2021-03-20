using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1000,5000)]
    public float ballForce;
    private Rigidbody rigidbody;
    private bool thrown = false;
    public GameObject playerReference;
    public float kickingDistance = 4.7f;
    public float movementSpeed = 5f;
    public GameObject ballPivot;
    bool setForKick = false;
    Vector3 lastPlayerPosition;
    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GameManager.Instance.onFinishLineCrossed += SetForKick;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, playerReference.transform.position));

        if(Input.GetKeyDown(KeyCode.R)){
            Animator playerAnimator = playerReference.GetComponent<Animator>();
            run = !run;
            playerAnimator.applyRootMotion = false;
            playerAnimator.SetBool("Running", run);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            SetForKick();
        }

        if(setForKick){
            if(Vector3.Distance(transform.position, lastPlayerPosition) < 4.7){
                 ballPivot.transform.position += transform.forward * Time.deltaTime * movementSpeed;
            }else{
                setForKick = false;
            }
        }
    }

    public void SetForKick(){
        setForKick = true;
        lastPlayerPosition = playerReference.transform.position;

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
