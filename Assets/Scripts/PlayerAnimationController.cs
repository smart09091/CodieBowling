using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator gfx;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onFinishLineCrossed += SetForKick;
        GameEvents.Instance.onGameStart += EnableRun;
        GameEvents.Instance.onRoundFinished += PerformVictoryDance;
        GameEvents.Instance.onNextLevel += ResetAnimator;
    }
    void OnDestroy() {
        GameEvents.Instance.onFinishLineCrossed -= SetForKick;
        GameEvents.Instance.onGameStart -= EnableRun;
        GameEvents.Instance.onRoundFinished -= PerformVictoryDance;
        GameEvents.Instance.onNextLevel -= ResetAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableRun(){
        Debug.Log("EnableRun");
        gfx.SetBool("Running", true);
    }

    public void DisableRun(){
        gfx.SetBool("Running", false);
    }

    public void SetForKick(){

        if(gfx != null){
            gfx.applyRootMotion = false;
            gfx.SetBool("Running", false);
            gfx.applyRootMotion = true;
            gfx.SetTrigger("Kick");
        }
    }
    public void PerformVictoryDance(){
            gfx.SetTrigger("Victory");
    }

    public void ResetAnimator(){
        gfx.applyRootMotion = false;
        gfx.transform.localPosition = Vector3.zero;
    }
}
