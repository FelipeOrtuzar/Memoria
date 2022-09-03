using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{


    [SerializeField] Dropdown dropdownDistress;
    [SerializeField] Dropdown dropdownMap;
    [SerializeField] Dropdown dropdownAnimalType;


    public void TutorialButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }


    public void MainGameButtonPressed()
    {

        transform.Find("Menu").gameObject.SetActive(false);
        transform.Find("MainGameSettings").gameObject.SetActive(true);




    }


    public void EncuestaVolver() {
        transform.Find("MainGameSettings").gameObject.SetActive(false);
        transform.Find("Menu").gameObject.SetActive(true);

    }



    public void EncuestaSiguiente() {

        transform.Find("Menu").gameObject.SetActive(false);
        transform.Find("MainGameSettings").gameObject.SetActive(false);
        transform.Find("MainGameSettingsFobia").gameObject.SetActive(true);

        //SceneManager.LoadScene("Casa2");
    }

    public void EncuestaSiguientePhobo() {
        transform.Find("MainGameSettingsFobia").gameObject.SetActive(false);
        transform.Find("MainGameSettingsMapa").gameObject.SetActive(true);


    }


    public void EncuestaVolverPhobo()
    {
        transform.Find("MainGameSettingsFobia").gameObject.SetActive(false);
        transform.Find("MainGameSettings").gameObject.SetActive(true);
        transform.Find("Menu").gameObject.SetActive(false);

    }



    public void EncuestaVolverMap() {
        transform.Find("Menu").gameObject.SetActive(false);
        transform.Find("MainGameSettingsFobia").gameObject.SetActive(true);
        transform.Find("MainGameSettingsMapa").gameObject.SetActive(false);

    }

    public void EncuestaSiguienteMap() {

 

        string type_of_animal = dropdownAnimalType.options[dropdownAnimalType.value].text;
        string map = dropdownMap.options[dropdownMap.value].text;

        string pre_distress = dropdownDistress.options[dropdownDistress.value].text;
        int index_of_twopoints = pre_distress.IndexOf(':');
        float amount_distress = float.Parse(pre_distress.Substring(0, index_of_twopoints));




        PlayerPreferences.LoadResources(type_of_animal, amount_distress, map);



        SceneManager.LoadScene(PlayerPreferences.getMap());
    }

}
