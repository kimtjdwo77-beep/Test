using UnityEngine;

public class Gameobjectp : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Playerprefs --- 유니티 단순 저장 시스템 키-값 쌍으로 저장 (딕셔너리)
    // 보안에 취약하기 떄문에 주로 게임설정에 쓰는걸 권장한다.
    // 세이브 방법은 Setint , Setfloat 이런식 로드 방법은 Set 대신 Get   ex) Getint

    public int gold = 0;
    public int level = 1;
    public float posx = 0f;
    public float posy = 0f;
    public string playerName = "Player"; 


    void Start()
    {
        gold = 100;
        level = 10;
        posx = 100f;
        posy = 150f;
        playerName = "Nogingu";

        DeleteAll();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Savewithplayerprefs();

            print("세이브 완");
        }
        if(Input.GetMouseButtonDown(1))
        {
            Lordwithplayerprefs();
            print($"Gold { gold}, leb: {level}, Posx: {posx} Posy: {posy} Name: {playerName} ");
        }
        

    }

    //세이브와 로드 방법
    void Savewithplayerprefs()
    {

        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetFloat("PosX", posx);
        PlayerPrefs.SetFloat("PosY", posy);
        PlayerPrefs.SetString("Player", playerName);
        //값만 넣은 상태 , 따라서 데이터들을 파일로 만들어준다
        PlayerPrefs.Save();

    }

    void Lordwithplayerprefs()
    {
        //저장된 값이 없으면 여기서 값 디폴트 설정 가능함
        gold = PlayerPrefs.GetInt("Gold", 100);
        level = PlayerPrefs.GetInt("Level", 1);
        posx = PlayerPrefs.GetFloat("PosX");
        posy = PlayerPrefs.GetFloat("PosY");
        playerName = PlayerPrefs.GetString("Player", "T1");

    }

    //특정 데이터를 삭제하기
    void DeleteData(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    //데이터 존재유무 확인
    bool HasData(string key)
    {
        return PlayerPrefs.HasKey(key);
    }



}
