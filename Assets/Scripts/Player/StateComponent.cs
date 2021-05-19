using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateComponent : MonoBehaviour
{
    public bool isGrounded = false;
    public bool canFly = false;
    public int shields = 0;
    public bool isDamaged = false;
    public int damageEffectCounter = 0;
    public GameObject loseScreen;
    private int screenCounter=0;
    private bool isDead = false;

    int orbs;
    int keys;

    GameObject shieldCounter;
    GameObject orbCounter;
    GameObject keyCounter;

    public Vector2 iniPosition;

    public bool cantDie = false;

    public GameObject damageSound;
    static AudioSource damageSoundSource;


    void Start()
    {
        if(damageSoundSource==null)
        {
            damageSoundSource = Instantiate(damageSound).GetComponent<AudioSource>();
        }
        shieldCounter = GameObject.Find("ShieldCounter");
        orbCounter = GameObject.Find("OrbCounter");
        keyCounter = GameObject.Find("KeyCounter");
        AddShield();
    }

    void Update()
    {
        if(isDamaged)
        {
            ColorDamageEffect(true);
            damageEffectCounter++;
        }
        if(damageEffectCounter>=100)
        {
            ColorDamageEffect(false);
            isDamaged = false;
            damageEffectCounter = 0;
        }
        if(isDead==true)
        {
            screenCounter++;
            if(screenCounter>=500)
            {
                isDead = false;
                ResetLevel();
                screenCounter = 0;
            }
        }
    }

    public void AddOrb()
    {
        orbs += 1;
        if (orbs > 9)
        {
            orbs = 0;
            AddShield();
        }
        orbCounter.GetComponent<Text>().text = "X "+ orbs;
    }

    public void AddKey()
    {
        keys += 1;
        keyCounter.GetComponent<Text>().text = "X " + keys;
    }

    public void RemoveKey()
    {
        keys -= 1;
        keyCounter.GetComponent<Text>().text = "X " + keys;
    }

    void AddShield()
    {
        shields += 1;
        shieldCounter.GetComponent<Text>().text = "X " + shields;
    }

    public void RecieveDamage(int damage) {
        damageSoundSource.Play();
        if (shields < damage) {
            Die();
        }
        else {
            shields -= damage;
            shieldCounter.GetComponent<Text>().text = "X " + shields;
            isDamaged = true;
        }
    }
    public void Die() {

        if (cantDie)
        {
            shieldCounter.GetComponent<Text>().text = "X " + 0;
        }
        else
        {
            ShowLoseScreen();
        }
    }

    public void ColorDamageEffect(bool isActivated)
    {
        if(isActivated)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        
    }

    public int GetKeys() {
        return keys;
    }

    public void ShowLoseScreen()
    {
        AudioListener.volume = 0f;
        Instantiate(loseScreen, Camera.main.transform);
        isDead = true;
    }

    public void ResetLevel()
    {
        AudioListener.volume = 1f;
        FreezeWorldComponent.instance.ResetWorld();
        EraChangeWorldComponent.instance.ResetWorld();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
