using System.Collections.Generic;
using UnityEngine;

public class RetoManager : MonoBehaviour
{
    public TextAsset archivoDeRetos; // Asigna el .txt desde el inspector

    public List<string> retos = new List<string>();

    void Start()
    {
        CargarRetosDesdeTextAsset();
    }

    void CargarRetosDesdeTextAsset()
    {
        if (archivoDeRetos != null)
        {
            string[] lineas = archivoDeRetos.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            retos = new List<string>(lineas);
            Debug.Log($"Se cargaron {retos.Count} retos desde TextAsset.");
        }
        else
        {
            Debug.LogError("No se asignó ningún archivo de retos.");
        }
    }

    public string ObtenerRetoAleatorio()
    {
        if (retos.Count == 0)
        {
            return "¡No quedan retos!";
        }

        int indice = Random.Range(0, retos.Count);
        string reto = retos[indice];
        retos.RemoveAt(indice);
        return reto;
    }

    public string ObtenerRetoAlAzarSinEliminar()
    {
        if (retos.Count == 0)
        {
            return "Sin retos disponibles";
        }

        int indice = Random.Range(0, retos.Count);
        return retos[indice];
    }

    public int RetosDisponibles()
    {
        return retos.Count;
    }
}
