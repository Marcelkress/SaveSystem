using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExample : MonoBehaviour
{

    public int health;
    public string nameOfObject;
    public List<float> scores;

    void Start()
    {
        SaveSystem.SaveData<int>(health, "Health");
        SaveSystem.SaveData<string>(nameOfObject, nameOfObject);
        SaveSystem.SaveData<List<float>>(scores, "Player scores");

        //health = SaveSystem.LoadData<int>("Health");
        //scores = SaveSystem.LoadData<List<float>>("Player scores");
    }

    
}
