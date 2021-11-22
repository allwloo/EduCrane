using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class high_light : MonoBehaviour
{
    bool check;
    float timer;
    double waitingTime;
    GameObject hl_obj;
    ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        /*
        timer = 0;
        waitingTime = 1;

        
        Debug.Log("particel: "+particle);
        if (particle.isPlaying)
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            if (particle.isPlaying)
            {
                Debug.Log("Error!");
            }
        }
        check = false;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            if (check)
            {
                ParticleStop();
            }
            else
            {
                ParticlePlay();
            }
            Debug.Log("check: "+check);
            timer = 0;
        }
        */
    }

    public void ParticlePlay(GameObject hl_obj)
    {
        /*
        particle = hl_obj.GetComponent<ParticleSystem>();
        if (check)
        {
            Debug.Log("particle is already play!");
        }
        else
        {
            particle.Play();
            check = true;
        }
        */
        particle = hl_obj.GetComponent<ParticleSystem>();
        particle.Play();
    }

    public void ParticleStop(GameObject hl_obj)
    {
        particle = hl_obj.GetComponent<ParticleSystem>();
        particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        /*
        if (!check)
        {
            Debug.Log("particle is already stop!");
        }
        else
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            check = false;
        }
        */
    }
}
