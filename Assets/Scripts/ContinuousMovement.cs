using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour
{

    private float gravity = -9.81f;
    private float fallingSpeed;
    public LayerMask groundLayer;
    public float additionalHeight = 0.0f;
    public float deltaHeight_ifGrounded = 0.2f;
    public float deltaHeight_Capsule = 0.0f;
    public float extraRadius = 0.0f;
    public bool isMoving { get; set; }

    public XRNode LeftInputSource;
    public XRNode RightInputSource;

    private Vector2 inputAxis;
    private bool LeftInputPrimaryButton;
    private bool RightInputPrimaryButton;

    private float PrimaryButtonSleepTime = 0.5f;
    private bool PrimaryButtonIsSleep = false;


    private XROrigin origin;

    private CharacterController character;
    public float speed = 5;

    private GameObject RayInteractor;
    private GameObject LeftHandPanel;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        character =  GetComponent<CharacterController>();
        origin = GetComponent<XROrigin>();
        isMoving = false;

        audioSource = transform.Find("CameraOffSet").Find("Pies").GetComponent<AudioSource>();
        RayInteractor = transform.Find("CameraOffSet").Find("RayInteractor").gameObject;
        LeftHandPanel = transform.Find("CameraOffSet").Find("LeftHand").Find("HandCanvas").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        InputDevice leftController = InputDevices.GetDeviceAtXRNode(LeftInputSource);
        leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        leftController.TryGetFeatureValue(CommonUsages.primaryButton, out LeftInputPrimaryButton);

        InputDevice rightController = InputDevices.GetDeviceAtXRNode(RightInputSource);
        rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightInputPrimaryButton);


        
        is_A_button_clicked();
        is_X_button_clicked();

    }

    private void is_A_button_clicked()
    {
        if ((RightInputPrimaryButton) && !PrimaryButtonIsSleep)
        {

            RayInteractor.SetActive(!RayInteractor.activeSelf);
            PrimaryButtonIsSleep = true;
            PrimaryButtonSleepTime = 0.5f;
        }
        if (PrimaryButtonSleepTime < 0.0f)
        {
            PrimaryButtonIsSleep = false;
        }
        PrimaryButtonSleepTime -= Time.deltaTime;
    }


    private void is_X_button_clicked() {
        if ((LeftInputPrimaryButton) && !PrimaryButtonIsSleep)
        {

            LeftHandPanel.SetActive(!LeftHandPanel.activeSelf);
            PrimaryButtonIsSleep = true;
            PrimaryButtonSleepTime = 0.5f;
        }
        if (PrimaryButtonSleepTime < 0.0f)
        {
            PrimaryButtonIsSleep = false;
        }
        PrimaryButtonSleepTime -= Time.deltaTime;

    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, origin.Camera.transform.eulerAngles.y, speed);
        Vector3 direction = headYaw * new Vector3((float)inputAxis.x, 0, inputAxis.y);
        isMoving = direction.magnitude > 0;
        if (isMoving)
        {
            character.Move(direction * Time.fixedDeltaTime * speed);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            

        }
        
        if (!ShouldFall())
        {
            //fallingSpeed -= gravity * Time.fixedDeltaTime;
            fallingSpeed = gravity;
        }
        else
        {
            fallingSpeed = -gravity;
            //fallingSpeed = gravity * Time.fixedDeltaTime;
        }
        //gravity
        character.height += additionalHeight;
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

        //Debug.Log("Height: " + character.height);
    }

    bool ShouldFall()
    {
        
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 10.01f + deltaHeight_ifGrounded;
        bool hasHit = Physics.SphereCast(rayStart, character.radius*2 + extraRadius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        float distanceToGround = hitInfo.distance;
        //Debug.Log("Has hit: " + hasHit);
        //Debug.Log("distanceToGround: " + distanceToGround + " deltaHeight_ifGrounded: " + deltaHeight_ifGrounded);

        
        if (!hasHit)// si el rayo no encuentra nada
        {

            return true;
        }
        else {// Si el rayo encuentra contacto, se revisa la distancia al piso
            return distanceToGround < deltaHeight_ifGrounded;
        }

        
    }


    void CapsuleFollowHeadset()
    {
        character.height = origin.CameraInOriginSpaceHeight + deltaHeight_Capsule;
        Vector3 capsuleCenter = transform.InverseTransformPoint(origin.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth, capsuleCenter.z);
    }
}
