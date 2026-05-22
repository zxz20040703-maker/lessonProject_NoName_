using GF.FUNCTION;
using GF.FUNCTION.TOKEN;
using GF.GQZL.DATA;
using GF.INTERFACE_FRAME;
using GF.INTERFACE_FRAME.ICHARACTER;
using GF.INTERFACE_FRAME.IDATACENTER;
using GF.USEFUL_BASE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace GF
{


    namespace LOGIC
    {
        namespace INTERFACE_LOGIC
        {

        }
        public struct LOGICPOS
        {
           readonly float _x, _y, _z;
        }

       
        

        namespace MANAGER
        {
            namespace FIGHT_MANAGER
            {
                enum FightModel

                {
                    VISUALNOVEL,
                    CARDHEAL,
                    WECHAT,
                    TALKHEAL
                }
                namespace FIGHT_CLASS
                {
                    public class VisualNovelModel : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                    {
                        public void Enter()
                        {

                        }
                        public void Exit()
                        {

                        }
                        public void Update()
                        {

                        }
                    }
                    public class CardHealModel : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                    {
                        public void Enter()
                        {

                        }
                        public void Exit()
                        {

                        }
                        public void Update()
                        {

                        }
                    }
                    public class WeChatModel : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                    {
                        public void Enter()
                        {

                        }
                        public void Exit()
                        {

                        }
                        public void Update()
                        {

                        }
                    }
                    public class TalkHealModel : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                    {
                        public void Enter()
                        {

                        }
                        public void Exit()
                        {

                        }
                        public void Update()
                        {

                        }
                    }
                }
                public class FightMgr
                {
                    public FightMgr()
                    {
                        _fightModelMachine = new();

                        FightMachineInit();
                    }

                    private GF.INTERFACE_FRAME.IFIGHT.IFight _curFight;
                    private GF.USEFUL_BASE.StateMachineBase<FightModel, GF.INTERFACE_FRAME.ISTATE_MACHINE.IState> _fightModelMachine;
                    private GF.FUNCTION.TOKEN.EvtToken<GF.EVENTS.ChangePlayingModel> evtToken;
                    private void FightMachineInit()
                    {
                        _fightModelMachine.StateRegister(FightModel.VISUALNOVEL, new GF.LOGIC.MANAGER.FIGHT_MANAGER.FIGHT_CLASS.VisualNovelModel());
                        _fightModelMachine.StateRegister(FightModel.CARDHEAL, new GF.LOGIC.MANAGER.FIGHT_MANAGER.FIGHT_CLASS.CardHealModel());
                        _fightModelMachine.StateRegister(FightModel.WECHAT, new GF.LOGIC.MANAGER.FIGHT_MANAGER.FIGHT_CLASS.WeChatModel());
                        _fightModelMachine.StateRegister(FightModel.TALKHEAL, new GF.LOGIC.MANAGER.FIGHT_MANAGER.FIGHT_CLASS.TalkHealModel());
                    }
                    public void ChangeFightModel(GF.EVENTS.ChangePlayingModel evt)
                    {
                        FightModel a = (FightModel)evt.GetMsg();
                        _fightModelMachine.ChangeState(a);
                    }
                }
            }

            namespace CARDMANAGER
            {
                public class CardManager
                {

                    public CardManager(CardGenerator cardGenerator)
                    {

                    }

                }



                /// <summary>
                /// 卡牌生成器
                /// </summary>
                public class CardGenerator
                {
                    //这个类的主要目的是调控卡牌的生成：每次进出对象池时，都要重新分配实例的卡牌id、描述、类型这三样属性

                    private UnityObjectPool _cardPool;//对象池，各类型的卡牌都有自己的对象池（需注入预制体）
                    private readonly Dictionary<CardType, UnityObjectPool> _dic;
                    public CardGenerator()
                    {
                        //_cardPool = new();

                    }

                }

                public class CardDataConfig
                {
                    //每个类型卡牌的数量、卡牌的id
                    private static List<GF.GQZL.DATA.CardConfig> _cardConfigList;
                    public CardDataConfig()
                    {
                        _cardConfigList = new List<GF.GQZL.DATA.CardConfig>();
                    }

                    public void GetRandomCardConfig(CardInfo cardInfo)
                    {

                    }
                }

            }

        }

    }


    namespace BUSINESS
    {

        #region 玩家模块 :状态机管理
        public class PlayerControl 
        {
           public INTERFACE_BUSINESS.IPlayerControl Behaviour;
          
            public PlayerControl(INTERFACE_BUSINESS.IPlayerControl control)
             {
                 Behaviour = control;
            }
        }
        public enum PlayerState
        {
              Walk = 1 << 0,
              Run = 1 << 1,
              Climb = 1 << 2,
              Fly = 1 << 3,
              FastFly = 1 << 4,
        }
        public class PlayerCenter
        {
            private StateMachineBase<PlayerState, GF.INTERFACE_FRAME.ISTATE_MACHINE.IState> _playerStateMachine;
            public PlayerCenter()
            {
                _playerStateMachine = new();
                StateInit();
                   
            }

            private void StateInit()
            {
                _playerStateMachine.StateRegister(PlayerState.Walk, new PlayerWalk());
                _playerStateMachine.StateRegister(PlayerState.Run, new PlayerRun());
                _playerStateMachine.StateRegister(PlayerState.Climb, new PlayerClimb());
                _playerStateMachine.StateRegister(PlayerState.Fly, new PlayerFly());
            }
        }

        public class PlayerWalk : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {
            public void Enter()
            {
            }
            public void Exit()
            {
            }
            public void Update()
            {
            }
        }
        public class PlayerRun : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {
            public void Enter()
            {
            }
            public void Exit()
            {
            }
            public void Update()
            {
            }
        }

        public class PlayerClimb : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {
            public void Enter()
            {
            }
            public void Exit()
            {
            }
            public void Update()
            {
            }
        }

        public class PlayerFly : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {
            public void Enter()
            {
            }
            public void Exit()
            {
            }
            public void Update()
            {
            }
        }


        #endregion

        #region 道具模块 :需要搭配ECS

        public class ItemSystem
        {
            public ItemSystem()
            {

            }
        }
        public class ItemEntity :Component
        {
            public string ItemID { get; set; }
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public Sprite ItemIcon { get; set; }
        }

        #endregion
    }


    //接口
    namespace INTERFACE_FRAME
    {
        namespace IFIGHT

        {
            public interface IFight
            {

            }
        }
        namespace IEVENT
        {


            public interface IEvt
            {
                public object GetMsg();
            }

            public interface IDisposable
            {
                public void Dispose();
            }



        }
        namespace ISTATE_MACHINE
        {
            public interface IState
            {
                public void Enter();
                public void Exit();

                public void Update();
            }

        }
        namespace ILOG
        {
            public interface ILoger
            {
                public void Log(string msg);
                public void LogWarning(string msg);
                public void LogError(string msg);
            }



        }

        namespace ITEXTPOINTER
        {
            public interface ITyper
            {
                float Speed { get; set; }
                bool IsTypeing { get; set; }
                IEnumerator TextShow();
            }
        }

        namespace ICARD
        {
            interface ICard
            {
                public string CardID { get; set; }
                public string CardName { get; set; }
                public ICurableCharacter CardTarget { get; set; }
            }

        }
        namespace ICHARACTER
        {
            public interface ICurableCharacter
            {
                public string CharacterID { get; set; }
                public string CharacterName { get; set; }
                public int HopeValue { get; set; }
                public int HappinessValue { get; set; }
                public CharacterSpecialState SpecialState { get; set; }
                public bool IsUnlock { get; set; }
                public CurableCharacterStage CurableCharacterStage { get; set; }

            }
        }
        public interface IDecision
        {
            public void Execute();
        }
        namespace IDATACENTER
        {
            public interface IDataCenter 
            {

                void Save(int slotIndex, IPlayerData playerData = null, ISaveInfo saveInfo = null, SystemConfig systemConfig = null);
                void LoadPlayerDataAsync(int slotIndex);
                void LoadSaveInfoAsync(int slotIndex);
                bool CheakSomeoneSlotIsSave(out bool isHaveSaveInfo, int index);
                public T GetTFromAb<T>(string a) where T : class;
            }

            public interface IPlayerData
            {
                public int slotIndex { get; set; }
            }
            public interface ISaveInfo
            {
                int slotIndex { get; set; }
                string RealTime { get; set; }
                string GameTime { get; set; }
            }
            public interface ISaveMgr : ISystemConfig
            {
                Task Save(int slotIndex, IPlayerData playerData = null, ISaveInfo saveInfo = null, SystemConfig systemConfig = null);
                Task<IPlayerData> LoadPlayerData(int slotIndex);
                Task<ISaveInfo> LoadSaveInfo(int slotIndex);
                bool CheakSomeoneSlotIsSave(out bool isHaveSaveInfo, int index);
                public T LoadConfigFromAb<T>(string a) where T : class;
            }
            public interface ISystemConfig
            {
                public Task<GF.GQZL.DATA.SystemConfig> GetSystemConfig();

            }
        }

        public interface IAssetMgr : IAb , IAudio , IPhoto
        {

        }

        public interface IAb
        {
            public GF.FUNCTION.TOKEN.ABToken LoadAbToken(string abName);
         
        }

        public interface IAudio
        {
            public void ChangeAudioClip();
        }
        public interface IPhoto
        {
            public void ChangeObjectImg();
        }
        public interface IMapper
        {
            public void Init();
            public T GetAsset<T> (string name) where T : UnityEngine.Object;
            public string MapperName { get; set; }
            public T GetInstance<T>(string name) where T : class ;
        }

        public interface IControl :System.IDisposable
        {
            public void Do<T>(BASICALMODEL.ChangeAssetInfo info, bool isCache, Action<T> action) where T : class;
        }


        public interface ICardEffect
        {
            void ApplyEffect();
            void ApplySpecialEffect(int effectIndex);
        }
    }
   namespace INTERFACE_BUSINESS
    {
        public interface IPlayerControl
        {
            void DoSomething();
        }
    }

    namespace FUNCTION
    {
        public static class Factory
        {
            public static T CreatT<T>(params System.Object[] args) where T : class
            {
                return Activator.CreateInstance(typeof(T), args) as T;
            }
        }

        public static class UnityComponentRegister
        {
            private static readonly Dictionary<string , ComponentRegisterControl> _dic = new Dictionary<string , ComponentRegisterControl>();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key">不能同名</param>
            /// <param name="component"></param>
            public static void RegisterToDic(string key, ComponentRegisterControl component)
            {
                if (_dic.ContainsKey(key)) throw new Exception(key + "同名错误");
                if (component = null) throw new Exception(component.name + "组件为空");
                _dic[key] = component;
            }
            public static bool TryGetComponent(string key , out ComponentRegisterControl component)
            {
                component = null;
                if(_dic.ContainsKey(key))
                {
                    component = _dic[key];
                    return true;
                }

                return false;
            }
            public static void UnRegister(string key)
            {
                if( _dic.ContainsKey(key))
                {
                    _dic.Remove(key);
                }

                return;
            }
        }

        namespace DECISION
        {
            public class DecisionNode : GF.INTERFACE_FRAME.IDecision
            {
                private GF.INTERFACE_FRAME.IDecision _nodeTrue;//可以是判断节点，也可以是动作节点。为真时走
                private GF.INTERFACE_FRAME.IDecision _nodeFalse;//同上，为假时走
                private Func<bool> _condition;//来自各个控件的bool

                public DecisionNode(Func<bool> func, GF.INTERFACE_FRAME.IDecision trueNode = null, GF.INTERFACE_FRAME.IDecision falseNode = null)
                {
                    _condition = func;
                    _nodeTrue = trueNode;
                    _nodeFalse = falseNode;
                }
                public void Execute()
                {
                    if (_condition.Invoke())
                    {
                        _nodeTrue?.Execute();
                    }
                    else
                    {
                        _nodeFalse?.Execute();
                    }
                }
            }

            public class ActionNode : GF.INTERFACE_FRAME.IDecision
            {
                private Action _action;
                public ActionNode(Action action)
                {
                    _action = action;
                }
                public void Execute()
                {

                }
            }
            public class DecisionRoot
            {
                private GF.INTERFACE_FRAME.IDecision _decisionNode;
                public DecisionRoot(GF.INTERFACE_FRAME.IDecision decisionNode)
                {
                    _decisionNode = decisionNode;
                }

                public void DoExecute()
                {
                    _decisionNode.Execute();
                }

                public void Update()
                {
                    DoExecute();
                }
            }
        }
        public class Debugger : INTERFACE_FRAME.ILOG.ILoger
        {
            public void Log(string msg)
            {
                Debug.Log(msg);
            }
            public void LogWarning(string msg)
            {
                Debug.LogWarning(msg);
            }
            public void LogError(string msg)
            {
                Debug.LogError(msg);
            }
        }
        namespace TOKEN
        {
            public sealed class ObjectPoolToken<T> : System.IDisposable
                                                where T : class, new()
                                                

            {

                Action<T> _action;
                private T _obj;


                public ObjectPoolToken(Action<T> action, T obj)
                {
                    _action = action;
                    _obj = obj;
                }


                public void Dispose()
                {
                    _action(_obj);
                    _obj = null;

                }


            }

            /// <summary>
            /// 通过令牌操控ab包加载资源
            /// </summary>
            public class ABToken : System.IDisposable
            {

                private Action<ABToken> _remove;
                private string[] _dependency;//当前ab包的依赖包
                private Type assetType;
                public string ABName { get; set; }
                private AssetBundle _aB;
                public ABToken(string abName, Action<ABToken> action,  AssetBundle aB ,Type type = null , string[] dependencyPackage =null)
                {
                    ABName = abName;
                    _remove = action;
                    assetType = type;
                    _dependency = dependencyPackage;
                    _aB = aB;

                    Debug.Log(abName + "创建中");
                }
                public void Dispose()
                {
                    Unload();
                    _remove?.Invoke(this);
                    _aB = null;
                    ABName = null;

                }
                public IEnumerator LoadAssetAsync<T>(string assetsName  , Action<T> callback) where T : UnityEngine.Object
                {
                    if (!_aB.Contains(assetsName))
                        throw new Exception($"{assetsName}不存在 , 请检查资源名称是否有误");
                    
                    AssetBundleRequest abR  =  _aB.LoadAssetAsync(assetsName);
                    yield return abR;

                    if (abR.asset == null) yield break;
                    
                    callback.Invoke((T) abR.asset); 

                }
                public T LoadAssetByToken<T>(string assetsName)where T : UnityEngine.Object
                {
                    if (!_aB.Contains(assetsName))
                    {
                        throw new Exception($"{assetsName}不存在 , 请检查资源名称是否有误");
                    }
                    T temp = _aB.LoadAsset<T>(assetsName);
                    _ = temp ?? throw new Exception($"资源名称不正确，{assetsName}");
                    return temp;
                }
                private void Unload(bool isUnloadAllLoadedObjects = false)
                {
                    _aB.Unload(isUnloadAllLoadedObjects);
                }

            }
            public sealed class EvtToken<T> : System.IDisposable
             where T : INTERFACE_FRAME.IEVENT.IEvt

            {
                private readonly Action _unsubscribe;
                private bool _disposed;

                internal EvtToken(Action unsubscribe)
                {
                    _unsubscribe = unsubscribe;
                }

                public void Dispose()
                {
                    if (_disposed) return;
                    _disposed = true;
                    _unsubscribe();
                }

            }
        }
    
        public static class ToolClass
        {
            public static void QuickSort<T>(IList<T> list) where T : IComparable<T> 
            {

            }

            private static void GetPivot()
            {

            }
        }

    
    }
    //事件总线
    namespace EVENT_BUS
    {

        public sealed class EventBus
        {

            private readonly Dictionary<Type, List<Delegate>> _handlers;
            private readonly ReaderWriterLockSlim _lock ;

            public EventBus() { 
                _handlers = new Dictionary<Type, List<Delegate>>();
                _lock = new ReaderWriterLockSlim();

            }


            public GF.FUNCTION.TOKEN.EvtToken<T> Subscribe<T>(Action<T> handler)
                where T : INTERFACE_FRAME.IEVENT.IEvt
            {
                if (handler == null) throw new ArgumentNullException(nameof(handler));

                _lock.EnterWriteLock();
                try
                {
                    var type = typeof(T);

                    if (!_handlers.TryGetValue(type, out var list))
                    {
                        list = new List<Delegate>();
                        _handlers[type] = list;
                    }

                    list.Add(handler);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }

                return new GF.FUNCTION.TOKEN.EvtToken<T>(() => Unsubscribe(handler));
            }

            public void Publish<T>(T evt)
        where T : INTERFACE_FRAME.IEVENT.IEvt
            {
                _lock.EnterReadLock();
                try
                {
                    if (!_handlers.TryGetValue(typeof(T), out var list))
                        return;

                    foreach (var d in list.ToArray()) // 快照
                    {
                        try
                        {
                            ((Action<T>)d)(evt);
                        }
                        catch (Exception)
                        {
                            Debug.Log($"EventBus ：{d}   出错");
                        }
                    }
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
            private void Unsubscribe<T>(Action<T> handler)
         where T : INTERFACE_FRAME.IEVENT.IEvt
            {
                _lock.EnterWriteLock();
                try
                {
                    var type = typeof(T);
                    if (!_handlers.TryGetValue(type, out var list))
                        return;

                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (list[i] == (Delegate)handler)
                        {
                            list.RemoveAt(i);
                            break;
                        }
                    }

                    if (list.Count == 0)
                        _handlers.Remove(type);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
        }

    }
 
    namespace USEFUL_BASE
    {


        public class StateBase : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {

            public void Enter()
            {

            }
            public void Exit()
            {

            }

            public void Update()
            {

            }

        }

        /// <summary>
        /// 互斥状态机
        /// </summary>
        /// <typeparam name="T1">枚举类</typeparam>
        /// <typeparam name="T2">接口类</typeparam>
        public class StateMachineBase<T1, T2> where T1 : Enum where T2 : class, GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
        {
            private readonly object _instanceLock = new object();
            private Dictionary<T1, T2> _dictionary = new Dictionary<T1, T2>();
            private T2 _curState;


            public void StateRegister(T1 state, T2 temp)
            {
                lock (_instanceLock)
                {
                    _ = temp ?? throw new ArgumentNullException(nameof(temp));
                    if (_dictionary.ContainsKey(state))
                    {

                        return;
                    }
                    _dictionary.Add(state, temp);
                }

            }

            public void ChangeState(T1 state)
            {
                lock (_instanceLock)
                {
                    if (_dictionary.TryGetValue(state, out var temp))
                    {
                        if (temp == _curState) return;
                        _curState?.Exit();
                        temp.Enter();
                        _curState = temp;
                    }
                }

            }
            public void Update()
            {
                _curState?.Update();
            }
        }

        /// <summary>
        /// 通用对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ObjectPool<T> where T : class, new()
        {
            private readonly object _lock = new object();
            private T[] _tArray;
            public int MaxCount { private set; get; }
            public int NowCount { get; private set; }
            public ObjectPool(int poolDepth)
            {
                lock (_lock)
                {
                    MaxCount = poolDepth;
                    _tArray = new T[poolDepth];
                }


            }

            public void PoolInit()
            {
                lock (_lock)
                {
                    NowCount = 0;
                    for (int i = 0; i < _tArray.Length; i++)
                    {
                        _tArray[i] = new T();
                       
                    }
                    NowCount = MaxCount;
                }


            }

            /// <summary>
            ///  返回令牌
            /// </summary>
            /// <returns></returns>
            public ObjectPoolToken<T> GetObj()
            {
                lock (_lock)
                {

                    if (NowCount <= 0) return null;

                    T temp = _tArray[NowCount - 1];
                    _tArray[NowCount - 1] = null;
                    NowCount--;
                    return new ObjectPoolToken<T>(this.BackToPool, temp);
                }

            }

            private void BackToPool(T obj)
            {
                lock (_lock)
                {
                    //判断池是否已满
                    if (MaxCount <= NowCount) return;

                    _tArray[NowCount - 1] = obj;
                    NowCount++;
                }

            }

        }

        public class UnityObjectPool
        {
           
            private int NowCount;
            private int MaxCount;
            private GameObject[] gameObjects;

            public UnityObjectPool(int max)
            {
               
                MaxCount = max;
                gameObjects = new GameObject[MaxCount];
                
            }

            public void UnityObjectPoolInit(Func<GameObject> Prefab , params Type[] components)
            {
                for (int i = 0;i < MaxCount; i++)
                {
                    gameObjects[i] = GameObject.Instantiate(Prefab());
                    foreach (var component in components)
                    {
                        if (typeof(UnityEngine.Component).IsAssignableFrom(component))continue;
                        
                        gameObjects[i].AddComponent(component);
                    }
                    gameObjects[i].SetActive(false); 

                }

                NowCount = MaxCount;

            }

            public ObjectPoolToken<GameObject> GetUnityObject()
            {
                
                if(NowCount <= 0 ) return null;
                GameObject a = gameObjects[NowCount - 1];
                a.SetActive(true);
                gameObjects[NowCount - 1] = null;
                NowCount--;
                return new ObjectPoolToken<GameObject>(BackToPool,a );
            }

            private void BackToPool(GameObject @gameObject)
            {
                if(NowCount == MaxCount)return;

                @gameObject.gameObject.SetActive(false);
                NowCount++;
                gameObjects[NowCount - 1] = @gameObject;
                
            }
        }
    }

    namespace EVENTS
    {


        /// <summary>
        /// 切换游戏全局状态的事件
        /// </summary>
        public sealed class ChangeGameState : GF.INTERFACE_FRAME.IEVENT.IEvt
        {
            private readonly object _msgBox;
            public ChangeGameState(GF.BASICALMODEL.GameState gameState)
            {
                _msgBox = gameState;
            }
            public object GetMsg()
            {
                return _msgBox!;
            }

        }

        /// <summary>
        /// 切换游戏模式
        /// </summary>
        public sealed class ChangePlayingModel : GF.INTERFACE_FRAME.IEVENT.IEvt
        {
            private readonly object _msgBox;
            public ChangePlayingModel(GF.INTERFACE_FRAME.IFIGHT.IFight fight)
            {
                _msgBox = fight;
            }
            public object GetMsg()
            {
                return _msgBox;
            }
        }


    }


    namespace BASICALMODEL
    {
       
            namespace GAME_STATE_CLASS
            {
                public class GameReadyState : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                    public void Enter()
                    {

                    }
                    public void Exit()
                    {

                    }
                    public void Update()
                    {

                    }
                }
                public class GamePlayingState : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                   
                    public void Enter()
                    {

                    }
                    public void Exit()
                    {

                    }
                    public void Update()
                    {

                    }
                }
                public class GameStoringState : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                    public void Enter()
                    {

                    }
                    public void Exit()
                    {

                    }
                    public void Update()
                    {

                    }
                }
                public class GameStopState : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                    public void Enter()
                    {

                    }
                    public void Exit()
                    {

                    }
                    public void Update()
                    {

                    }

                }


                /// <summary>
                /// 新生态：加载一切存档信息头、读取游戏配置到CacheMgr中
                /// </summary>
                public class GameNewBorn : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                    public delegate bool CheakIsSave(out bool isHaveSaveInfo, int slotIndex);
                    private CheakIsSave _cheakIsSave;

                    public GameNewBorn(CheakIsSave call)
                    {
                        _cheakIsSave = call;
                    }
                    public void Enter()
                    {
                        //等待加载配置
                    }
                    public void Exit()
                    {
                        //分发配置到各个模块
                    }
                    public void Update()
                    {
                        //无
                    }

                }
                public class GameOver : GF.INTERFACE_FRAME.ISTATE_MACHINE.IState
                {
                    public void Enter()
                    {

                    }
                    public void Exit()
                    {

                    }
                    public void Update()
                    {

                    }
                }
            }
            public enum GameState
            {
                READY = 1,//就绪
                PLAYING = 1 << 1,//运行
                STORING = 1 << 2,//存档
                STOP = 1 << 3,//阻塞
                NEWBORN = 1 << 4,//新生
                OVER = 1 << 5,//结束
            }
            /// <summary>
            /// as the most heightest manager of the game,it'could not be refed in others
            /// </summary>
            public sealed class GameMgr
            {

                private static readonly object _lockObj = new object();
                private static GameMgr Instance { get; set; }
                public static DataCenter Instance_data { get; private set; }
                private static StateMachineBase<GameState, GF.INTERFACE_FRAME.ISTATE_MACHINE.IState> _gameStateMachine = new();
     
                public GameMgr( )
                {
                    lock (_lockObj)
                    {
                        Instance_data = new DataCenter();
                        Instance = this;
                        GSMInit();
                    }

                }

                private void GSMInit()
                {
                    _gameStateMachine.StateRegister(GameState.NEWBORN, new GAME_STATE_CLASS.GameNewBorn(Instance_data.CheakSomeoneSlotIsSave));
                    _gameStateMachine.StateRegister(GameState.READY, new GAME_STATE_CLASS.GameReadyState());
                    _gameStateMachine.StateRegister(GameState.PLAYING, new GAME_STATE_CLASS.GamePlayingState());
                    _gameStateMachine.StateRegister(GameState.STORING, new GAME_STATE_CLASS.GameStoringState());
                    _gameStateMachine.StateRegister(GameState.STOP, new GAME_STATE_CLASS.GameStopState());
                    _gameStateMachine.StateRegister(GameState.OVER, new GAME_STATE_CLASS.GameOver());

                }

                public void ChangeGameState(GF.EVENTS.ChangeGameState evt)
                {
                    GameState gameState = (GameState)evt.GetMsg();
                    _gameStateMachine.ChangeState(gameState);
                }

            }

        
            public class AssetMgr
            {

                private readonly List<GF.INTERFACE_FRAME.IMapper> _mappersList;
               

                private AbControl _abControl;
                private GF.INTERFACE_FRAME.IControl _assetControl;

                public AssetMgr( AbControl abControl = null)
                {
                    _abControl = abControl;
                    _mappersList = new List<GF.INTERFACE_FRAME.IMapper>();   
                    MakeMapper();
                }

                #region 辅助
                private IMapper GetMapperFromList(string mapperName)
                {
                    if(!TryGetMapperFromList(mapperName , out var mapper))
                    {
                        throw new Exception($"{mapperName}不存在");
                    }
                    
                    return mapper;
                }
                private void MakeMapper()
                {
                    List<ABToken> abs = _abControl.LoadAbTokens();

                    for (int i = 0; i < abs.Count; i++)
                    {
                        if (abs[i] == null) continue;
                        _mappersList.Add(new AssetInfoMaper<UnityEngine.Object>(abs[i]));

                        Debug.Log("mapper has been created");
                        
                    }
                }

                private void MakeMapperToList()
                {
                    List<ABToken> aBTokens = _abControl.LoadAbTokens();
                    for(int i = 0; i < aBTokens.Count; i ++)
                    {
                        _mappersList[i] = new AssetInfoMaper<UnityEngine.Object>(aBTokens[i] );
                    }
                }


                #endregion

                /// <summary>
                /// 业务接口：加载资源。自动解析传入的Info然后生成对应策略
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="info"></param>
                /// <param name="action"></param>
                /// <param name="isCache"></param>
                public void Do<T>(ChangeAssetInfo info , Action<T> action  , bool isCache)where T : class
                {
                    IControl newPolicy;
                    if (!TryGetMapperFromList(info.MapName, out var mapper))
                    {
                        throw new Exception("策略生成错误");
                    }
                    if (info.TA == TypeOfAsset.Instance)//如果类型是实例
                    {
                       
                        newPolicy = Factory.CreatT<GetTInstanceFromAssetModel>(mapper);
                    }
                    else
                    {
                        newPolicy = Factory.CreatT<GetResourcesRefFromAssetModel>(mapper);
                    }


                    _assetControl = newPolicy;
                    _assetControl.Do(
                        info,
                        isCache,
                        action
                        );
                }


                /// <summary>
                /// mapper引用获取,方法仅供策略类使用
                /// </summary>
                /// <param name="Name"></param>
                /// <param name="mapper"></param>
                /// <returns></returns>
                private bool TryGetMapperFromList(string Name, out IMapper mapper)
                {

                    //要防止引用混乱
                    mapper = null;
                    bool isExist = false;
                    for (int i = 0; i < _mappersList.Count; i++)
                    {
                        if (_mappersList[i].MapperName == Name)
                        {
                            mapper = _mappersList[i];
                            isExist = true;
                            break;
                        }
                        continue;
                    }
                    return isExist;

                }
            }



            /// <summary>
            /// 【可多线程】只负责令牌的分发，ab包令牌具有加载/卸载资源的功能
            /// </summary>
            public class AbControl : GF.INTERFACE_FRAME.IAb
            {
                private readonly List<ABToken> _abList;
                private readonly object _locker = new object();
                public AbControl(string[] strings)
                {
                    _abList = new List<ABToken>();
                    CreatAbToken(strings);
                }

                public GF.FUNCTION.TOKEN.ABToken LoadAbToken(string abName)
                {
                    lock( _locker )
                    {
                        if (!TryGetAbTokenFromList(abName, out var t))
                        {
                            return t;
                        }

                        return t;
                    }
               
                }

                public List<ABToken> LoadAbTokens(string[] strings = null)
                {

                    if (_abList.Count > 0) return _abList;
                    CreatAbToken(strings);

                    return _abList;
                }
               

                #region 辅助
                private void BackToList(ABToken token)
                {
                    lock (_locker)
                    {
                        for (int i = 0; i < _abList.Count; i++)
                        {
                            if (_abList[i] == null) _abList[i] = token;
                            else continue;
                        }
                    }
                   
                   
                }


                /// <summary>
                ///【禁多线程】重点： 制作AB包令牌。只在构造函数中进行一次
                /// </summary>
                /// <param name="strings"></param>
                private void CreatAbToken(string[] strings)
                {
                    int i = 0;
                    foreach(string s in strings) 
                    {

                      
                        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + s);
                        ABToken aBToken = new ABToken(s, BackToList, ab) { ABName = s };
                        _abList.Add( aBToken);
                        i++;
                        ab = null;
                    }

                }

                private  bool TryGetAbTokenFromList(string abName , out GF.FUNCTION.TOKEN.ABToken token)
                {
                     token = null;
                     bool isExist = false;
                    for (int i  = 0;  i < _abList.Count; i++)
                    {
                        if (_abList[i] == null) continue;
                        else if(_abList[i ].ABName == abName)
                        {
                            token = _abList[i ];
                            isExist = true;
                            _abList[i] = null;
                            break;
                        }
                            
                    }
                 

                    return isExist;
                }

                #endregion

            }

            #region AssetMgr的策略

            /// <summary>
            /// 从资源模块获得资产的引用
            /// </summary>
            public sealed class GetResourcesRefFromAssetModel :GF.INTERFACE_FRAME.IControl
            {

                private IMapper _mapper;
                public GetResourcesRefFromAssetModel(IMapper mapper1 )
                {
                    _mapper = mapper1;
                }
                 public void Do<T>( ChangeAssetInfo info,bool isCache ,Action<T> action = null ) where T : class
                {
                    if (_mapper == null) throw new ArgumentNullException(nameof(_mapper));
                    if (info == null) throw new ArgumentNullException(nameof(info));

                    switch (info.TA)
                    {
                        case TypeOfAsset.Photo:
                            if (UnityComponentRegister.TryGetComponent(info.componentKey, out var sC))
                            {
                                Image image = sC.GetComponentByMono<Image>();
                                image.sprite = _mapper.GetAsset<Sprite>(info.assetName) ?? throw new Exception($"图片 找不到对应资产{info.assetName}");
                            }
                            break;
                        case TypeOfAsset.Music:
                            if (UnityComponentRegister.TryGetComponent(info.componentKey  , out var a ))
                            {
                                AudioSource audioSource =  a.GetComponentByMono<AudioSource>();
                                audioSource.clip = _mapper.GetAsset<AudioClip>(info.assetName) ?? throw new Exception($"音乐 找不到对应资产{info.assetName}");
                            }
                            break;
                        case TypeOfAsset.Text:
                            TextAsset c = _mapper.GetAsset<TextAsset>(info.assetName) ?? throw new Exception($"文本 找不到对应资产{info.assetName}");
                            action(c as T);
                            break;



                    }


                    info.ClearComponent();

                 }

                public void Dispose()
                {
                    _mapper = null;
                }
             
            }

            /// <summary>
            /// 从资源模块得到配置示例
            /// </summary>
            public sealed class GetTInstanceFromAssetModel: GF.INTERFACE_FRAME.IControl
            {
                public IMapper _mapper;
                public GetTInstanceFromAssetModel(IMapper mapper)
                {
                    _mapper = mapper;
                }

                /// <summary>
                /// 行为：从资源模块得到配置示例，原则上仅限于文本类资源。通过反序列化得到配置实例，并通过回调传出
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="info"></param>
                /// <param name="isCache">是否缓存。原则上仅缓存类的实例</param>
                /// <param name="action"></param>
                public void Do<T>(ChangeAssetInfo info, bool isCache, Action<T>action )where T :class
                {
                   T temp = _mapper.GetInstance<T>(info.assetName);
                   action( temp );

                    if (isCache)
                    {

                        CacheManager.Instance.LoadToCache(info.assetName, temp);
                    }

                }

                public void Dispose()
                {
                    _mapper = null;
                }
            }

            #endregion
            public enum TypeOfAsset
            {
                Photo = 1,
                Music = 1 << 1,
                AB = 1 <<2,
                Text = 1 << 3,
                Instance = 1 << 4,
            }


            /// <summary>
            /// 信息类
            /// </summary>
            public class ChangeAssetInfo//可以再抽象一个接口
            {
                public TypeOfAsset TA;
                public string assetName;
                public string MapName;
                public string componentKey;

                /// <summary>
                /// 
                /// </summary>
                /// <param name="tA">是一个枚举类型</param>
                /// <param name="assetName">资源在ab包中的名字</param>
                /// <param name="mapName">ab包的名字</param>
                /// <param name="targetComponentKey">unity组件</param>
                public ChangeAssetInfo(TypeOfAsset tA, string assetName, string mapName, string targetComponentKey)
                {
                    TA = tA;
                    this.assetName = assetName;
                    MapName = mapName;
                    this.componentKey = targetComponentKey;
                }

                public void ClearComponent()
                {
                    componentKey = null;
                }
            }
            /// <summary>
            /// 【禁用多线程】资源映射器：持有ab包令牌的引用，负责从ab包中加载资源并存储在字典中以供查询。每个mapper只负责一种类型的资源
            /// 只缓存同种资源。原则上类的示例应该放在CacheManager中，但考虑到资源模块的特殊性，允许mapper缓存类的实例
            /// </summary>
            public class AssetInfoMaper<AssetType> : GF.INTERFACE_FRAME.IMapper, System.IDisposable
                where AssetType : UnityEngine.Object
            {
                private readonly Dictionary<string, AssetType> _sMap = new();
                
                private ABToken _assetToken;//依赖于令牌和系统配置完成注册
                public string MapperName { get; set; }
                public AssetInfoMaper(ABToken assetToken)
                {
                    _assetToken = assetToken;
                    MapperName = assetToken.ABName;
                }

                #region api
                public void Init()
                {


                }

       
                public T GetAsset<T>(string name) where T : UnityEngine.Object
                {
                    //先在查询字典是否存在想要的，如果没有就从ab包中读取并存储在字典中，如果ab包里也没有，就返回空
                    if(name == null)return null;
                    if(_sMap.TryGetValue(name , out var asset)  )
                    {
                        _sMap[name] = null ;
                        return asset as T;
                    }
                  
                    AssetType temp_t = _assetToken.LoadAssetByToken<AssetType>(name);
                    AddToDic(name, temp_t);
                    _sMap[name] = null;


                    return temp_t as T;
                  

                    
                }
                public T GetInstance<T>(string name)where T :class 
                {
                     string a =GetAsset<TextAsset>(name).text;
                    if (a == null) throw new Exception("获取配置失败，请先检对照ab包查名称是否出错");
                    
                     return JsonUtility.FromJson<T>(a);
                }

                /// <summary>
                /// 只卸载ab包，不释放缓存
                /// </summary>
                public void Dispose()
                {
                    
                    _assetToken.Dispose();
                    _assetToken = null;
                }

                #endregion

                #region 辅助
                private void AddToDic(string assetName, AssetType value)
                {

                    if (_sMap.ContainsKey(assetName)) Debug.LogError("重名错误" + assetName);
                    if (value == null) Debug.LogError("value 为空");

                    _sMap.Add(assetName, value);
                }
                #endregion
            }
        


      


            public class UIMgr
            {
                /*UIMgr职责：
                    *一、UI模块内存管理：并非所有ui面板都应该加载到内存，应该进行动态加载和卸载：
                        *策略一：提前分析游戏内常驻UI面板，最近最小使用先卸载
                        *策略二：预加载、不卸载
                        *策略三：临时面板（打开才加载，关闭立刻卸载）

                     二、展示/关闭指定UI面板
                   */

                private readonly List<UIPanel> _uiPanelList;
                private UILRU _uILRU;

                
            }
            public class UILRU
            {
                private static readonly List<LRUInfo> _lRUInfos = new List<LRUInfo>();
                private const int _maxPanelCount = 5;
                public UILRU()
                {
                    
                }
         
                public void RegisterInfo(LRUInfo info , out LRUInfo outInfo)
                {
                    if(TryGetInfoFromList(info.ObjectName , out var lRUInfo))
                    {
                        throw new Exception("LRU信息注册时ui名称重复");
                    }
                    outInfo = null;

                    if(_lRUInfos.Count < _maxPanelCount)
                    _lRUInfos.Add(info);
                    else//从最远端排出一个LRUInfo
                    {
                       // outInfo = GetInfoFromList();
                    }
                }


         
                public void UpdataInfo(string name , float interval)
                {
                    if(TryGetInfoFromList(name , out var info)) 
                    {
                        info.Interval = interval;
                    }
                    else
                    {
                        throw new Exception("更新时没找到这个物体的LRU信息");
                    }
                }

                #region 辅助
                private bool TryGetInfoFromList(string name , out LRUInfo lRUInfo)
                {
                    lRUInfo = null;
                    for(int i = 0; i < _lRUInfos.Count; i++)
                    {
                        if (_lRUInfos[i].ObjectName == name)
                        {
                            lRUInfo= _lRUInfos[i];

                            return true;
                        }
                    }
                    return false;
                }

              /*  private LRUInfo GetInfoFromList()
                {
                    //只释放List最远端、只在有新对象进入时释放
                    SortByTime();

                }*/
                private void SortByTime()
                {

                    for (int i = 0;i < _lRUInfos.Count; i ++ )
                    {
                        for(int j = 0;j < _lRUInfos.Count; j++)
                        {
                            if(_lRUInfos[i].Interval > _lRUInfos[j].Interval && i < j)//比较谁大，大的排在后面
                            {
                                LRUInfo bigger =_lRUInfos[i];
                                LRUInfo other = _lRUInfos[j];

                                _lRUInfos[i] = other;
                                _lRUInfos[j] = bigger;

                            }
                        }
                    }
                }
                #endregion
            }
            public class UIPanel : MonoBehaviour
            {
                //职责：实现打开和关闭面板的功能
                private void Awake()
                {
                    new LRUInfo() { ObjectName = gameObject.name ,
                                    Interval = 0            ,
                                     };
                }
                private void OnDestroy()
                {
                    
                }
                public void Open()
                {
                    
                }

                public void Close()
                {

                }
            }
            public class LRUInfo
            {
                public string ObjectName {  get; set; }
                public float Interval {  get; set; }
                public int Quotation {  get; set; }
            }
        

    }

   

    namespace GQZL
    {

        namespace DATA
        {

            public class DataCenter : GF.INTERFACE_FRAME.IDATACENTER.IDataCenter
            {
                public static DataCenter Instance { get; private set; }
                private static GF.INTERFACE_FRAME.IDATACENTER.ISaveMgr _saveManager;
                public DataCenter()
                {
                    _saveManager = new SaveManager();
                    Instance = this;
                }

                public async Task<SystemConfig> GetSystemConfig()
                {
                    return await _saveManager.GetSystemConfig();
                }
                public void Save(int slotIndex, GF.INTERFACE_FRAME.IDATACENTER.IPlayerData playerData = null, GF.INTERFACE_FRAME.IDATACENTER.ISaveInfo saveInfo = null, SystemConfig systemConfig = null)
                {
                    _saveManager.Save(slotIndex, playerData, saveInfo, systemConfig);
                }

                public bool CheakSomeoneSlotIsSave(out bool isHaveSaveInfo, int index)
                {
                    return _saveManager.CheakSomeoneSlotIsSave(out isHaveSaveInfo, index);
                }
                public async void LoadPlayerDataAsync(int slotIndex)
                {

                    await _saveManager.LoadPlayerData(slotIndex);
                }
                public async void LoadSaveInfoAsync(int slotIndex)
                {
                    await _saveManager.LoadSaveInfo(slotIndex);
                }
                public T GetTFromAb<T> (string a)where T : class
                {
                   return _saveManager.LoadConfigFromAb<T>(a);
                }
            }

            #region 高层数据：游戏配置、玩家数据、存储信息

            //游戏配置：全部卡牌配置和系统配置
            //卡牌配置：卡牌的类型、数量、ID、描述
            //系统配置：声音大小、文字速度、卡牌总量
            //游戏配置的加载时机：游戏进入新生态。游戏配置放在ab包的text_ab包中，然后通过Datacenter得到GameConfig的实例

            //玩家数据（存储在持久化目录中）：是否第一次游玩、所有人物的解锁状态、存储目录

            //加载时机：游戏进入就绪态
            [System.Serializable]
            public class GameConfig
            {
                public int MaxCardInHand;
                public int MaxCardInCardHeap;
                public float MusicVolume;
                public float SpeakerVolume;
                public float TextShowSpeed;

                
                public List<CardConfig> CardConfigList;
                public string[] AbNames;
                public GameConfig()
                {
                    CardConfigList = new List<CardConfig>();
                }
            }

            [System.Serializable]
            public class PlayerData : GF.INTERFACE_FRAME.IDATACENTER.IPlayerData
            {
                public bool isFirstPlay;
                public CharacterChainList characterChainList;
                public int slotIndex { get; set; }
            }

            [System.Serializable]
            public class SaveInfo : GF.INTERFACE_FRAME.IDATACENTER.ISaveInfo
            {
                public int slotIndex { get; set; }
                public int SlotIndex;
                public string chapterName;
                public string GameTime { get; set; }
                public string gameTime;
                public string RealTime { get; set; }
                public string realTime;
            }


            [System.Serializable]
            public class CardData
            {

                public string id;
                public int type;
                public string name;
                public string description;
                public int deckCount;

                public CardBaseEffect baseEffect;
                public List<CardSpecialEffect> specialEffects = new();
            }



            [System.Serializable]
            public class SystemConfig
            {
                public int MaxCardInHand;
                public int MaxCardInCardHeap;
                public float MusicVolume;
                public float SpeakerVolume;
                public float TextShowSpeed;

            }
            [System.Serializable]
            public class CardConfig
            {
                public string CardID;
                public int CardType;
                public string CardDescribe;
                public string CardName;
                public int MaxCount;
            }

            #endregion

            #region 底层数据

            [System.Serializable]
            public class CardBaseEffect
            {
                public int moodDelta;
                public int energyDelta;
            }

            [System.Serializable]
            public class CardSpecialEffect
            {
                public string dsl;
            }


            [System.Serializable]
            public enum CardType
            {
                EX = 1,
                TYPE2 = 1 << 1,
                TYPE3 = 1 << 2,
            }
            [System.Serializable]
            public class CharacterChainList
            {
                public List<CharacterData> allCharactersDataList;
            }

            [System.Serializable]
            public class CharacterData 
            {
                public string CID;
                public string CName;
                public int HopeValue;
                public int HappyValue;
                public CharacterSpecialState SpecialState;
                public bool Islock;
                public CurableCharacterStage CurableCStage;
            }

            [System.Serializable]
            public enum CharacterSpecialState
            {
                SENSITIVE = 1 << 0,
                ANGRY = 1 << 1,
                SAD = 1 << 2,
            }

            [System.Serializable]
            public enum CurableCharacterStage
            {
                STAGE_ONE = 1 << 0,
                STAGE_TWO = 1 << 1,
                FINISHIED = 1 << 2,
            }

    

            #endregion
            

            #region 存储管理器实现
            /// <summary>
            /// 完全依赖Unity,禁多线程,只能在主线程进行，0号卡槽为游戏默认存档，一切自动保存均在0号卡槽
            /// </summary>
            public class SaveManager : GF.INTERFACE_FRAME.IDATACENTER.ISaveMgr
            {
                private static readonly string _savePath = Application.persistentDataPath;//可读写目录路径
                private const int _maxSlot = 12;//最大卡槽
                private static readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);//只允许一个线程去写

                #region 对外接口

                public async Task Save(int index, IPlayerData playerData = null, ISaveInfo saveInfo = null, SystemConfig systemConfig = null)
                {

                    if (index < 0 || index >= _maxSlot)
                    {
                        Debug.LogError("索引越界，请检查");
                    }

                    try
                    {
                        await semaphoreSlim.WaitAsync();

                        try
                        {
                            if (playerData != null)
                            {

                                //玩家数据
                                string path = GetPlayerPath(index);
                                string temppath = path + ".temp";
                                string data = JsonUtility.ToJson((PlayerData)playerData, true);

                                await System.IO.File.WriteAllBytesAsync(temppath, System.Text.Encoding.UTF8.GetBytes(data));
                                if(System.IO.File.Exists(path)) System.IO.File.Delete(path);
                                System.IO.File.Move(temppath, path);
                            }

                        }
                        catch (Exception e)
                        {
                            Debug.Log(e.ToString() + "存储玩家数据时出现错误");
                            //删除临时文件
                            string temppath = GetPlayerPath(index) + ".temp";
                            if (System.IO.File.Exists(temppath))
                            {
                                System.IO.File.Delete(temppath);
                            }
                        }

                        try
                        {
                            if (saveInfo != null)
                            {
                                //存档头数据
                                string path1 = GetInfoPath(index);
                                string temppath1 = path1 + ".temp";
                                string data1 = JsonUtility.ToJson((SaveInfo)saveInfo, true);
                                await System.IO.File.WriteAllBytesAsync(temppath1, System.Text.Encoding.UTF8.GetBytes(data1));
                                if (System.IO.File.Exists(path1)) System.IO.File.Delete(path1);
                                System.IO.File.Move(temppath1, path1);
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e.ToString() + "存档头存储失败");
                            //删除临时文件
                            string temppath = GetInfoPath(index) + ".temp";
                            if (System.IO.File.Exists(temppath))
                            {
                                System.IO.File.Delete(temppath);
                            }

                        }



                        try
                        {

                            if (systemConfig != null)
                            {
                                string path2 = GetConfigPath();
                                string data2 = JsonUtility.ToJson(systemConfig, true);
                                string temppath2 = path2 + ".temp";
                                await System.IO.File.WriteAllBytesAsync(temppath2, System.Text.Encoding.UTF8.GetBytes(data2));
                                if (System.IO.File.Exists(path2)) System.IO.File.Delete(path2);
                                System.IO.File.Move(temppath2, path2);
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e.ToString() + "系统配置存储失败");
                            //删除临时文件
                            string temppath = GetConfigPath() + ".temp";
                            if (System.IO.File.Exists(temppath))
                            {
                                System.IO.File.Delete(temppath);
                            }




                        }
                    }
                    finally
                    {
                        semaphoreSlim.Release();  
                    }
                 
                }

                public async Task<GF.GQZL.DATA.SystemConfig> GetSystemConfig()
                {
                    //得到默认系统配置，先查看默认路径是否存在玩家设置的系统配置，如果存在则读取并返回，如果不存在则返回默认系统配置
                    string path = GetConfigPath();
                    if (System.IO.File.Exists(path))
                    {
                        byte[] bytes = await Task.Run(() => { return System.IO.File.ReadAllBytes(path); });
                        string data =System.Text.Encoding.UTF8.GetString(bytes);
                        return JsonUtility.FromJson<GF.GQZL.DATA.SystemConfig>(data);
                    }

                    //返回默认系统配置
                    return new GF.GQZL.DATA.SystemConfig()
                    {
                        MaxCardInHand = 5,
                        MaxCardInCardHeap = 20,
                        MusicVolume = 0.5f,
                        SpeakerVolume = 0.5f,
                        TextShowSpeed = 1f,
                    };

                }

                /// <summary>
                /// 给UI看的存档头
                /// </summary>
                /// <param name="index"></param>
                /// <returns></returns>
                public async Task<ISaveInfo> LoadSaveInfo(int index)
                {
                    if (!System.IO.File.Exists(GetInfoPath(index)) || index >= _maxSlot)
                    {
                        return null;
                    }
                    byte[] bytes = await Task.Run(() => { return System.IO.File.ReadAllBytes(GetInfoPath(index)); });
                    string saveMsg = System.Text.Encoding.UTF8.GetString(bytes);
                    ISaveInfo a = JsonUtility.FromJson<SaveInfo>(saveMsg);
                    return a;
                }
                public async Task<IPlayerData> LoadPlayerData(int index)
                {
                    if (!System.IO.File.Exists(GetPlayerPath(index)) || index >= _maxSlot) { return null; }
                 
                    byte[] ao  = await Task.Run(() =>
                    {
                        return System.IO.File.ReadAllBytes(GetPlayerPath(index));
                    });
                    
                    string a = System.Text.Encoding.UTF8.GetString(ao);
                    IPlayerData playerData = JsonUtility.FromJson<PlayerData>(a);
                   
                    return playerData;
                }


                public async Task<ISaveInfo[]> GetAllSaveInfo()
                {
                    ISaveInfo[] _result = new SaveInfo[_maxSlot];
                    for (int i = 0; i < _maxSlot; i++)
                    {
                        _result[i] = await LoadSaveInfo(i);
                    }

                    return _result;
                }


                /// <summary>
                /// 从ab包里加载方法
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="a"></param>
                /// <returns></returns>
                public T LoadConfigFromAb<T>(string a)where T : class 
                {
                    if (a == null) return null;
                   return JsonUtility.FromJson<T>(a);
                }


                /// <summary>
                /// 检查某个卡槽是否有存档，isHaveSaveInfo是为了区分是否有存档头信息。
                /// </summary>
                /// <param name="isHaveSaveInfo"></param>
                /// <param name="index"></param>
                /// <returns></returns>
                public bool CheakSomeoneSlotIsSave(out bool isHaveSaveInfo, int index)
                {
                    if (index < 0 || index >= _maxSlot)
                    {
                        isHaveSaveInfo = false;
                        return false;
                    }
                    isHaveSaveInfo = System.IO.File.Exists(GetInfoPath(index));
                    return System.IO.File.Exists(GetPlayerPath(index));

                }

                #endregion

                #region 辅助方法
                private string GetPlayerPath(int index)
                {
                    return Path.Combine(_savePath, $"PlayerData_{index}.json");
                }
                private string GetInfoPath(int index)
                {
                    return Path.Combine(_savePath, $"SaveInfo_{index}.json");
                }
                private string GetConfigPath()
                {
                    return Path.Combine(_savePath, $"SystemConfig.json");
                }

                #endregion
            }
            #endregion

            /// <summary>
            /// 存储一些全局的、常用的数据。
            /// </summary>
            public  class CacheManager
            {
                private static readonly Dictionary<string, System.Object> _cache = new Dictionary<string, System.Object>();
                public static CacheManager Instance { get; set; }
                public CacheManager()
                {
                    Instance = this;
                }
          

                /// <summary>
                /// 存到内存中
                /// </summary>
                /// <param name="key">类型名</param>
                /// <param name="value"></param>
                public void LoadToCache(string key , System.Object value)
                {
                    
                    if (!_cache.TryGetValue(key ,out var a))
                    {
                       _cache.Add(key , value);
                        return;
                    }

                    if (value == a) return;//重复则返回

                    _cache[key] = value;
                   
                }

                /// <summary>
                /// 返回System.Object类的实例。需自行灵活判断
                /// </summary>
                /// <param name="key"></param>
                /// <returns></returns>
                public System.Object GetFromCache(string key)
                {
                    return _cache[key];//此处不做空检验
                }
            }
        }
    }

    namespace Temp
    {
        public class CardCSVLoader
        {

            private CardBaseEffect ParseBaseEffect(string text)
            {
                CardBaseEffect effect = new();

                effect.moodDelta = Extract(text, "�ľ���");
                effect.energyDelta = Extract(text, "������");

                return effect;
            }

            private int Extract(string text, string key)
            {
                int index = text.IndexOf(key);
                if (index < 0) return 0;

                string sub = text.Substring(index + key.Length);
                Match m = Regex.Match(sub, @"[-+]?\d+");

                return m.Success ? int.Parse(m.Value) : 0;
            }
        }
    }
}