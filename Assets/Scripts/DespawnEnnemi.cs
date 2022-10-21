using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnnemi : MonoBehaviour
{
    public int Lifetime;
    private Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        StartCoroutine(TourneTirreur());
        StartCoroutine(Mort());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Mort()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
    IEnumerator TourneTirreur()
    {
        if (this.name.Contains("tirreur"))
        {
            yield return new WaitForSeconds(Bullet.TempsAttAvantAtkStatic);
            Vector3 difference = player - this.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180);
        }
    }
}
