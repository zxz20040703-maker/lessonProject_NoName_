using GF.INTERFACE_FRAME.ITEXTPOINTER;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// Unity打字机：默认挂给VisualNovelPanel->DialogBar->Text (TMP)
/// 只负责处理文本表现的逻辑，不管其他任何逻辑
/// </summary>
public class TextTyper : MonoBehaviour, GF.INTERFACE_FRAME.ITEXTPOINTER.ITyper
{
    private TextMeshProUGUI _curTextMeshProUGUI;//当前的TMP组件，可替换
    private char[] _emotionalSymbols = new char[] { '！', '？', '。', '，', '；', '!' };//中文输入法的符号
    private void Awake()
    {
        _curTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        Debug.Log(Application.persistentDataPath);
    }


    public float Speed { get; set; }
    public bool IsTypeing {  get; set; }
    public IEnumerator TextShow()
    {
        if (IsTypeing) yield break;//防重复
        IsTypeing = true;
        _curTextMeshProUGUI.maxVisibleCharacters = 0;
        int allTextCount = _curTextMeshProUGUI.textInfo.characterCount;


 
        float time = 0;
        int _curIndex = 0;


        //当前显示文本索引 < 总文本时
        while (_curTextMeshProUGUI.maxVisibleCharacters < allTextCount)
        {
           
            yield return null;
            time += Time.deltaTime;
            if (time >= Speed)//Speed为间隔时间
            {
                
                time = 0;//计时归零
                char currentChar = _curTextMeshProUGUI.textInfo.characterInfo[_curIndex].character;

                _curTextMeshProUGUI.maxVisibleCharacters++;
                if (IsEmotionalSymbol(currentChar))//如果当前显示的是情感符号               
                yield return new WaitForSeconds(0.15f);                  
          
                _curIndex++;
            }
          
        }

        _curIndex = 0;
        IsTypeing = false;
    }
    public void ChangeTMP(TextMeshProUGUI textMeshProUGUI)
    {
        try
        {

            _ = textMeshProUGUI ?? throw new NullReferenceException("对话组件传递失效 , 使用默认对话组件");
        }catch(NullReferenceException ex)
        {
            Debug.Log(ex);

        }
    }

    /// <summary>
    /// 判断是否时情感符号
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool IsEmotionalSymbol(char c)
    {
        foreach (var symbol in _emotionalSymbols)
        {
            if (c == symbol)
                return true;
        }
        return false;
    }

    private void Test001()
    {
        _curTextMeshProUGUI.text = "shfuisdhfiusfhiusdhfuisdfhuisdhfiusdfhiusdfdasjdasdasdasd";
        _curTextMeshProUGUI.ForceMeshUpdate();
        StartCoroutine(TextShow());
        Speed = 0.05f;
        int allTextCount = _curTextMeshProUGUI.textInfo.characterCount;
        Debug.Log(allTextCount);
    }
}
