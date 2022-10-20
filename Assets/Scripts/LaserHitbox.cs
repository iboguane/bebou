using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHitbox : MonoBehaviour
{
    private Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerStats.Instance.TakeDamage();
        Destroy(this);
    }
}
