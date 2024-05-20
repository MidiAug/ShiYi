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

    [Header("选择按钮")]
    public GameObject choicePanel;
    public Button choice1;
    public Button choice2;
    public Button choice3;
    public Button choice4;

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        if (textList.Count > 0)
        {
            StartCoroutine(SetTextUI());
        }
        else
        {
            Debug.LogError("Text list is empty!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            if (FindObjectOfType<TalkButton>() != null)
            {
                FindObjectOfType<TalkButton>().EndTalking();
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        if (file == null)
        {
            Debug.LogError("Text file is null!");
            return;
        }

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line.Trim());
        }

        if (textList.Count == 0)
        {
            Debug.LogError("No lines found in the text file!");
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        while (index < textList.Count && textList[index].StartsWith("#"))
        {
            index++;
        }

        if (index >= textList.Count)
        {
            yield break;
        }

        if (textList[index].StartsWith("&"))
        {
            choicePanel.SetActive(true);
            yield break;  // Wait for user to make a choice
        }

        switch (textList[index])
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
        while (!cancelTyping && letter < textList[index].Length)
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

    void Start()
    {
        choice1.onClick.AddListener(() => OnChoiceClick(1));
        choice2.onClick.AddListener(() => OnChoiceClick(2));
        choice3.onClick.AddListener(() => OnChoiceClick(3));
        choice4.onClick.AddListener(() => OnChoiceClick(4));
    }

    void OnChoiceClick(int choice)
    {
        if (!choicePanel.activeSelf)
        {
            choicePanel.SetActive(true);
        }

        switch (choice)
        {
            case 1:
            case 3:
            case 4:
                index = 7;  // Example index for these choices
                break;
            case 2:
                index = 10; // Example index for the second choice
                break;
        }

        choicePanel.SetActive(false); // Hide the choice panel after making a choice
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
}
