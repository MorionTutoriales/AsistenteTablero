using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoCombate : MonoBehaviour
{
	public Contador cAtacantes;
	public Contador cDefensores;
	public TextMeshProUGUI txtAtacantes;
	public TextMeshProUGUI txtDefensores;

	public List<int> dadosAtacante;
	public List<int> dadosDefensor;

	public SharpUI.Source.Common.UI.Elements.Toggle.ToggleButton tFortalezasAtacantes;
	public SharpUI.Source.Common.UI.Elements.Toggle.ToggleButton tFortalezasDefensor;
	public SharpUI.Source.Common.UI.Elements.Toggle.ToggleButton tLiderAtacante;
	public SharpUI.Source.Common.UI.Elements.Toggle.ToggleButton tLiderDefensor;
	public GameObject panelAutoCombate;

	public void IniciarAutoCombate()
	{
		StartCoroutine(Combatir());
	}

	public void AutoCombatir()
	{
		panelAutoCombate.SetActive(true);
		txtAtacantes.text = cAtacantes.valor.ToString("00");
		txtDefensores.text = cDefensores.valor.ToString("00");
	}
	public IEnumerator Combatir()
	{
		yield return new WaitForSeconds(0.5f);
		while (cAtacantes.valor > 0 && cDefensores.valor > 0)
		{
			LanzarDados(cAtacantes.valor, cDefensores.valor);
			int menor = dadosAtacante.Count < dadosDefensor.Count ? dadosAtacante.Count : dadosDefensor.Count;
			AjustarLiderYFortalezas();
			print(menor);
			for (int i = 0; i < menor; i++)
			{
				if (dadosAtacante[i] > dadosDefensor[i])
				{
					cDefensores.Restar();
				}
				else
				{
					cAtacantes.Restar();
				}
				txtAtacantes.text = cAtacantes.valor.ToString("00");
				txtDefensores.text = cDefensores.valor.ToString("00");
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void LanzarDados(int atacantes, int defensores)
	{
		dadosAtacante = new List<int>();
		dadosDefensor = new List<int>();
		for (int i = 0; i < 3; i++)
		{
			if (atacantes>i)
			{
				dadosAtacante.Add(Random.Range(1, 7));
			}
			
		}
		for (int i = 0; i < 2; i++)
		{
			if (defensores > i)
			{
				dadosDefensor.Add(Random.Range(1, 7));
			}
		}
		dadosAtacante.Sort();
		dadosAtacante.Reverse();
		dadosDefensor.Sort();
		dadosDefensor.Reverse();

	}

	public void AjustarLiderYFortalezas()
	{
		if (tLiderAtacante.isOn)
		{
			dadosAtacante[0] = Mathf.RoundToInt(Mathf.Clamp(dadosAtacante[0] + 1, 1, 6));
		}

		if (tLiderDefensor.isOn)
		{
			dadosDefensor[0] = Mathf.RoundToInt(Mathf.Clamp(dadosDefensor[0] + 1, 1, 6));
		}

		if (tFortalezasAtacantes.isOn)
		{
			for (int i = 0; i < dadosAtacante.Count; i++)
			{
				dadosAtacante[i] = Mathf.RoundToInt(Mathf.Clamp(dadosAtacante[i] + 1, 1, 6));
			}
		}

		if (tFortalezasDefensor.isOn)
		{
			for (int i = 0; i < dadosDefensor.Count; i++)
			{
				dadosDefensor[i] = Mathf.RoundToInt(Mathf.Clamp(dadosDefensor[i] + 1, 1, 6));
			}
		}
	}
}
