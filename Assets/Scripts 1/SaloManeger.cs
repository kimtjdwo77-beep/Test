using System;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

//데이터?
[System.Serializable] // 데이터 직렬화 , 내부적으로 바이트 형으로 변환하는거
public class PlayerData
{

    public int level;
    public int gold;
    public string name;
    public float posX;
    public float posY;

    public PlayerData()
    {

        level = 1;
        gold = 100;
        name = "Player";
        posX = 0;
        posY = 0;

    }

}

public class Setting
{

}


public class SaloManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 싱글톤 패턴: 게임에 딱 하나 존재
    public static SaloManeger Instance { get; private set;  }

    public PlayerData playerData;
    string fileName = "playerData.json";
    string playerDataPath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerDataPath = Path.Combine(Application.persistentDataPath, fileName);

        playerData = new PlayerData();

    }

    //데이터저장띠
   // public void SaveplayerData()
   // {
   //     try
   //     {
   //         // c# 클 -> json 문자열 변환  오브젝트나 스크립트는 하나의 클래스, 즉 인자로 오브젝트를 받는다는 것

   //         string json = JsonUtility.ToJson(playerData, true);
   //         File.WriteAllText(playerDataPath, json);

   //     }
   //     catch (Exception e)
   //     {
   //         Debug.LogError($"저장 실패: {e.Message}");
   //     }

   // }

   // public bool LordplayerData()
   // {
   //     if(File.Exists(playerDataPath))
   //     {
   //         return false;
   //     }


   //     try
   //     {
   //         // c# 클 -> json 문자열 변환  오브젝트나 스크립트는 하나의 클래스, 즉 인자로 오브젝트를 받는다는 것

   //         string json = File.ReadAllText(playerDataPath);
   //         File.WriteAllText(playerDataPath, json);
   //         playerData = JsonUtility.FromJson<PlayerData>(json);
   //         return true;

   //     }
   //     catch (Exception e)
   //     {
   //         Debug.LogError($"불러오기: {e.Message}");
   //         return false;
   //     }


   // }

   //public void Deletesavealldata()
   // {
   //     if(File.Exists(playerDataPath))
   //     {
   //         File.Delete(playerDataPath);
   //     }
   //     playerData = new PlayerData();
       
   // }

    //void UpdateSavedata()
    //{

    //    if (SaloManeger.Instance == null)
    //    {

    //        PlayerData data = SaloManeger.Instance.playerData;

    //        data.level = 5;
    //        data.gold = 1557;

    //        SaloManeger.Instance.SaveplayerData();
    //    }    
    //}


}
