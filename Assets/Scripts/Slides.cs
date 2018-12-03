using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slides : MonoBehaviour {

    [SerializeField]
    List<GameObject> slides;
    [SerializeField]
    GameObject MainMenuScene;

    GameObject currentSlide;
    
    int currentSlideIndex = 0;
    // Use this for initialization
    void Start() {

        foreach (var slide in slides)
            slide.SetActive(false);
        currentSlide = slides[currentSlideIndex];
        currentSlide.SetActive(true);
    }

    public void NextSlide()
    {
        currentSlideIndex++;
        if (currentSlideIndex >= slides.Count)
        {
            gameObject.SetActive(false);
            MainMenuScene.SetActive(true);
            return;
        }
        currentSlide = slides[currentSlideIndex];
        foreach (var slide in slides)
            slide.SetActive(false);

        currentSlide.SetActive(true);
    }

}
