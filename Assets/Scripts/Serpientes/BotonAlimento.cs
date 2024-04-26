using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAlimento : MonoBehaviour
{
    public Text txtAlimento;

    public void Consumir()
    {
        AlimentosSerp.singleton.CrearAlimento();
        Destroy(gameObject);
    }
}
