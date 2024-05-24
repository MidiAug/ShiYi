using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextAsset dialogDataFile;

    public SpriteRenderer spriteLeft;
    public SpriteRenderer spriteRight;

    public TMP_Text nameText;
    public TMP_Text dialogText;

    public List<Sprite> sprites = new List<Sprite>();

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

    public int dialogIndex = 0;
    public string[] dialogRows;

    public Button next;
    public GameObject optionButton;
    public Transform buttonGroup;

    public GameObject dialogCanvas;

    private System.Action onDialogComplete; // 回调函数

    private void Awake()
    {
        dialogCanvas.SetActive(false);
        imageDic["闽闽"] = sprites[0];
        imageDic["守护者"] = sprites[1];
    }

    void Start()
    {
        ReadText(dialogDataFile);
    }

    public void StartDialog(System.Action onComplete)
    {
        dialogIndex = 0;
        onDialogComplete = onComplete;
        dialogCanvas.SetActive(true);
        ShowDialogRow();
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name, string _position)
    {
        if (_position == "左")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if (_position == "右")
        {
            spriteRight.sprite = imageDic[_name];
        }
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        Debug.Log("读取成功");
    }

    public void ShowDialogRow()
    {
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                dialogIndex = int.Parse(cells[5]);
                next.gameObject.SetActive(true);
                break;
            }
            else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
            {
                next.gameObject.SetActive(false);
                GenerateOption(i);
                break;
            }
            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                dialogCanvas.SetActive(false);
                onDialogComplete?.Invoke(); // 调用回调函数
            }
        }
    }

    public void OnClickNext()
    {
        ShowDialogRow();
    }

    public void GenerateOption(int _index)
    {
        string[] cells = dialogRows[_index].Split(',');
        if (cells[0] == "&")
        {
            GameObject button = Instantiate(optionButton, buttonGroup);
            //绑定按钮
            button.GetComponentInChildren<TMP_Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener(
            delegate
            {
                OnOptionClick(int.Parse(cells[5]));
            });
            GenerateOption(_index + 1);
        }
    }

    public void OnOptionClick(int _id)
    {
        dialogIndex = _id;
        ShowDialogRow();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }
}
