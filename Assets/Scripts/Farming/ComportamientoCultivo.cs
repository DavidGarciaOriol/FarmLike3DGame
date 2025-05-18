using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoCultivo : MonoBehaviour
{
    DatosSemilla semillaParaCrecer;

    [Header("Etapas de vida")]
    [SerializeField] public GameObject semilla;
    /*[SerializeField] */ private GameObject semillero;
    /*[SerializeField] */ private GameObject cosechable;

    private int crecimiento;
    private int crecimientoMaximo;
    public enum EstadoCultivo
    {
        Semilla,
        Semillero,
        Cosechable
    }

    public EstadoCultivo estadoCultivo;

    // Lógica para plantar un cultivo
    public void Plantar(DatosSemilla semillaParaCrecer)
    {
        this.semillaParaCrecer = semillaParaCrecer;

        semillero = Instantiate(semillaParaCrecer.Semillero, transform);

        DatosItem hortalizaQueProporciona = semillaParaCrecer.HortalizaQueProporciona;

        cosechable = Instantiate(hortalizaQueProporciona.Modelado, transform);

        int horasParaCrecer = TiempoDeJuego.DiasAHora(semillaParaCrecer.DiasParaCrecer);

        crecimientoMaximo = TiempoDeJuego.HorasAMinuto(horasParaCrecer);

        CambiarEstado(EstadoCultivo.Semilla);
    }

    // Lógica de crecimiento del cultivo
    public void Crecer()
    {
        // Crece en 1 por cada iteración
        crecimiento++;

        // Germinación del semillero al 50% del tiempo de crecimiento
        if (crecimiento >= crecimientoMaximo / 2 && estadoCultivo == EstadoCultivo.Semilla)
        {
            CambiarEstado(EstadoCultivo.Semillero);
        }

        // Completamente crecido
        if (crecimiento >= crecimientoMaximo && estadoCultivo == EstadoCultivo.Semillero)
        {
            CambiarEstado(EstadoCultivo.Cosechable);
        }
    }

    void CambiarEstado(EstadoCultivo nuevoEstado)
    {
        semilla.SetActive(false);
        semillero.SetActive(false);
        cosechable.SetActive(false);

        switch (nuevoEstado)
        {
            case EstadoCultivo.Semilla:
                semilla.SetActive(true);
                break;
            case EstadoCultivo.Semillero:
                semillero.SetActive(true);
                break;
            case EstadoCultivo.Cosechable:
                cosechable.SetActive(true);
                break;
        }

        estadoCultivo = nuevoEstado;
    }
}
