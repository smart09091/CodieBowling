using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1000,5000)]
    public float ballForce;
    public Vector3 ballStartPosition;
    public Vector3 ballPivotStartPosition;
    private Rigidbody rigidbody;
    private bool thrown = false;
    public GameObject playerReference;
    public float kickingDistance = 4.7f;
    public float movementSpeed = 5f;
    public GameObject ballPivot;
    [Range(0,2)]
    public int ballType;
    public float ballScale;
    public float minBallScale = 1.5f;
    public float maxBallScale = 3f;
    bool setForKick = false;
    Vector3 lastPlayerPosition;
    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        SetBallScale(ballScale);
        ballPivotStartPosition = ballPivot.transform.localPosition;
        ballStartPosition = transform.localPosition;

        GameEvents.Instance.onFinishLineCrossed += SetForKick;
        GameEvents.Instance.onGaugeForceApplied += SetBallForce;
        GameEvents.Instance.onBallObstacleHit += HandleBallObstacleHit;
        GameEvents.Instance.onWallObstacleHit += HandleWallObstacleHit;
        GameEvents.Instance.onNextLevel += ResetBall;
    }

    void OnDestroy() {

        GameEvents.Instance.onFinishLineCrossed -= SetForKick;
        GameEvents.Instance.onGaugeForceApplied -= SetBallForce;
        GameEvents.Instance.onBallObstacleHit -= HandleBallObstacleHit;
        GameEvents.Instance.onWallObstacleHit -= HandleWallObstacleHit;
        GameEvents.Instance.onNextLevel -= ResetBall;
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

    public void SetBallScale(float value){

        ballPivot.transform.localScale = new Vector3(
            ballScale,
            ballScale,
            ballScale
        );
    }

    public void SetForKick(){
        setForKick = true;
        lastPlayerPosition = playerReference.transform.position;

    }

    public void PerformKick(){
        Debug.Log("PerformKick");
        
        GameEvents.Instance.KickStart();

        if(!thrown){
           thrown = true;
           rigidbody.isKinematic = false;
           //rigidbody.velocity = new Vector3(0,0,speed);
           rigidbody.AddForce(transform.forward * ballForce);
        }
    }

    public void SetBallForce(float force){
        ballForce = force;
    }

    public void HandleBallObstacleHit(int ballType, float scaleValue, float ballForceValue){
        if(this.ballType == ballType){
            ballScale += scaleValue;

            if(ballScale > maxBallScale){
                ballScale = maxBallScale;
            }

            GameEvents.Instance.GaugeForceUpdated(ballForceValue);

        }else{
            ballScale -= scaleValue;

            if(ballScale < minBallScale){
                ballScale = minBallScale;
            }

            GameEvents.Instance.GaugeForceUpdated(-ballForceValue);
        }

        SetBallScale(ballScale);
    }

    public void HandleWallObstacleHit(int wallType){
        ballType = wallType;

        SetBallScale(ballScale);
    }

    public void ResetBall(){
        ballScale = 1.5f;
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        ballPivot.transform.localPosition = ballPivotStartPosition;
        transform.localPosition = ballStartPosition;
        transform.localRotation = Quaternion.identity;
        thrown = false;
        SetBallScale(ballScale);
    }
    
}
