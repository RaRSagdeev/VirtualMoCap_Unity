using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainText;

    [SerializeField]
    private GameObject ChangableText;

    [SerializeField]
    private GameObject PowerText;

    private TextMeshProUGUI TMProText;

    public void SetVisible(bool visible, string text = "")
    {
        MainText.SetActive(visible);
        ChangableText.SetActive(visible);
        TMProText.text = text;
        PowerText.SetActive(!visible);
    }
    // Start is called before the first frame update
    void Start()
    {
        TMProText = ChangableText.GetComponent<TextMeshProUGUI>();
    }
}
