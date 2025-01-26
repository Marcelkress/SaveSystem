using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    public Settings settings;

    public bool save;

    void Start()
    {
        settings = new();

        if (save == true)
        {
            settings.audioVol = 67.8f;
            settings.fieldOfView = 95;
            settings.accesibilty = false;
            settings.sensitivity = 5.5f;

            SaveSystem.SaveData<Settings>(settings, "Settings");
        }
        else
        {
            settings = SaveSystem.LoadData<Settings>("Settings");
        }
    }

    
}

[System.Serializable]
public class Settings
{
    public int fieldOfView;
    public float audioVol;
    public float sensitivity;
    public bool accesibilty;
}
