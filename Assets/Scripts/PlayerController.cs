using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;

public class PlayerController : MonoBehaviour
{
    public bool running = true;
    public Joystick joystickReference;    
    public GameObject playerSideMovementPivot;
    public float forwardSpeed;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onFinishLineCrossed += StopPlayerMovement;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement(){
        
        if(running){
            //Move main player object forward
            Vector3 playerPosition = transform.position;
            playerPosition.z += forwardSpeed * Time.deltaTime;
            
            transform.position = playerPosition;
            
            /*Check for horizontal input from onscreen joystick and 
            apply sideward movement to the playerSideMovementPivot*/
            float xMovement = joystickReference.xAxis.value;
            Vector3 playerSideMovementPivotPosition = playerSideMovementPivot.transform.position;
            playerSideMovementPivotPosition.x += xMovement * horizontalSpeed * Time.deltaTime;
            playerSideMovementPivotPosition.x = Mathf.Clamp(playerSideMovementPivotPosition.x, -3f, 3f);
            playerSideMovementPivot.transform.position = playerSideMovementPivotPosition;
        }
    }

    void StopPlayerMovement(){
        running = false;
    }
}
