// Copyright (c) 2023 EchKode
// SPDX-License-Identifier: BSD-3-Clause

using Entitas;

using PhantomBrigade.Data;

using UnityEngine;

namespace EchKode.PBMods.BattleLog
{
	sealed class InputSystem : IExecuteSystem
	{
		private static BattleLogWindow blw;

		public void Execute()
		{
			if (string.IsNullOrWhiteSpace(ModLink.Settings.toggleWindowInputActionKey))
			{
				return;
			}

			var inputActions = DataMultiLinker<DataContainerInputAction>.data;
			if (!inputActions.ContainsKey(ModLink.Settings.toggleWindowInputActionKey))
			{
				return;
			}
			var inputAction = inputActions[ModLink.Settings.toggleWindowInputActionKey];

			if (InputHelper.CheckAndConsumeAction(inputAction.actionID))
			{
				ToggleLogWindow();
			}
		}

		private static void ToggleLogWindow()
		{
			Debug.LogFormat(
				"Mod {0} ({1}) toggling battle log window",
				ModLink.modIndex,
				ModLink.modId);

			if (blw != null)
			{
				blw.enabled = !blw.enabled;
				return;
			}

			var go = new GameObject();
			blw = go.AddComponent<BattleLogWindow>();
			blw.enabled = true;
		}
	}
}
