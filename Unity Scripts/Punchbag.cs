using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Punchbag : MonoBehaviour
{
    [SerializeField]
    private Vector3 Position;
    [SerializeField]
    private GameObject TMProText;

    private Rigidbody rigidbody;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Position = gameObject.transform.position;
        StartCoroutine("ReturnToPosition");
    }

    private void OnCollisionEnter(Collision collision)
    {
        int power = 0;
        speed = rigidbody.velocity.magnitude;
        power = (int)(speed * 33 * 2 * 0.2);
        if (TMProText is not null)
        {
            string text = string.Format("Сила удара:{0}", power);
            TMProText.GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    IEnumerator ReturnToPosition()
    {
        while (true)
        {
            gameObject.transform.position = Position;
            yield return new WaitForSeconds(2f);
        }
    }
}
