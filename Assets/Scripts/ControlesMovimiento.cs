using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesMovimiento : MonoBehaviour
{


    private Vector3 initialPosition;

    [SerializeField] float frecuencia = 1;
    [SerializeField] float intensidad = 1;

    [SerializeField] Material ballMaterial;
    [SerializeField] float freqTransparencia;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.time * frecuencia;
        
        transform.position = new Vector3(initialPosition.x, initialPosition.y + intensidad * Mathf.Sin(delta), initialPosition.z);

        float transparency = Mathf.Sin(Time.time * freqTransparencia) / 2.0f + 0.5f;

        Color myColor = ballMaterial.color;
        myColor.a = transparency;
        ballMaterial.color = myColor;


    }
}
