using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour
{
    // Start is called before the first frame update


    private static string QualityLevel;

    private static Object FobosModel;
    private static float anxietyLevel;
    private static string gameMap = "Casa";
    private static string type_of_animal;

    public static float getAnxietyLevel() { return anxietyLevel; }

    public static void setAnxietyLevel(float _anxietyLevel) { anxietyLevel = _anxietyLevel; }

    

    public static Object getFobosModel() {

        if (FobosModel)
        {
            Debug.Log("returned: " + FobosModel.name);
            return FobosModel;
        }
        FobosModel = Resources.Load("FobosModels/Arañas/LowQualityPhoboPrefab") as GameObject;
        //FobosModel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/FobosModels/Arañas/LowQualityPhoboPrefab.prefab");

        return FobosModel;
    }

    public static string getMap() { return gameMap; }



    private void Start()
    {
        
        //FobosModel = Resources.Load("FobosModels/Arañas/LowQualityPhoboPrefab");
        if (FobosModel is null)
        {
            FobosModel = Resources.Load("FobosModels/Arañas/LowQualityPhoboPrefab") as GameObject;
            if (FobosModel is null)
            {
                Debug.Log("Fobos not instantiated correctly");
            }
        }
    }

    public void ScrollBarChanged() {

        Dropdown dropdownDistress = transform.gameObject.GetComponent<Dropdown>();


        string pre_distress = dropdownDistress.options[dropdownDistress.value].text;

        int index_of_twopoints = pre_distress.IndexOf(':');

        float amount_distress = float.Parse(pre_distress.Substring(0, index_of_twopoints));

        AnxietyToQuality(amount_distress);

        /*switch (anxietyLevel)
        {

            case float n when (0.0f <= n && n < 0.4f):
                QualityLevel = "High";

                
                break;
            case float n when (0.4f <= n && n < 0.7f):
                QualityLevel = "Medium";
                break;
            case float n when (0.7f <= n && n < 1.0f):
                QualityLevel = "Low";
                break;
            default:
                QualityLevel = "Low";
                break;
        }*/
        //Phobo = Instantiate(LowQualityPhoboPrefab);

        //Debug.Log("QualityLevel: " + QualityLevel);
    }

    internal static void LoadResources(string _type_of_animal, float amount_distress, string map)
    {
        type_of_animal = _type_of_animal;
        anxietyLevel = amount_distress;
        gameMap = map;

        AnxietyToQuality(amount_distress);

        FobosModel = Resources.Load("FobosModels/" + type_of_animal + "/" + QualityLevel + "QualityPhoboPrefab");

        
    }

    public static void AnxietyToQuality(float _amount_distress) {

        switch (_amount_distress)
        {

            case float n when (0.0f <= n && n < 0.4f):
                QualityLevel = "High";


                break;
            case float n when (0.4f <= n && n < 0.7f):
                QualityLevel = "Medium";
                break;
            case float n when (0.7f <= n && n < 1.0f):
                QualityLevel = "Low";
                break;
            default:
                QualityLevel = "Low";
                break;
        }

    }

    

    public void ModelDropdownChanged(Dropdown dropdown) {

        
        type_of_animal = dropdown.options[dropdown.value].text;
        //Debug.Log("QualityLevel: " + QualityLevel);
        //Debug.Log("FobosModels/" + selectedText + "/" + QualityLevel + "QualityPhoboPrefab");
        FobosModel = Resources.Load("FobosModels/" + type_of_animal + "/" + QualityLevel + "QualityPhoboPrefab");
        //Debug.Log("Loaded: " + FobosModel.name);
        //FobosModel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/FobosModels/Arañas/LowQualityPhoboPrefab.prefab");
        if (FobosModel is null) {
            Debug.Log("Fobos not instantiated correctly");
        }
        

    }


    public void MapDropdownChanged(Dropdown dropdown)
    {
        gameMap = dropdown.options[dropdown.value].text;


    }






}
