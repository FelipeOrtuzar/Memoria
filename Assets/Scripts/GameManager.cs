using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{

    //const string PLAYERNAME = "VROrigin";

    //private GameObject button;

    public Text TiempoObservacionDirecta;
    public Text DistanciaMínima;

    public GameObject HidePlaces;
    public GameObject Player;

    //public GameObject HighQualityPhoboPrefab;
    //public GameObject MidQualityPhoboPrefab;
    //public GameObject LowQualityPhoboPrefab;
    private GameObject Phobo;

    //private Vector3 PlayerPos;
    private Vector3 PlayerPosPrevToTele;
    private Quaternion PlayerRotPrevToTele;

    private float timerLeftToMove;
    private bool considerTimer;
    private float maxTimeForStillness = 30.0f;
    public GameObject safeHouseCenterObject;

    private float timeInDirectExposure = 0.0f;
    private float minDistanceToPhobo = 100.0f;




    // Start is called before the first frame update
    void Start()
    {
        //PlayerPos = Player.transform.position;
        timerLeftToMove = maxTimeForStillness;
        considerTimer = true;

        insertPhobosInScene();
    }

    // Update is called once per frame
    void Update()
    {

        ContinuousMovement ContMov = Player.GetComponent<ContinuousMovement>();
        bool isPlayerMoving = false;
        if (ContMov != null)
        {
            if (ContMov.isMoving) { timerLeftToMove = maxTimeForStillness; }
        }

        if (!isPlayerMoving && considerTimer) {

            timerLeftToMove -= Time.deltaTime;
            if (timerLeftToMove < 0) {

                TeleportToSafeHouse();
                considerTimer = false;
            }
        }

        ThrowRayCast();
    }

    private void ThrowRayCast()
    {

        Vector3 originPoint = Phobo.transform.position;
        Vector3 targetPoint = Player.transform.position;
        Vector3 direction = Vector3.Normalize(targetPoint - originPoint);
        minDistanceToPhobo = Math.Min(Vector3.Magnitude(targetPoint - originPoint), minDistanceToPhobo);

        bool hasHit = Physics.Raycast(originPoint, direction, out RaycastHit hitInfo);

        if (string.Equals(hitInfo.collider.gameObject.name, "VROrigin")) {
            timeInDirectExposure += Time.deltaTime;
        }

        TiempoObservacionDirecta.text = "Tiempo observación directa: " + ((int)timeInDirectExposure).ToString() + "s.";
        DistanciaMínima.text = "Distancia mínina con Fobos: " + ((int)minDistanceToPhobo/2).ToString() + "m aprox.";
    }

    private void TeleportToSafeHouse() {

        PlayerPosPrevToTele = Player.transform.position;
        PlayerRotPrevToTele = Player.transform.rotation;

        Player.transform.position = safeHouseCenterObject.transform.position;

        try {
            Player.transform.Find("CameraOffSet").Find("RayInteractor").gameObject.SetActive(true);
        }
        catch (NullReferenceException ex) { Debug.Log("Ray not found."); Debug.LogException(ex); }
    }


    private void insertPhobosInScene() {

        int CountHidePlaces = HidePlaces.transform.childCount;
        int HidePlaceChoosed = (int) UnityEngine.Random.Range(0, CountHidePlaces);

        Transform PositionTransformChoosed = HidePlaces.transform.GetChild(HidePlaceChoosed);

        Phobo = Instantiate(PlayerPreferences.getFobosModel()) as GameObject;

        Phobo.transform.position = PositionTransformChoosed.position;
        Phobo.transform.localScale = PositionTransformChoosed.localScale;
        Phobo.transform.rotation = PositionTransformChoosed.rotation;

        Phobo.AddComponent<XRGrabInteractable>();
    }

    public void ClickedOnContinuar()
    {
        
        Player.transform.position = PlayerPosPrevToTele;
        Player.transform.rotation = PlayerRotPrevToTele;
        try
        {
            Player.transform.Find("CameraOffSet").Find("RayInteractor").gameObject.SetActive(false);
        }
        catch (NullReferenceException ex) { Debug.Log("Ray not found."); Debug.LogException(ex); }
        considerTimer = true;
        timerLeftToMove = 10;
    }

    public void ClickedOnSalir()
    {
        SceneManager.LoadScene("Menu");
    }


    public void ClickedMostrarArana(RawImage image) {

        
        image.gameObject.SetActive(!image.gameObject.activeInHierarchy);
    }



    public void AranaTomada() {
        SceneManager.LoadScene("Menu");
        Debug.Log("La arana ha sido tomada");
    }







}
