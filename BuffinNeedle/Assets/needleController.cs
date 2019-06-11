using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waitfor3Seconds());
        Destroy(this);   
    }

    IEnumerator Waitfor3Seconds()
    {
        yield return new WaitForSeconds(3);
    }
}
