using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public RawImage slideImage; //reference to your UI RawImage component
    public Texture[] slides;    //array of slide images
    private int currentIndex = 0;



    void Start()
    {
        if (slides.Length > 0 && slideImage != null)
            slideImage.texture = slides[currentIndex];
    }

    void Update()
    {
        //next slide
        if (Input.GetKeyDown(KeyCode.N)) //'N' button 
        {
            NextSlide();
        }

        //previous slide
        if (Input.GetKeyDown(KeyCode.P)) //'P' button 
        {
            PreviousSlide();
        }

    }

    public void NextSlide()
    {
        //you can only move forward if you're NOT on the last slide
        if (currentIndex < slides.Length - 1)
        {
            currentIndex++;
            slideImage.texture = slides[currentIndex];
        }
    }

    public void PreviousSlide()
    {
        //you can only move backward if you're NOT on the first slide
        if (currentIndex > 0)
        {
            currentIndex--;
            slideImage.texture = slides[currentIndex];
        }
    }
}