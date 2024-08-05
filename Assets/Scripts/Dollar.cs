using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollar : MonoBehaviour
{
    public GameObject dollar;

    void Start()
    {
        StartCoroutine(waitToFall());
        IEnumerator waitToFall()
        {
            yield return new WaitForSeconds(1.5f);
            dollar.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
        StartCoroutine(waitToDestroy());
        IEnumerator waitToDestroy()
        {
            yield return new WaitForSeconds(4.5f);
            Destroy(dollar);
        }
    }
}
