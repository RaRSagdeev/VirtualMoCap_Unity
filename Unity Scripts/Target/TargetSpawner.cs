using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private AnimationInfo[] Animations;

    [SerializeField]
    private CameraManager Camera;

    [SerializeField]
    private AnimationChanger AnimationChanger;

    [SerializeField]
    private GameObject End;

    private int targetIndex = 0;
    private AnimationInfo currentAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentAnimation = Animations[targetIndex];
        CreateNewTarget();
    }

    void CreateNewTarget()
    {
        GameObject.Instantiate(currentAnimation.TargetPrefab, currentAnimation.Offset, currentAnimation.TargetPrefab.transform.rotation);
    }

    public void ChangeTarget()
    {
        targetIndex++;
        if (targetIndex < Animations.Length)
        {
            Camera.ChangePosition(false, currentAnimation.TMPText);
            currentAnimation = Animations[targetIndex];
            Invoke("CreateNewTarget", 3f);
            AnimationChanger.ChangeAnimation(currentAnimation.Controller);
        }
        else
        {
            End.SetActive(true);
        }
    }
}
