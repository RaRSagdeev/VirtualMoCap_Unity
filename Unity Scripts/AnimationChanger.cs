using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    [SerializeField]
    private Animator Trainer;

    public void ChangeAnimation(RuntimeAnimatorController Animation)
    {
        Debug.Log("Change Anim");
        Trainer.runtimeAnimatorController = Animation;
    }
}
