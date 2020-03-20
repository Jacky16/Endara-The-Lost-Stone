using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerLifeManager playerData;
    public SaveData()
    {

    }
}
[SerializeField]
public class PlayerData
{
    public int MyLife;
    public PlayerData(int life)
    {
        this.MyLife = life;
    }

}