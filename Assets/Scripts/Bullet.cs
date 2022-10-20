using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    private Vector3 player;
    private Vector3 behindplayer;
    private float d;
    public float troploin;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>().position;
        d = Mathf.Pow((this.gameObject.transform.position.x - player.x), 2) + Mathf.Pow((this.gameObject.transform.position.y - player.y), 2);
        behindplayer = new Vector3(900 / d * player.x + (1 - 900 / d) * this.gameObject.transform.position.x, 900 / d * player.y + (1 - 900 / d) * this.gameObject.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TueBullet());
        transform.position = Vector3.MoveTowards(transform.position, behindplayer, Time.deltaTime*speed);
    }
    void OnTriggerEnter2D(Collider2D col){
        //PlayerStats.Instance.TakeDamage();
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator TueBullet()
    {
        yield return new WaitForSeconds(troploin);
        Destroy(gameObject);
    }
}
