using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RayActivator : MonoBehaviour
{

    public GameObject rayInteractor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        rayInteractor.SetActive(true);
        
    }

    void OnTriggerExit(Collider collider)
    {
        rayInteractor.SetActive(false);
    }
}
