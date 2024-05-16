using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupBook : MonoBehaviour
{
    public GameObject collectTextObj, intText;
    public AudioSource pickupSound, ambianceLayer12, ambianceLayer34, ambianceLayer56, ambianceLayer7;
    public bool interactable;
    public static int pagesCollected;
    public Text collectText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pagesCollected++;
                collectText.text = pagesCollected + "/8 books";
                collectTextObj.SetActive(true);
                pickupSound.Play();

                // Stop the current ambiance layer
                if (pagesCollected == 1)
                {
                    StopAndPlay(ambianceLayer12);
                }
                else if (pagesCollected == 3)
                {
                    StopAndPlay(ambianceLayer34);
                }
                else if (pagesCollected == 5)
                {
                    StopAndPlay(ambianceLayer56);
                }
                else if (pagesCollected == 7)
                {
                    StopAndPlay(ambianceLayer7);
                }

                intText.SetActive(false);
                gameObject.SetActive(false);
                interactable = false;
            }
        }
    }

    void StopAndPlay(AudioSource newAmbiance)
    {
        // Stop the current ambiance layer
        if (ambianceLayer12.isPlaying)
        {
            ambianceLayer12.Stop();
        }
        else if (ambianceLayer34.isPlaying)
        {
            ambianceLayer34.Stop();
        }
        else if (ambianceLayer56.isPlaying)
        {
            ambianceLayer56.Stop();
        }
        else if (ambianceLayer7.isPlaying)
        {
            ambianceLayer7.Stop();
        }

        // Play the new ambiance layer
        newAmbiance.Play();
    }
}