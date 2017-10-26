using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;


[TrackColor(0.2313f, 0.6353f, 0.5843f)]
[TrackClipType(typeof(ParticleControlClip))]
[TrackBindingType(typeof(ParticleSystem))]
public class ParticleControlTrack : TrackAsset {
	

	protected override Playable CreatePlayable (PlayableGraph graph, GameObject go, TimelineClip clip)
	{
		return base.CreatePlayable (graph, go, clip);
	}

	public override Playable CreateTrackMixer (PlayableGraph graph, GameObject go, int inputCount)
	{
		return ScriptPlayable<ParticleControlMixerBehaviour>.Create (graph, inputCount);
	}
}
