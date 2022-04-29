using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public TutorialManager tutorialManager;


    private void OnTriggerEnter()
    {
        tutorialManager.FirstStep();
    }
}
