using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[Serializable]
public class ParticleControlBehaviour : PlayableBehaviour{

	ParticleSystem particleSystem;
	public bool syncLifetime = true;
	float lastPsTime;
	float lastTime = -1f;
	bool isInit = false;

	void InitializeIfNeeded(object playerData){
		if (isInit)
			return;
		
		this.particleSystem = playerData as ParticleSystem;
		isInit = true;
	}

	public override void PrepareFrame (Playable playable, FrameData info)
	{
		if (particleSystem == null || !particleSystem.gameObject.activeInHierarchy)
			return;

		float time = (float)playable.GetTime<Playable> ();
		if (!Mathf.Approximately(lastTime , -1f) && Mathf.Approximately(lastTime , time))
			return;
		float num1 = Time.fixedDeltaTime * 0.5f;
		float t1 = time;
		float num2 = t1 - lastTime;
		if ((double) t1 < (double) lastTime || (double) t1 < (double) num1 || Mathf.Approximately(lastTime, -1f) || (double) num2 > (double) this.particleSystem.main.duration || !Mathf.Approximately(lastPsTime, this.particleSystem.time))
		{
			this.particleSystem.Simulate(0.0f, true, true);
			this.particleSystem.Simulate(t1, true, false);
		}
		else
		{
			float num3 = t1 % this.particleSystem.main.duration;
			float t2 = num3 - this.particleSystem.time;
			if ((double) t2 < -(double) num1)
				t2 = num3 + this.particleSystem.main.duration - this.particleSystem.time;
			this.particleSystem.Simulate(t2, true, false);
		}
		lastPsTime = this.particleSystem.time;
		lastPsTime = time;

		if (syncLifetime) {
			var main = particleSystem.main;
			main.startLifetimeMultiplier = (float)playable.GetDuration<Playable> ();
		}
	}

	// Activate And Initialize
	public override void ProcessFrame (Playable playable, FrameData info, object playerData)
	{
		InitializeIfNeeded (playerData);
	}

	public override void OnBehaviourPlay (Playable playable, FrameData info)
	{
		lastTime = -1f;
	}

	public override void OnBehaviourPause (Playable playable, FrameData info)
	{
		lastTime = -1f;
	}

}
