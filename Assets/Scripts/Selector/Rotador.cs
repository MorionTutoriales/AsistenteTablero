using UnityEngine;

public class Rotador : MonoBehaviour
{
    public Vector3 velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime);
    }
}
