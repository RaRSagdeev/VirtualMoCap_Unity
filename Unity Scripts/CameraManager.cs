using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 TrainerPos;

    [SerializeField]
    private Vector3 PlayerPos;

    [SerializeField]
    private TextManager TextManager;

    private void Start()
    {
        Invoke("MoveToPlayer", 8f);
    }

    public void ChangePosition(bool Player, string text)
    {
        if (Player)
            MoveToPlayer();
        else
            MoveToTrainer(text);
    }

    private void MoveToTrainer(string text)
    {
        TextManager.SetVisible(true, text);
        gameObject.transform.position = TrainerPos;
        Invoke("MoveToPlayer", 8f);
    }

    private void MoveToPlayer()
    {
        TextManager.SetVisible(false);
        gameObject.transform.position = PlayerPos;
    }
}
