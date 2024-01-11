using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler,
IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool pointerIn = false;
    public UnityEvent onPress = new UnityEvent();
    public UnityEvent onRelease = new UnityEvent();
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData){
        pointerIn = true;
    }

    public void OnPointerExit(PointerEventData eventData){
        pointerIn = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        if (pointerIn) {
            animator.SetBool("Pressed",true);
            onPress.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData){
        animator.SetBool("Pressed",false);

        if (pointerIn) onRelease.Invoke();
    }
}
