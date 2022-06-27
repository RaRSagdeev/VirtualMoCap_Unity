using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler : MonoBehaviour
{
    [SerializeField]
    private TargetSpawner Spawner;

    private void Start()
    {
        Spawner = FindObjectOfType<TargetSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Player_punch_bag")
        {
            GameObject.Destroy(gameObject);
            Spawner.ChangeTarget();
        }
    }
}
