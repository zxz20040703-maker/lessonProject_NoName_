using GF.GQZL.DATA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public CardType CardType;
    public string CardName;
    public string CardDescription;
    public string CardID;



    private TextMeshProUGUI _nameUGUI;
    private TextMeshProUGUI _descriptionUGUI;

    private void Awake()
    {
        _nameUGUI = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _descriptionUGUI = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        
    }

    
    public void ShowText(string name , string description)
    {
        _nameUGUI.text = name;
        _descriptionUGUI.text = description;
    }

    /// <summary>
    /// 每次重新激活此脚本，从卡牌管理器重新 随机 获得名字、id
    /// </summary>
    private void OnEnable()
    {
        //需要一个database
    }
}
