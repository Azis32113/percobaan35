using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinyakHilang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gone(8f));
    }

    IEnumerator Gone(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
