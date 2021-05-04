using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    ParticleSystem ps;
    int currentState;
    float seed;
    void Start()
    {
        rainParticleSystem.Stop();
        ps = GetComponent<ParticleSystem>();
        currentState = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ps.isPlaying){
            currentState = markov(currentState);
            ps = changeClouds(ps,currentState,seed);
            ps.Play();
        }
    }

    int markov(int currentState){
        seed = 100*Random.Range(0.0f,1.0f);
        switch(currentState){
            case 1:
                if(seed>50){
                    return 2;
                }
                else{
                    return 1;
                }
                break;
            case 2:
                if(seed<34){
                    return 1;
                }
                else if((seed>33)&&(seed<67)){
                    return 2;
                }
                else{
                    return 3;
                }
                break;
            case 3:
                if(seed<34){
                    return 2;
                }
                else if((seed>33)&&(seed<67)){
                    return 3;
                }
                else{
                    return 4;
                }
                break;
            case 4:
                if(seed<34){
                    return 3;
                }
                else if((seed>33)&&(seed<67)){
                    return 4;
                }
                else{
                    return 2;
                }
                break;
            default:
                return 1;
                break;
        }
    }

    ParticleSystem changeClouds(ParticleSystem ps, int currentState, float seed){
        switch(currentState){
            case 1:
                ps.maxParticles = 0;
                return ps;
                break;
            case 2:
                ps.maxParticles = 200;
                ps.startColor = new Color(168,169,180,255);
                if(seed<06){
                    rainParticleSystem.maxParticles = 200;
                    rainParticleSystem.Play();
                }
                return ps;
                break;
            case 3:
                ps.maxParticles = 500;
                ps.startColor = new Color(168,148,149,255);
                if(seed<51){
                    rainParticleSystem.maxParticles = 700;
                    rainParticleSystem.Play();
                }
                return ps;
                break;
            case 4:
                ps.maxParticles = 1000;
                ps.startColor = new Color(127,128,140,255);
                if(seed<91){
                    rainParticleSystem.maxParticles = 1000;
                    rainParticleSystem.Play();
                }
                return ps;
                break;
        }
        return ps;
    }

}

