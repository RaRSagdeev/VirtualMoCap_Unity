using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AnimationInfo", order = 1)]
public class AnimationInfo : ScriptableObject
{
    public string Name;
    public GameObject TargetPrefab;
    public RuntimeAnimatorController Controller;
    public string BodyPart;
    public Vector3 Offset;
    public string TMPText;
}
