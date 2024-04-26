using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentosSerp : MonoBehaviour
{
    public List<string> bancoAlimentos;
    public static AlimentosSerp singleton;
    public GameObject alimento;
    public Transform padre;

    void Start()
    {
        singleton = this;
        for (int i = 0; i < 22; i++)
        {
            bancoAlimentos.Add("Sapo");
        }
        for (int i = 0; i < 18; i++)
        {
            bancoAlimentos.Add("Lagartijas");
        }
        for (int i = 0; i < 5; i++)
        {
            bancoAlimentos.Add("Lombriz");
        }
        for (int i = 0; i < 8; i++)
        {
            bancoAlimentos.Add("Ave");
        }
        for (int i = 0; i < 5; i++)
        {
            bancoAlimentos.Add("Caracol");
        }
        for (int i = 0; i < 12; i++)
        {
            bancoAlimentos.Add("Insecto");
        }
        for (int i = 0; i < 10; i++)
        {
            bancoAlimentos.Add("Rata");
        }
        Barajar();
		for (int i = 0; i < 6; i++)
		{
            CrearAlimento();
		}
    }

    public void Barajar()
	{
        List<string> bancoAlimentosBarajados = new List<string>();
        while(bancoAlimentos.Count > 0)
		{
            int pos = Random.Range(0, bancoAlimentos.Count);
            bancoAlimentosBarajados.Add(bancoAlimentos[pos]);
            bancoAlimentos.RemoveAt(pos);
		}
        bancoAlimentos = bancoAlimentosBarajados;
    }

    public void CrearAlimento()
	{
        GameObject g = Instantiate(alimento, padre);
        g.GetComponent<BotonAlimento>().txtAlimento.text = bancoAlimentos[0];
        bancoAlimentos.RemoveAt(0);
	}
}
