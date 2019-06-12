using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waitfor1Seconds());
    }

    IEnumerator Waitfor1Seconds()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
