using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> BodyTargets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var first = BodyTargets[0].transform.position;
        var second = BodyTargets[1].transform.position;
        float x = first.x + ((second.x - first.x)/2);
        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
