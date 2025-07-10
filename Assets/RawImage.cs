/*using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public RawImage slideImage; //reference to UI RawImage component
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
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SlideShow : MonoBehaviour
{
    public RawImage slideImage;        // Assign SlideImage here
    public Texture[] slides;           // Your image slides
    public RenderTexture videoTexture; // Assign VideoTexture here
    public VideoPlayer videoPlayer;    // Assign VideoPlayer here
    public int currentSlide = 0;

    void Start()
    {
        ShowSlide(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && currentSlide < slides.Length)
        {
            NextSlide();
        }
        if (Input.GetKeyDown(KeyCode.P) && currentSlide > 0)
        {
            PrevSlide();
        }
    }

    public void NextSlide()
    {
        if (currentSlide < slides.Length)
        {
            currentSlide++;
            ShowSlide(currentSlide);
        }
    }

    public void PrevSlide()
    {
        if (currentSlide > 0)
        {
            currentSlide--;
            ShowSlide(currentSlide);
        }
    }

    public void ShowSlide(int index)
    {
        // If it's the last slide, show the video
        if (index == slides.Length)
        {
            slideImage.texture = videoTexture;
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.frame = 0;
            videoPlayer.Play();
        }
        else
        {
            slideImage.texture = slides[index];
            videoPlayer.Stop();
            videoPlayer.gameObject.SetActive(false);
        }
        currentSlide = Mathf.Clamp(index, 0, slides.Length);
    }
}
