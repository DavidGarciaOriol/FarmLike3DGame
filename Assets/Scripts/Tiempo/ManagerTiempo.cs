using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTiempo : MonoBehaviour
{
    public static ManagerTiempo Instance { get; private set; }

    [Header("Tiempo de juego")]
    [SerializeField] private TiempoDeJuego tiempoDeJuego;
    [SerializeField] private float escalaDeTiempo = 1.0f;

    [Header("Ciclo día y noche")]
    [SerializeField] private Transform posicionDelSol;

    // Lista de objetos que informan de cambios en el tiempo
    List<IObservadorDeTiempo> observadores = new List<IObservadorDeTiempo>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tiempoDeJuego = new TiempoDeJuego(0, TiempoDeJuego.Estacion.Primavera, 1, 6, 0);
        StartCoroutine(ActualizarTiempo());
    }

    IEnumerator ActualizarTiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / escalaDeTiempo);
            Tick();
        }
    }

    // Un tick de tiempo de juego
    public void Tick()
    {
        tiempoDeJuego.ActualizarReloj();

        // Informa a los observadores de una actualización de tiempo
        foreach (IObservadorDeTiempo observador in observadores)
        {
            observador.ActualizacionDeReloj(tiempoDeJuego);
        }

        ActualizarMovimientoDelSol();
    }

    void ActualizarMovimientoDelSol()
    {
        // Convierte la hroa actual en minutos
        int tiempoEnMinutos = TiempoDeJuego.HorasAMinuto(tiempoDeJuego.Hora) + tiempoDeJuego.Minuto;

        /** Calcula la posición del sol
         * El sol se mueve 15 grados en una hora
         * Eso son 0.25 grados en un minuto
         * A media noche (0:00), el ángulo del sol es -90 grados */
        float anguloDelSol = 0.25f * tiempoEnMinutos - 90;

        // Aplicamos el ángulo a la luz direccional de la escena
        posicionDelSol.eulerAngles = new Vector3(anguloDelSol, 0, 0);
    }


    // Agrega el objeto a la lista de observadores
    public void RegistrarObservador(IObservadorDeTiempo observador)
    {
        observadores.Add(observador);
    }

    // Elimina el objeto de la lista de observadores
    public void DescartarObservador(IObservadorDeTiempo observador)
    {
        observadores.Remove(observador);
    }
}
