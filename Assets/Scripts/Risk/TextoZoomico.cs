using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoZoomico : MonoBehaviour
{
    public TextMeshProUGUI txtPro;
    [Range(0f,1f)]
    public float t;
    public Vector3 posFinal;
    public Color colorFinal;
    public Color colorActual;

    bool enRutina = false;

    public int valor;
    void Start()
    {
        t = 0.999f;
        StartCoroutine(Actualizar());
    }

    public void Animar(string texto)
	{
        t = 0;
		if (texto == "+1")
		{
            valor++;
		}
		else if (texto == "-1")
        {
            valor--;
		}
        txtPro.text = valor.ToString();
		if (!enRutina)
		{
            StartCoroutine(Actualizar());
		}
	}

    // Update is called once per frame
    IEnumerator Actualizar()
    {
        enRutina = true;
		while (t<1)
		{
            txtPro.transform.localPosition = Vector3.Lerp(Vector3.zero, posFinal, t);
            txtPro.color = Color.Lerp(Color.white * colorActual, colorFinal * colorActual, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        txtPro.color = Color.Lerp(Color.white * colorActual, colorFinal * colorActual, 1);
        enRutina = false;
        valor = 0;
    }
}
