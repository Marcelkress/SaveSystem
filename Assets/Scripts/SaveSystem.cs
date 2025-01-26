using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static SaveSlot currentSaveSlot;

    public static void SaveData<T>(T data, string name)
    {
        SaveData<T> classToSave = new SaveData<T>();

        classToSave.data = data;
        classToSave.name = name;

        string jsonString = JsonUtility.ToJson(classToSave);

        string filePath = GetFilePath(classToSave.name);

        File.WriteAllText(filePath, jsonString);

        Debug.Log("Data saved to: " + filePath);
    }

    public static T LoadData<T>(string name)
    {
        string filePath = GetFilePath(name);

        if (!File.Exists(filePath))
            return default;

        string jsonString = File.ReadAllText(filePath);

        SaveData<T> loadedData = JsonUtility.FromJson<SaveData<T>>(jsonString);

        Debug.Log("Data loaded from: " + filePath);
        return loadedData.data;
    }

    static string GetFilePath(string name)
    {
        string slotString = currentSaveSlot.ToString();

        string path = Path.Combine(Application.persistentDataPath, slotString + $"/{name}.json");

        string directory = Path.Combine(Application.persistentDataPath, slotString);

        if (!Directory.Exists(directory))
        {
            CreateDirectory(directory);
        }

        return path;
    }

    static void CreateDirectory(string directory)
    {
        Directory.CreateDirectory(directory);
    }
}

public class SaveData<T>
{
    public string name;
    public T data;
}
