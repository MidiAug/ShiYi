using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public TMP_Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("头像")]
    public Sprite face01, face02;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFormFile(textFile);
    }
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&index==textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        //if (Input.GetKeyDown(KeyCode.R)&&textFinished)
        //{
        //    StartCoroutine(SetTextUI());
        //}
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(textFinished&&!cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished&&!cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate=file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch(textList[index].Trim().ToString())
        {
            case "守护者":
                faceImage.sprite = face01;
                index++;
                break;
            case "闽闽":
                faceImage.sprite = face02;
                index++;
                break;
        }
        int letter = 0;
        while (!cancelTyping && letter<textList[index].Length-1 )
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
