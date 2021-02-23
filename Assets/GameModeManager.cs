using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    // We use STATES because we wanna know when the game is oplaying
    public enum GameState
    {
        FREEMODE,
        PLAYING,
        SCORING,
    }

    [Header("[Game Mode : Time Limit ]")]
    [SerializeField]
    private Button startbutton ;
    [SerializeField]
    private Button stopbutton;
    // We have to update the 3 panels which display time
    [SerializeField]
    private Text left_timepanel;
    [SerializeField]
    private Text right_timepanel;
    [SerializeField]
    private Text top_timepanel;
    [SerializeField]
    private Text final_score;
    [SerializeField]
    private GameObject default_panel;
    [SerializeField]
    private GameObject scoring_panel;
    [SerializeField] private GameState game_state = GameState.FREEMODE;
    [SerializeField] private float game_time_limit = 30.0f;
    [SerializeField] private float countdown ;
    public ScoreManager scoremanager; // we need the scoremanager to reset it when the game mode launch
    
    int final_points; 

    private void Awake()
    {
        countdown = game_time_limit;
    }
    void Start()
    {
        left_timepanel.gameObject.SetActive(false);
        right_timepanel.gameObject.SetActive(false);
        top_timepanel.gameObject.SetActive(false);
        stopbutton.gameObject.SetActive(false);
        // we have to rest the score in free mode
        scoremanager.ResetScore();

        default_panel.SetActive(true);
        scoring_panel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (game_state == GameState.FREEMODE)
        {

        }
        if (game_state == GameState.PLAYING)
        {
            // managing time on countdown
            if (countdown <= 0)
            {
                final_points = scoremanager.GetScore();
                scoremanager.ResetScore();
                game_state = GameState.SCORING;
                
                
            }
            else
            {
                countdown -= Time.deltaTime;
            }
            //  we manage below the 3 countdowns panels
            left_timepanel.text = "" + Mathf.Round(countdown);
            right_timepanel.text = "" + Mathf.Round(countdown);
            top_timepanel.text = "" + Mathf.Round(countdown);
        }
        if (game_state == GameState.SCORING)
        {
            Scoring();
        }
    }
    // The time limit game is activated here
    public void StartTimeLimitGame()
    {
        scoremanager.ResetScore();
        left_timepanel.gameObject.SetActive(true);
        right_timepanel.gameObject.SetActive(true);
        top_timepanel.gameObject.SetActive(true);
        stopbutton.gameObject.SetActive(true);
        startbutton.gameObject.SetActive(false);
        countdown = game_time_limit;

        if(game_state == GameState.SCORING)
        {
            default_panel.SetActive(true);
            scoring_panel.SetActive(false);
        }
       
        game_state = GameState.PLAYING;

    }
    public void Scoring()
    {
        default_panel.SetActive(false);
        scoring_panel.SetActive(true);
        final_score.text = "NOT BAD ! " + "\n" + "YOU SCORED : " + final_points;
        countdown = game_time_limit;
    }
    public void StartFreeMode()
    {
        scoremanager.ResetScore();
        default_panel.SetActive(true);
        scoring_panel.SetActive(false);

        stopbutton.gameObject.SetActive(false);
        startbutton.gameObject.SetActive(true);

        left_timepanel.gameObject.SetActive(false);
        right_timepanel.gameObject.SetActive(false);
        top_timepanel.gameObject.SetActive(false);
        countdown = game_time_limit;
        
        game_state = GameState.FREEMODE;

    }
}
