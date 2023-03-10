// Copyright (c) 2023 EchKode
// SPDX-License-Identifier: BSD-3-Clause

using HarmonyLib;

using PBSettingUtility = PhantomBrigade.Data.SettingUtility;

namespace EchKode.PBMods.BattleLog
{
	[HarmonyPatch]
	static class Patch
	{
		[HarmonyPatch(typeof(PBSettingUtility), "LoadData")]
		[HarmonyPostfix]
		static void Su_LoadDataPostfix()
		{
			SettingUtility.LoadData();
		}

		[HarmonyPatch(typeof(PhantomBrigade.Heartbeat), "Start")]
		[HarmonyPrefix]
		static void Hb_StartPrefix()
		{
			Heartbeat.Start();
		}
	}
}
