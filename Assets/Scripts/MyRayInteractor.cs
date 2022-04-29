using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MyRayInteractor : MonoBehaviour
{


    private XRRayInteractor ThisRay;
    public LineRenderer lineRenderer;
    public Color ActualColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        ThisRay = transform.GetComponent<XRRayInteractor>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HoveringInteractable() {


        lineRenderer.endColor = Color.magenta;
    }

    public void desHoveringInteractable() {
        lineRenderer.endColor = Color.magenta;

    }
}
