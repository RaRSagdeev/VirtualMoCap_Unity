using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField]
    private Animator componentAnimator;

    private bool startFadeIn = false;

    private bool startFadeOut = false;


    public void StartFadeIn()
    {
        startFadeIn = true;
    }

    public void StartFadeOut()
    {
        startFadeOut = true;
    }

    IEnumerator FadeIn()
    {
        if (startFadeIn)
        {
            componentAnimator.SetBool("FadeIn", true);
            Debug.Log("Entered Fade In");
            yield return new WaitForSeconds(1.0f);
            componentAnimator.SetBool("FadeIn", false);
            startFadeIn = false;
        }
        else
            yield return null;
    }

    IEnumerator FadeOut()
    {
        if (startFadeOut)
        {
            componentAnimator.SetBool("FadeOut", true);
            Debug.Log("Entered Fade Out");
            yield return new WaitForSeconds(1.0f);
            componentAnimator.SetBool("FadeOut", false);
            startFadeOut = false;
        }
        else
            yield return null;
    }

    private void Start()
    {
        StartCoroutine("FadeOut");
        StartCoroutine("FadeIn");
    }
}