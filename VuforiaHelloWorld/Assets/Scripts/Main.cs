using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class Main : MonoBehaviour
{
    public static GameObject[] animais;
    public static GameObject animalSelecionado;
    public static int animalIndex;
    public static bool mark2;
    public static bool mark1;

    void Awake()
    {
        animais = GameObject.FindGameObjectsWithTag("Animal1");
        animalIndex = 0;
        mark2 = false;

        foreach (GameObject animal in animais)
        {
            animal.SetActive(false);
        }
        animais[0].SetActive(true);
        print("Main awake");
        print(animais[0]);
        /*animais = GameObject.FindGameObjectsWithTag("Animal1");
        foreach (GameObject animal in animais)
        {
            animal.SetActive(false);
            print("achou animal");
        }*/
    }
}
