using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogs : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprImage;
    [SerializeField] private TMP_Text text;
    [SerializeField] private float timeBetweenSentences;
    [SerializeField] private float timeDialodDisplayed;
    [SerializeField][TextArea(5, 3)] private string[] sentences;
    
    private Cooldowns cdDialog;
    private bool isDisplayed;

    private void Start()
    {
        isDisplayed = false;
        cdDialog = new(timeBetweenSentences);
        cdDialog.ResetCD();
        image.sprite = sprImage;
        image.gameObject.SetActive(false);
    }

    private void Update()
    {
        cdDialog.DecreaseCD(Time.deltaTime);
        if (!cdDialog.isFinished) return;
        DisplayDialog(!isDisplayed);
        cdDialog.ResetCD(isDisplayed ? timeDialodDisplayed : timeBetweenSentences);
    }

    private void DisplayDialog(bool displayed)
    {
        if (sentences.Length == 0) return;
        if (displayed)
        {
            text.text = sentences[Random.Range(0,sentences.Length)];
        }
        isDisplayed = displayed;
        image.gameObject.SetActive(displayed);
    }
}
