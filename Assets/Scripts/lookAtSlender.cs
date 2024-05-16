using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lookAtSlender : MonoBehaviour
{
    public RawImage staticImage;
    public Color color;
    public float drainRate, rechargeRate, health, healthDamage, healthRechargeRate, maxStaticAmount;
    public float audioIncreaseRate, audioDecreaseRate;
    public bool looking, canRecharge;
    public AudioSource staticSound;
    public string deathScene;

    void Start()
    {
        color.a = 0f;
        health = 100f;
    }
    void OnBecameVisible()
    {
        looking = true;
    }
    void OnBecameInvisible()
    {
        looking = false;
    }
    void FixedUpdate()
    {
        if(color.a > maxStaticAmount)
        {

        }
        else if(color.a < maxStaticAmount)
        {
            staticImage.color = color;
        }
        if (looking == true)
        {
            color.a = color.a + drainRate * Time.deltaTime;
            health = health - healthDamage * Time.deltaTime;
            staticSound.volume = staticSound.volume + audioIncreaseRate * Time.deltaTime;
        }
        if (looking == false)
        {
            color.a = color.a - rechargeRate * Time.deltaTime;
            if (canRecharge == true)
            {
                health = health + healthRechargeRate * Time.deltaTime;
            }
            staticSound.volume = staticSound.volume - audioDecreaseRate * Time.deltaTime;
        }
        if(health < 1)
        {
            SceneManager.LoadScene(deathScene);
        }
    }
}