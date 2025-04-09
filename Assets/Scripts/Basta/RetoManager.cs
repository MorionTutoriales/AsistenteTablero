using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RetoManager : MonoBehaviour
{
    public string fileName = "retos_basta_final.txt"; // Nombre del archivo en StreamingAssets

    public List<string> retos = new List<string>();

    void Start()
    {
        CargarRetosDesdeArchivo();
    }

    void CargarRetosDesdeArchivo()
    {
        string ruta = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(ruta))
        {
            string[] lineas = File.ReadAllLines(ruta);
            retos = new List<string>(lineas);
            Debug.Log($"Se cargaron {retos.Count} retos.");
        }
        else
        {
            Debug.LogError("No se encontró el archivo: " + ruta);
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

    [ContextMenu("Lanzar en consola")]
    public void LanzarEnConsola()
    {
        print(ObtenerRetoAleatorio());
    }

    public int RetosDisponibles()
    {
        return retos.Count;
    }

    public string ObtenerRetoAlAzarSinEliminar()
    {
        if (retos.Count == 0)
            return "Sin retos disponibles";

        int indice = Random.Range(0, retos.Count);
        return retos[indice];
    }
}
