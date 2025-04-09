using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RetoDisplayRuleta : MonoBehaviour
{
    public TextMeshProUGUI retoText;       // El texto donde aparecen los retos
    public RetoManager retoManager;        // Referencia al script de retos
    public Image imagenRotatoria;          // Imagen UI que va a rotar

    public float duracion = 3f;            // Duración total de la ruleta
    public float velocidadCambio = 0.05f;  // Frecuencia de cambio de frase

    public void IniciarRuleta()
    {
        StartCoroutine(RuletaCoroutine());
    }

    IEnumerator RuletaCoroutine()
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracion)
        {
            if (retoManager != null && retoManager.RetosDisponibles() > 0)
            {
                string retoRandom = retoManager.ObtenerRetoAlAzarSinEliminar();
                retoText.text = retoRandom;

                // Rotar imagen entre -7 y 7 grados en Z
                if (imagenRotatoria != null)
                {
                    float anguloZ = Random.Range(-7f, 7f);
                    imagenRotatoria.rectTransform.rotation = Quaternion.Euler(0, 0, anguloZ);
                }
            }

            tiempoTranscurrido += velocidadCambio;
            yield return new WaitForSeconds(velocidadCambio);
        }

        // Reto final que sí se elimina de la lista
        string retoFinal = retoManager.ObtenerRetoAleatorio();
        retoText.text = retoFinal;

        // Dejar imagen sin rotación final si se desea
        if (imagenRotatoria != null)
        {
            imagenRotatoria.rectTransform.rotation = Quaternion.identity;
        }
    }
}
