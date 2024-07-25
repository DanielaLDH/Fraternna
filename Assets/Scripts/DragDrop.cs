using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Tooltip("Canvas que contém os objetos arrastáveis.")]
    [SerializeField] Canvas canvas;

    private Vector3 startPosition;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;


    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

    }

    // Método chamado no início do arrasto
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f; // Torna o objeto parcialmente transparente
        canvasGroup.blocksRaycasts = false; // Permite que o objeto passe por outros objetos raycast
    }

    // Método chamado durante o arrasto
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        // Move o objeto com base na posição do mouse e na escala do canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // Método chamado no fim do arrasto
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f; // Restaura a opacidade do objeto
        canvasGroup.blocksRaycasts = true; // Bloqueia novamente os raycasts
    }

    // Método chamado quando o objeto é clicado
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
