using UnityEngine;


[ExecuteInEditMode]

public class particlefix : MonoBehaviour 




	{
		ParticleSystem.Particle[] unused = new ParticleSystem.Particle[1];

		void Awake()
		{
			GetComponent<ParticleSystemRenderer>().enabled = false;
		}

		void LateUpdate()
		{
			GetComponent<ParticleSystemRenderer>().enabled = GetComponent<ParticleSystem>().GetParticles(unused) > 0;
		}
	}