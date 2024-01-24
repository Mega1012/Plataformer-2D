using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public KeyCode KeyToTrigger = KeyCode.A;
    public KeyCode KeyToExit = KeyCode.S;
    public string TriggerToPlay = "Run";

    private void OnValidate()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyToTrigger))
        {
            animator.SetBool(TriggerToPlay, !animator.GetBool(TriggerToPlay));
        }
    }  



}
