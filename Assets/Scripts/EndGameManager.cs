using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{

    [SerializeField] GameObject PhoboFoundGem;
    [SerializeField] GameObject PhoboCloseGem;
    [SerializeField] GameObject PhoboStaredGem;
    [SerializeField] GameObject Gemas;

    [SerializeField] float frecuencia = 1;
    [SerializeField] float intensidad = 1;
    private Vector3 initialPosition;

    [SerializeField] private static readonly float howMuchClose = 2;
    [SerializeField] private static readonly float howMuchStare = 10;

    static private bool hasPhoboFound = false;
    static private bool hasPlayerClose = false;
    static private bool hasPlayerStared = false;


    public static bool HasPhoboFound { get => hasPhoboFound; set => hasPhoboFound = value; }
    public static bool HasPlayerClose { get => hasPlayerClose; set => hasPlayerClose = value; }
    public static bool HasPlayerStared { get => hasPlayerStared; set => hasPlayerStared = value; }

    public static float HowMuchStare => howMuchStare;

    public static float HowMuchClose => howMuchClose;


    // Start is called before the first frame update
    void Start()
    {
        PhoboCloseGem.SetActive(hasPlayerClose);
        PhoboFoundGem.SetActive(hasPhoboFound);
        PhoboStaredGem.SetActive(hasPlayerStared);

        initialPosition = Gemas.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.time * frecuencia;

        Gemas.transform.position = new Vector3(initialPosition.x, initialPosition.y + intensidad * Mathf.Sin(delta), initialPosition.z);
    }



    public void ClickedOnSalir()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }


}
