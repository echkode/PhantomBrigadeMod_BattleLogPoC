// Copyright (c) 2023 EchKode
// SPDX-License-Identifier: BSD-3-Clause

namespace EchKode.PBMods.BattleLog
{
	sealed class BattleLogFeature : Feature
	{
		public BattleLogFeature()
		{
			Add(new InputSystem());
		}

		internal static void Install()
		{
			Heartbeat.SystemInstalls.Add(gc =>
			{
				if (string.IsNullOrWhiteSpace(ModLink.Settings.toggleWindowInputActionKey))
				{
					return;
				}

				var gcs = gc.m_stateDict["game"];
				var gameSystems = gcs.m_systems[0];
				var installee = new BattleLogFeature();
				SystemInstaller.InstallAtEnd(gameSystems, installee);
			});
		}
	}
}
