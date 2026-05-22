using GF.EVENT_BUS;
using UnityEngine;
using GF.BASICALMODEL;
using GF.BUSINESS;
public class Game : MonoBehaviour
{

    private BusinessModel _businessModel;
    private BaseModel _baseModel;
    void Awake()
    {
        _baseModel = new BaseModel();
        _businessModel = new BusinessModel();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

class BusinessModel 
{ 
    public static PlayerCenter PlayerCenter;

    public BusinessModel()
    {
        Debug.Log("BusinessModel Constructor");
        PlayerCenter = new PlayerCenter();

    }

}

class BaseModel
{
    public static EventBus EventBus;
    public static GameMgr GameManager;
    public static AssetMgr AssetManager;
    public static UIMgr UIManager;
    public BaseModel()
    {
        EventBus = new EventBus();
        GameManager = new GameMgr();
        UIManager = new UIMgr();
        AssetManager = new AssetMgr();
    }

}


