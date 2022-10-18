using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    [SerializeField] private TMP_Text text;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        text.text = ((int)timer).ToString() + "s";
    }
}
