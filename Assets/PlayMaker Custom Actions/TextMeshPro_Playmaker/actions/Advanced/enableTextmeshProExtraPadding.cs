// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Advanced")]
    [Tooltip("Enable Text Mesh Pro Extra Padding.")]

	public class enableTextmeshProExtraPadding : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshPro))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Check this to enable extra padding.")]
		public FsmBool enableExtraPadding;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

		TextMeshPro meshproScript;

		public override void Reset()
		{

			gameObject = null;
            enableExtraPadding = false;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			meshproScript = go.GetComponent<TextMeshPro>();

			if (!everyFrame.Value)
			{
				DoMeshChange();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoMeshChange();
			}
		}

		void DoMeshChange()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			meshproScript.extraPadding = enableExtraPadding.Value;
		}

	}
}