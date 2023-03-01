using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pedals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent onMouse;

    private bool isMouseDown;

    [SerializeField] private Sprite 
        defaultPedal,
        pressedPedal;

    [SerializeField] private Image graphicComponent;

    private void Start() => graphicComponent.sprite = defaultPedal;

    private void Update()
    {
        if (isMouseDown)
            onMouse.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
        graphicComponent.sprite = pressedPedal;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false;
        graphicComponent.sprite = defaultPedal;
    }
}

