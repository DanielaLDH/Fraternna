using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("Tamanho da borda em pixels onde a movimentação da câmera é ativada.")]
    [SerializeField] float edgeSize;

    [Tooltip("Velocidade de movimento da câmera.")]
    [SerializeField] float ScrollSpeed;


    // Update is called once per frame
    void Update()
    {
        // Obtém a posição do mouse na tela
        Vector3 mousePosition = Input.mousePosition;

        // Inicializa a direção do movimento
        Vector3 moveDirection = Vector3.zero;

        // Verifica em qual borda esta o mouse
        if (mousePosition.x >= Screen.width - edgeSize)
        {
            moveDirection.x = 1f;

        }else if (mousePosition.x <= edgeSize)
        {
            moveDirection.x = -1f;
        }

        // Move a câmera na direção calculada com base na velocidade e no tempo
        transform.position += moveDirection * ScrollSpeed * Time.deltaTime;
    }
}
