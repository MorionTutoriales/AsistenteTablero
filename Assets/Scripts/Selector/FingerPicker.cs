using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPicker : MonoBehaviour
{
    public GameObject circuloPrefab;
    public Canvas canvas;
    public float tiempoEspera = 5f;

    public AudioClip sonidoFinal;
    private AudioSource audioSource;

    private Dictionary<int, GameObject> dedos = new Dictionary<int, GameObject>();
    private float tiempoSinCambios = 0f;
    private int dedosAnteriores = 0;
    private bool seleccionando = false;
    private bool seleccionCompleta = false;
    private GameObject seleccionadoActual = null;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        int dedosActuales = Input.touchCount;

        if (seleccionando) return;

        // Si hay nuevos dedos, reiniciar proceso
        if (dedosActuales != dedosAnteriores)
        {
            if (seleccionCompleta)
            {
                // Borrar seleccionado anterior si hay
                if (seleccionadoActual != null)
                {
                    Destroy(seleccionadoActual);
                    seleccionadoActual = null;
                }
                seleccionCompleta = false;
            }

            tiempoSinCambios = 0f;
            dedosAnteriores = dedosActuales;
            ActualizarCirculos();
        }
        else if (!seleccionCompleta && dedosActuales > 0)
        {
            tiempoSinCambios += Time.deltaTime;
            if (tiempoSinCambios >= tiempoEspera)
            {
                StartCoroutine(SeleccionarAlAzar());
            }
            else
            {
                // Mover los círculos con los dedos
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch toque = Input.GetTouch(i);
                    if (dedos.ContainsKey(toque.fingerId))
                    {
                        dedos[toque.fingerId].transform.position = toque.position;
                    }
                }
            }
        }
    }

    void ActualizarCirculos()
    {
        foreach (var c in dedos.Values)
            Destroy(c);
        dedos.Clear();

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch toque = Input.GetTouch(i);
            Vector2 posPantalla = toque.position;
            GameObject circulo = Instantiate(circuloPrefab, canvas.transform);
            circulo.transform.position = posPantalla;

            // Color aleatorio
            Image img = circulo.GetComponent<Image>();
            if (img != null)
            {
                img.color = new Color(Random.value, Random.value, Random.value);
            }

            dedos[toque.fingerId] = circulo;
        }
    }

    IEnumerator SeleccionarAlAzar()
    {
        seleccionando = true;

        yield return new WaitForSeconds(0.5f);

        if (dedos.Count == 0)
        {
            seleccionando = false;
            yield break;
        }

        List<int> keys = new List<int>(dedos.Keys);
        int randomIndex = Random.Range(0, keys.Count);
        int seleccionadoID = keys[randomIndex];

        GameObject seleccionado = dedos[seleccionadoID];

        // Reproducir sonido
        if (sonidoFinal != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoFinal);
        }

        // Destruir todos menos el seleccionado
        foreach (var kv in dedos)
        {
            if (kv.Key != seleccionadoID)
                Destroy(kv.Value);
        }

        dedos.Clear();
        seleccionadoActual = seleccionado;
        seleccionCompleta = true;
        seleccionando = false;
    }
}
