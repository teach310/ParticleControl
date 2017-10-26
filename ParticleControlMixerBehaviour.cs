using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ParticleControlMixerBehaviour : PlayableBehaviour {

	ParticleSystem particleSystem;
	bool isInit = false;
	public bool controlActivation = true;

	void InitializeIfNeeded(object playerData){
		if (isInit)
			return;

		this.particleSystem = playerData as ParticleSystem;
		isInit = true;
	}

	// Activate And Initialize
	public override void ProcessFrame (Playable playable, FrameData info, object playerData)
	{
		InitializeIfNeeded (playerData);
		if (particleSystem == null)
			return;
		int inputCount = playable.GetInputCount<Playable>();
		bool flag = false;
		for (int inputIndex = 0; inputIndex < inputCount; ++inputIndex)
		{
			if ((double) playable.GetInputWeight<Playable>(inputIndex) > 0.0)
			{
				flag = true;
				break;
			}
		}
		particleSystem.gameObject.SetActive (flag);
	}

	public override void OnGraphStop (Playable playable)
	{
		if (particleSystem == null)
			return;
		particleSystem.gameObject.SetActive (false);
	}
}
