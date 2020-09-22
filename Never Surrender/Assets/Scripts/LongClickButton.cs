using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool pointerDown, pointerOver;
    private float pointerDownTimer, pointerOverTimer;
    public float requiredHoldTime;
    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private Image showInfoImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer > requiredHoldTime)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
        
        if (pointerOver == true)
        {
            
            pointerOverTimer += Time.deltaTime;
            showInfoImage.fillAmount = pointerOverTimer;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        showInfoImage.fillAmount = pointerOverTimer;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOver = false;
        pointerOverTimer = 0;
        Reset();
    }
}
