using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update


    private float estado;
    public Text textoMision;
    public Text textoBienvenida;

    public Text textoFinal;
    public GameObject MenuButton;
    public GameObject RestartButton;
    public XRRayInteractor interactor;

    public List<GameObject> Balls;

    public XRNode LeftHand;
    private Vector2 LeftInputAxis;
    private float LeftInputGrip;
    private bool Left_X_button;

    private Vector2 RightInputAxis;
    public XRNode RightHand;
    private float RightInputGrip;
    private bool Right_A_button;

    [SerializeField]
    GameObject Player;

    [SerializeField] GameObject Left_X;
    [SerializeField] GameObject Left_Stick;
    [SerializeField] GameObject Left_Grip;

    [SerializeField] GameObject Right_A;
    [SerializeField] GameObject Right_Stick;
    [SerializeField] GameObject Right_Grip;



    private void Start()
    {
        estado = 0; // no ha hecho nada
    }

    private void Update()
    {
        //Get devices
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(LeftHand);
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(RightHand);

        //left
        leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftInputAxis);
        leftHandDevice.TryGetFeatureValue(CommonUsages.grip, out LeftInputGrip);

        //right
        rightHandDevice.TryGetFeatureValue(CommonUsages.grip, out RightInputGrip);
        rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out RightInputAxis);


        leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out Left_X_button);
        rightHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out Right_A_button);

        

        


        if ( Right_A_button) {
            hasClicked_A_button();
        }


        if (Left_X_button)
        {

            hasClicked_X_button();
        }


        if (RightInputAxis.magnitude > 0) {
            hasClickedInputAxis();
        }


    }



    private void FixedUpdate()
    {
 
        

        ContinuousMovement ContMov = Player.GetComponent<ContinuousMovement>();

        if (ContMov != null)
        {
            if (ContMov.isMoving) {
                HasMoved();
            }
        }
    }

    public void FirstStep()
    {

        textoFinal.text = "¡Felicidades! Has completado el tutorial. \n ¿Qué deseas hacer ahora?";
        MenuButton.SetActive(true);
        RestartButton.SetActive(true);
        interactor.gameObject.SetActive(true);
    }

    public void ClickedOnReiniciar()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ClickedOnMenu() {

        SceneManager.LoadScene("Menu");
    }



    public void HasMoved() {

        if (estado == 0) {

            estado = 1;
            textoBienvenida.gameObject.SetActive(false);
            textoMision.text = "¡Perfecto! \n Prueba presionar el botón A en el mando derecho" +
                " para tener una mira que te permitirá interactuar con objetos de lejos";
            Left_Stick.SetActive(false);

            
            Right_A.SetActive(true);

        }
        
        
    }



    public void hasClicked_A_button() {


        if (estado == 1) {
            estado = 2;
            
            textoMision.text = "A continuación presiona el botón X en el mando izquierdo." +
                " Esto aparecerá una pantalla por si quieres salir del juego";

            
            Right_A.SetActive(false);

            Left_X.SetActive(true);
            
        }
    
    }



    private void hasClicked_X_button()
    {
        if (estado == 2)
        {
            estado = 3;

            textoMision.text = "Lo siguiente es cambiar tu ángulo de visión con la palanca del control derecho.";

            Left_X.SetActive(false);

            Right_Stick.SetActive(true);
        }
    }


    public void hasClickedInputAxis() {

        if (estado == 3)
        {
            estado = 4;
            textoMision.text = "¡Muy bien! \n Ahora prueba tomar una pelota con el botón de agarre.";

            Right_Stick.SetActive(false);

            Left_Grip.SetActive(true);
            Right_Grip.SetActive(true);

        }

    }



    public void HasBall()
    {

        if (estado == 4) {
            estado = 5;
            textoMision.text = "¡Excelente! \n Lo siguente es que dejes la pelota en el pedestal al otro lado de la muralla." +
                " Pero para eso deberás abrir primero la puerta con el botón de agarre";

            Left_Grip.SetActive(false);
            Right_Grip.SetActive(false);
        }
        
    }

    
}
