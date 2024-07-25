using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("Tamanho da borda em pixels onde a movimenta��o da c�mera � ativada.")]
    [SerializeField] float edgeSize;

    [Tooltip("Velocidade de movimento da c�mera.")]
    [SerializeField] float ScrollSpeed;


    // Update is called once per frame
    void Update()
    {
        // Obt�m a posi��o do mouse na tela
        Vector3 mousePosition = Input.mousePosition;

        // Inicializa a dire��o do movimento
        Vector3 moveDirection = Vector3.zero;

        // Verifica em qual borda esta o mouse
        if (mousePosition.x >= Screen.width - edgeSize)
        {
            moveDirection.x = 1f;

        }else if (mousePosition.x <= edgeSize)
        {
            moveDirection.x = -1f;
        }

        // Move a c�mera na dire��o calculada com base na velocidade e no tempo
        transform.position += moveDirection * ScrollSpeed * Time.deltaTime;
    }
}
