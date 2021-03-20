using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator gfx;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onFinishLineCrossed += SetForKick;
        gfx.SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetForKick(){

        if(gfx != null){
            gfx.applyRootMotion = false;
            gfx.SetBool("Running", false);
            gfx.applyRootMotion = true;
            gfx.SetTrigger("Kick");
        }
    }
}
