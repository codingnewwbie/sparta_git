using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
        [SerializeField] private bool createDustOnWalk = true;
        [SerializeField] private ParticleSystem dustParticelParticleSystem;
    
        public void CreateDustParticle()
        {
            if (createDustOnWalk)
            {
                dustParticelParticleSystem.Stop();
                dustParticelParticleSystem.Play();
            }
        }
}
