using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public Animator _Animator;
    public float WaitingPeriod;
    public BoxCollider _Wind;

    public void AnimationStatus(string status)
    {
        if (status == "true")
        {
            _Animator.SetBool("Run_", true);
            _Wind.enabled = true;
        }
        else
        {
            _Animator.SetBool("Run_", false);
            StartCoroutine(AnimationTrigger());
            _Wind.enabled = false;
        }

    }


    IEnumerator AnimationTrigger()
    {
        yield return new WaitForSeconds(WaitingPeriod);
        AnimationStatus("true");
    }
}
