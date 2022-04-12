using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Score : MonoBehaviour
{

    public Text scoreText; // スコア表示

    public Text score2Text;

    public Text score3Text;

    public Text score4Text;

    public Text score5Text;

    public Text highScoreText;//ハイスコア表示

    private int score;

    static int[] sc = new int[6];

    private int highScore;

    private string highScoreKey = "highScore";//保存キー

    private string Score2Key = "Score2";

    private string Score3Key = "Score3";

    private string Score4Key = "Score4";

    private string Score5Key = "Score5";

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (highScore < score)
        {
            highScore = score;
        }

        // スコア・ハイスコアを表示
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        score = 0;

        // ハイスコアを取得。保存されてなければ0を取得。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    public void AddPoint(int point)// 加点
    {
        score = score + point;
    }

    public void Save() // 保存
    {
        int s = 0;
        sc[s] = highScore;
        //Console.WriteLine(a[s]);
        s++;
        sc[s] = PlayerPrefs.GetInt(Score2Key, 0);
        // Console.WriteLine(a[s]);
        s++;
        sc[s] = PlayerPrefs.GetInt(Score3Key, 0);
        //Console.WriteLine(a[s]);
        s++;
        sc[s] = PlayerPrefs.GetInt(Score4Key, 0);
        //Console.WriteLine(a[s]);
        s++;
        sc[s] = PlayerPrefs.GetInt(Score5Key, 0);
        //Console.WriteLine(a[s]);
        s++;
        sc[s] = score;
        //Console.WriteLine(a[s]);

        Array.Sort(sc);
        Array.Reverse(sc);

        // スコアを保存
        PlayerPrefs.SetInt(highScoreKey, sc[0]);
        PlayerPrefs.SetInt(Score2Key, sc[1]);
        PlayerPrefs.SetInt(Score3Key, sc[2]);
        PlayerPrefs.SetInt(Score4Key, sc[3]);
        PlayerPrefs.SetInt(Score5Key, sc[4]);

        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }

    public void Rank()//ランキング表示
    {

        int s = 0;

        sc[s] = PlayerPrefs.GetInt(highScoreKey, 0);
        s++;

        sc[s] = PlayerPrefs.GetInt(Score2Key, 0);
        s++;

        sc[s] = PlayerPrefs.GetInt(Score3Key, 0);
        s++;

        sc[s] = PlayerPrefs.GetInt(Score4Key, 0);
        s++;

        sc[s] = PlayerPrefs.GetInt(Score5Key, 0);

        score2Text.text = sc[1].ToString();
        score3Text.text = sc[2].ToString();
        score4Text.text = sc[3].ToString();
        score5Text.text = sc[4].ToString();
        highScoreText.text = sc[0].ToString();
    }
}