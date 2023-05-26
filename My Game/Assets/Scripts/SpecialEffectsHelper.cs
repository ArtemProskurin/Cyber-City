using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;
    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SpecialEffectsHelper");
        }

        Instance = this;
    }

    public void Explosion(Vector3 position)
    {
        instatiate(smokeEffect, position);
        instatiate(fireEffect, position);
    }
    private ParticleSystem instatiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParcticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity
        ) as ParticleSystem;
        Destroy(
            newParcticleSystem.gameObject,
            newParcticleSystem.startLifetime
        );
        return newParcticleSystem;
        
    }
}
