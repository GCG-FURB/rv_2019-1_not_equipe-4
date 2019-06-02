using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using UnityEngine.Video;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static GameObject[] animais;
    public static AudioSource[] audioAnimais;
    public static AudioSource[] animalFalado;
    public static AudioSource[] historia;
    public static GameObject[] trads;
    public static GameObject[] animalLibras;
    public static GameObject[] textos;
    public static GameObject animalSelecionado;
    public static int animalIndex;
    public static bool mark2;
    public static bool mark1;
    public static bool markText;
    public static AudioSource audioSource;
    public static AudioClip audioClip;

    void Awake()
    {
        //rawImage = RawImage.FindObjectOfType<RawImage>();
        //videoPlayer = VideoPlayer.FindObjectOfType<VideoPlayer>();
        //rawImage.texture = videoPlayer.texture;
        //print("videoPlayer.texture: " + videoPlayer.texture);
        //print("rawImage.texture: " + rawImage.texture);

        animais = GameObject.FindGameObjectsWithTag("Animal1");
        audioAnimais = GameObject.FindGameObjectsWithTag("AudioAnimal").Select(x => x.GetComponent<AudioSource>()).ToArray();
        animalFalado = GameObject.FindGameObjectsWithTag("AnimalFalado").Select(x => x.GetComponent<AudioSource>()).ToArray();
        historia = GameObject.FindGameObjectsWithTag("Historia").Select(x => x.GetComponent<AudioSource>()).ToArray();
        trads = GameObject.FindGameObjectsWithTag("Traducao");
        animalLibras = GameObject.FindGameObjectsWithTag("AnimalLibras");
        textos = GameObject.FindGameObjectsWithTag("Text");
        animalIndex = 0;
        mark2 = false;
        mark1 = false;
        markText = false;
        

        foreach (GameObject animal in animais)
        {
            animal.SetActive(false);
        }

        foreach (GameObject trad in trads)
        {
            trad.SetActive(false);
        }

        foreach (GameObject animalLibra in animalLibras)
        {
            animalLibra.SetActive(false);
        }
        //foreach (GameObject texto in textos)
        //{
        //    texto.SetActive(false);
        //}
        print(animais.Length);
        animais[0].SetActive(true);
    }
}
