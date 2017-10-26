using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class ParticleControlClip : PlayableAsset, ITimelineClipAsset {

	public ParticleControlBehaviour template = new ParticleControlBehaviour();

	#region ITimelineClipAsset implementation

	public ClipCaps clipCaps {
		get {
			return ClipCaps.None;
		}
	}

	#endregion

	public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
	{
		return ScriptPlayable<ParticleControlBehaviour>.Create (graph, template);
	}
}
