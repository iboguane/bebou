using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 player;
    public LineRenderer lr;
    private float d;
    public GameObject LaserPrefab;
    public int TempReaction = 2;
    public GameObject ancre;
    void Start()
    {
    player = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
    lr.SetPosition(0, this.gameObject.transform.position);
        /*
Using this formula to get from line (x1,y1) and (x2,y2) a point (x3,y3) that is n distance from point 2
d = sqrt((x2-x1)^2 + (y2 - y1)^2) #distance
r = n / d #segment ratio

x3 = r * x2 + (1 - r) * x1 #find point that divides the segment
y3 = r* y2 + (1 - r) * y1 #into the ratio (1-r):r
    */
    d = Mathf.Pow((this.gameObject.transform.position.x - player.x), 2) + Mathf.Pow((this.gameObject.transform.position.y - player.y), 2);
    lr.SetPosition(1, new Vector3(500 / d * player.x + (1 - 500 / d) * this.gameObject.transform.position.x, 500 / d * player.y + (1 - 500 / d) * this.gameObject.transform.position.y, 0));
    StartCoroutine(Bzzt());
    }

    IEnumerator Bzzt()
    {
        yield return new WaitForSeconds(TempReaction);
        GameObject laser = Instantiate(LaserPrefab, this.gameObject.transform.position, Quaternion.identity);
        laser.transform.parent = gameObject.transform;
        foreach (GameObject ancre in GameObject.FindGameObjectsWithTag("Anchor")){
            Vector3 difference = player - ancre.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            ancre.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90f);
        }
        yield return new WaitForSeconds(TempReaction);
        Destroy(gameObject);
    }
}
