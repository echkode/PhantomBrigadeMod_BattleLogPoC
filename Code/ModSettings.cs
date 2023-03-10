// Copyright (c) 2023 EchKode
// SPDX-License-Identifier: BSD-3-Clause

using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace EchKode.PBMods.BattleLog
{
	partial class ModLink
	{
		internal sealed class ModSettings
		{
			[System.Flags]
			internal enum LoggingFlag
			{
				None = 0,
				System = 0x1,
				KeyBinding = 0x2,
				All = 0xFF,
			}

#pragma warning disable CS0649
			public LoggingFlag logging;
			public string toggleWindowInputActionKey;
			public string languageSector;
			public Dictionary<string, string> labelTextEntries;
#pragma warning restore CS0649

			internal bool IsLoggingEnabled(LoggingFlag flag) => (logging & flag) == flag;
		}

		internal static ModSettings Settings;

		internal static void LoadSettings()
		{
			var settingsPath = Path.Combine(modPath, "settings.yaml");
			Settings = UtilitiesYAML.ReadFromFile<ModSettings>(settingsPath, false);
			if (Settings == null)
			{
				Settings = new ModSettings()
				{
					labelTextEntries = new Dictionary<string, string>(),
				};

				Debug.LogFormat(
					"Mod {0} ({1}) no settings file found, using defaults | path: {2}",
					modIndex,
					modId,
					settingsPath);
			}

			if (Settings.logging != ModSettings.LoggingFlag.None)
			{
				Debug.LogFormat(
					"Mod {0} ({1}) diagnostic logging is on: {2}",
					modIndex,
					modId,
					Settings.logging);

				var entries = new List<string>();
				foreach (var kvp in Settings.labelTextEntries)
				{
					entries.Add(kvp.Key + ": " + kvp.Value);
				}
				Debug.LogFormat(
					"Mod {0} ({1}) settings\n  toggleWindowInputActionKey: {2}\n  languageSector: {3}\n  {4}",
					modIndex,
					modId,
					Settings.toggleWindowInputActionKey,
					Settings.languageSector,
					string.Join("\n  ", entries));
			}
		}
	}
}
