using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour
{
    // Start is called before the first frame update


    private string QualityLevel;
    
    private static Object FobosModel;
    private static float anxietyLevel;
    private static string gameMap = "Casa";

    public static float getAnxietyLevel() { return anxietyLevel; }

    public static Object getFobosModel() {

        if (FobosModel)
        {
            return FobosModel;
        }

        FobosModel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/FobosModels/Arañas/LowQualityPhoboPrefab.prefab");

        return FobosModel;
    }

    public static string getMap() { return gameMap; }



    private void Start()
    {
        FobosModel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/FobosModels/Arañas/LowQualityPhoboPrefab.prefab");
        //FobosModel = Resources.Load("FobosModels/Arañas/LowQualityPhoboPrefab");
        if (FobosModel is null)
        {
            Debug.Log("Fobos not instantiated correctly");
        }
    }

    public void ScrollBarChanged() {

        anxietyLevel = transform.gameObject.GetComponent<Scrollbar>().value;

        switch (anxietyLevel)
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
        //Phobo = Instantiate(LowQualityPhoboPrefab);

        //Debug.Log(anxietyLevel);
    }

    public void ModelDropdownChanged(Dropdown dropdown) {

        
        string selectedText = dropdown.options[dropdown.value].text;
        FobosModel = Resources.Load("Assets/FobosModels/" + selectedText + "/" + QualityLevel + "QualityPhoboPrefab.prefab");
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
