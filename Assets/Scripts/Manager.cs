using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{



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
        SceneManager.LoadScene(PlayerPreferences.getMap());
    }

}
