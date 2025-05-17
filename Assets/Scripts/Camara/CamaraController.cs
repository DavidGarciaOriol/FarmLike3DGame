using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Componente de posici�n (transform) del jugador
    [Header("Jugador a seguir")]
    [SerializeField] private Transform posicionJugador;

    [Header("Movimiento C�mara")]
    [SerializeField] private float suavizado = 2f;
    [SerializeField] private float offsetZ = 7f;

    // Start is called before the first frame update
    void Start()
    {
        // Si no se le pasa ning�n jugador en el inspector, lo busca en la Jerarqu�a.
        if (!posicionJugador || posicionJugador == null)
        {
            posicionJugador = FindObjectOfType<JugadorController>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SeguirJugador();
    }

    void SeguirJugador()
    {
        Vector3 posicionCamara = new Vector3(posicionJugador.position.x, transform.position.y, posicionJugador.position.z - offsetZ);
        transform.position = Vector3.Lerp(transform.position, posicionCamara, suavizado * Time.deltaTime);
    }
}
