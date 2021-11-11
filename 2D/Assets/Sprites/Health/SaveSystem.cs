using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   public static void SavePlayer(PlayerStatus stats)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.fun";
		FileStream stream = new FileStream(path, FileMode.Create);

		DPlayer data = new DPlayer(stats);
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static DPlayer LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.fun";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			DPlayer data = formatter.Deserialize(stream) as DPlayer;
			stream.Close();
			
			return data;
		}
		else
		{
			Debug.Log("Save file not found in " + path);
			return null;
		}
	}
}
