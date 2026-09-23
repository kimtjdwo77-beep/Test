using UnityEngine;
using UnityEngine.UI;
using TMPro; // 얘를 해줘야지 text messi pro 사용가능

public class Uitet : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI timertxt;
    public TextMeshProUGUI messagetxt;
    public Button resetbuttons;

    int highscore = 0;
    int currentscore = 0;
    float gamtimer = 0f;
       

    void Start()
    {
        //버튼을 인스펙터 창에서 직접 연결 없이 코드로 직접 연결시켜주는 방법 버튼을 ㅇㅇ

        resetbuttons.onClick.AddListener(ResetButtonclip);
        resetbuttons.onClick.AddListener(ResetUI);

    }

    // Update is called once per frame
    void Update()
    {
        gamtimer += Time.deltaTime;
        UpdateTxtscore();

        UpdateTimertxt();

        //키 눌러서 점수
        if(Input.GetKeyDown(KeyCode.V))
        {
            Addscore(10);
            ShowTempmsg(" + 10점 추가 ", 1f);
        }

        //랜덤 머시기 멋이 기 깔 나
        if(Input.GetKeyDown(KeyCode.C))
        {
            Color randcolor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f) , Random.Range(0f, 1f));
            ChangerTextcolor(timertxt, randcolor);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            changerTextfonsize(scoretxt,scoretxt.fontSize + 5);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            changerTextfonsize(scoretxt, scoretxt.fontSize + 5);
        }



    }

    void ChangerTextcolor(TextMeshProUGUI text, Color color)
    {
        if(text != null)
        {
            text.color = color;

        }

    }

    void changerTextfonsize(TextMeshProUGUI text, float size)
    {
        if( text != null)
        {

            text.fontSize = size;
        }

    }

    void ShowMessage(string msg)
    {
        if(msg != null)
        {
            messagetxt.text = msg;

            messagetxt.gameObject.SetActive(true);
            print("메세지 표시: " + msg);

        }

    }
    //일정시간이 지난 후에 메세지를 삭제하기 (코루틴, 인보크)
    void ShowTempmsg(string msg, float duration = 2f) 
    {
        ShowMessage(msg);

        Invoke("HideMessage", duration);

    }
    
    void HideMessage()
    {

        if(messagetxt != null)
        {

            messagetxt.gameObject.SetActive(false);

        }
    }
    void UpdateTimertxt()
    {
        int min = Mathf.FloorToInt(gamtimer / 60);
        int sec = Mathf.FloorToInt(gamtimer % 60);

        timertxt.text = $"타이머: [{min:D2} : {sec:D2}";

    }

    void Addscore(int points)
    {
        //currentscore++;
        currentscore += points;
        
        if(currentscore > highscore)
        {
             highscore = currentscore;
        }

        print("점메추");
    }

    void UpdateTxtscore()
    {
        if(scoretxt != null)
        {
            scoretxt.text = $"점수 : {currentscore}";
        }

    }

    public void ResetButtonclip()
    {
        print("ㄱ- no batidao");
    }

    void ResetUI()
    {
        ResetScore();
        Resetimer();
        ShowTempmsg("점수와 시간 초기화" , 5f);

    }

    void Resetimer()
    {
        gamtimer = 0f;
        UpdateTimertxt();
        print("탐초");

    }

    void ResetScore()
    {
        currentscore = 0;
        UpdateTxtscore();
        print("점 초");
    }
}
