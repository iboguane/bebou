using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnnemi : MonoBehaviour
{
    public int Lifetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Mort());
    }

    IEnumerator Mort()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
}
