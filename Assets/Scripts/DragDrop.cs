using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Tooltip("Canvas que cont�m os objetos arrast�veis.")]
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

    // M�todo chamado no in�cio do arrasto
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f; // Torna o objeto parcialmente transparente
        canvasGroup.blocksRaycasts = false; // Permite que o objeto passe por outros objetos raycast
    }

    // M�todo chamado durante o arrasto
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        // Move o objeto com base na posi��o do mouse e na escala do canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // M�todo chamado no fim do arrasto
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f; // Restaura a opacidade do objeto
        canvasGroup.blocksRaycasts = true; // Bloqueia novamente os raycasts
    }

    // M�todo chamado quando o objeto � clicado
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
