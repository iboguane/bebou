using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    private Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player  , Time.deltaTime*speed);
    }
    void OnTriggerEnter2D(Collider2D col){
        //PlayerStats.Instance.TakeDamage();
        Destroy(gameObject);
    }
}
