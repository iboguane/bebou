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
    public float TempsAttAvantAtk;
    public static float TempsAttAvantAtkStatic;
    private bool Cd = false;
    // Start is called before the first frame update
    void Start()
    {
        TempsAttAvantAtkStatic = TempsAttAvantAtk;
        StartCoroutine(TueBullet());
        StartCoroutine(Attaque());

    }

    // Update is called once per frame
    void Update()
    {
        if (Cd == true){
        transform.position = Vector3.MoveTowards(transform.position, behindplayer, Time.deltaTime*speed);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        PlayerStats.Instance.TakeDamage();
        if (col.tag == "Player" && this.gameObject.tag != "Bear")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator TueBullet()
    {
        yield return new WaitForSeconds(troploin+TempsAttAvantAtk);
        Destroy(gameObject);
    }
    IEnumerator Attaque()
    {
                /*
Using this formula to get from line (x1,y1) and (x2,y2) a point (x3,y3) that is n distance from point 2
d = sqrt((x2-x1)^2 + (y2 - y1)^2) #distance
r = n / d #segment ratio

x3 = r * x2 + (1 - r) * x1 #find point that divides the segment
y3 = r* y2 + (1 - r) * y1 #into the ratio (1-r):r
    */
        Cd = false;
        yield return new WaitForSeconds(TempsAttAvantAtk);
        transform.parent = null;
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>().position;
        d = Mathf.Pow((this.gameObject.transform.position.x - player.x), 2) + Mathf.Pow((this.gameObject.transform.position.y - player.y), 2);
        behindplayer = new Vector3(900 / d * player.x + (1 - 900 / d) * this.gameObject.transform.position.x, 900 / d * player.y + (1 - 900 / d) * this.gameObject.transform.position.y, 0);
        Cd = true;
        Vector3 difference = player - this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180);
        if (this.name.Contains("Bullet"))
        {
            AudioManager.instance.PlayClip("Pew");
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);
        }
        else
        {
            AudioManager.instance.PlayClip("Bear");
        }
    }
}
