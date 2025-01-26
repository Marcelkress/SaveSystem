using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemSettings : MonoBehaviour
{
    public SaveSlot currentSaveSlot;

    void Start()
    {
        SaveSystem.currentSaveSlot = currentSaveSlot;
    }

}

public enum SaveSlot
{
    Slot1 = 1,
    Slot2 = 2,
    Slot3 = 3
}


