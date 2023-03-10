using UnityEngine;

namespace EchKode.PBMods.BattleLog
{
	sealed class BattleLogWindow : MonoBehaviour
	{
		public void OnGUI()
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), Texture2D.whiteTexture, 0, false);
		}
	}
}
