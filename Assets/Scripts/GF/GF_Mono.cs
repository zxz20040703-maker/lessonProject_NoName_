using GF.FUNCTION;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GF
{
    /// <summary>
    /// 卡牌的表现层，负责卡牌的交互事件，完全依赖unity的ui系统，禁止多线程访问
    /// </summary>
    public class CardBehaviorController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,
                                                IPointerUpHandler, IPointerEnterHandler,
                                                IPointerExitHandler, IDragHandler,
                                                IBeginDragHandler, IEndDragHandler
    {
        //当鼠标悬停在卡牌上时，显示卡牌信息
        //当鼠标点击卡牌时，卡牌高亮且向上移动一小段、卡牌后续能够被拖动
        //当拖动结束时，判断卡牌是否被放置在合法的位置，如果合法则执行卡牌效果，否则将卡牌返回原位


        public void OnPointerClick(PointerEventData eventData)
        {

        }
        public void OnPointerDown(PointerEventData eventData)
        {

        }
        public void OnPointerEnter(PointerEventData eventData)
        {
        }
        public void OnPointerExit(PointerEventData eventData)
        {
        }
        public void OnPointerUp(PointerEventData eventData)
        {
        }
        public void OnDrag(PointerEventData eventData)
        {
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
        }
        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }


    /// <summary>
    /// 挂载给单个卡牌游戏物体
    /// </summary>
    public class Card : MonoBehaviour, GF.INTERFACE_FRAME.ICARD.ICard
    {
        public string CardID { get; set; }
        public string CardName { get; set; }
        public GF.INTERFACE_FRAME.ICHARACTER.ICurableCharacter CardTarget { get; set; }//卡牌的作用目标
    }



    public class CoroutineMgr : MonoBehaviour
    {
        public static CoroutineMgr Instance { get; private set; }

        private readonly Dictionary<IEnumerator, Coroutine> _runningCoroutines = new();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 启动协程
        /// </summary>
        public Coroutine StartCoroutineByMgr(IEnumerator enumerator)
        {
            if (enumerator == null) return null;

            Coroutine coroutine = StartCoroutine(enumerator);
            _runningCoroutines[enumerator] = coroutine;
            return coroutine;
        }

        /// <summary>
        /// 停止指定协程
        /// </summary>
        public void StopCoroutineByMgr(IEnumerator enumerator)
        {
            if (enumerator == null) return;

            if (_runningCoroutines.TryGetValue(enumerator, out Coroutine coroutine))
            {
                StopCoroutine(coroutine);
                _runningCoroutines.Remove(enumerator);
            }
        }

        /// <summary>
        /// 停止所有协程
        /// </summary>
        public void StopAllCoroutinesByMgr()
        {
            StopAllCoroutines();
            _runningCoroutines.Clear();
        }
    }


    public class ComponentRegisterControl: MonoBehaviour
    {
        public string ComponentID;
        public Component component;

        private void Awake()
        {
            UnityComponentRegister.RegisterToDic(ComponentID, this);
        }
        private void OnDestroy()
        {
            UnityComponentRegister.UnRegister(ComponentID);
        }

        public T GetComponentByMono<T>()where T : Component
        {

            return GetComponent<T>();
        }

    }
}
