using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameContainer gameContainer;
    [SerializeField] private GameUIManager uiManager;

    private List<ICharacter> ai_enemy = new List<ICharacter>();
    private List<ICharacter> ai_friends = new List<ICharacter>();
    private List<ICharacter> ai_friends_player = new List<ICharacter>();

    private PlayerController playerController;

    private void Start()
    {
        playerController = new PlayerController(gameContainer.GetPlayerView);

        for (int i = 0; i < gameContainer.AIViewsEnemy.Length; i++)
        {
            var mob = new AIController(gameContainer.AIViewsEnemy[i], gameContainer.GetPlayerView);
            mob.Init(this);
            ai_enemy.Add(mob);
        }

        for (int i = 0; i < gameContainer.AIViewsFriends.Length; i++)
        {
            var mob = new AIController(gameContainer.AIViewsFriends[i], gameContainer.GetPlayerView);
            mob.Init(this);
            ai_friends.Add(mob);
        }

        uiManager.SetFriendsMapCounter(ai_friends.Count);
        uiManager.SetFriendsPlayerCounter(ai_friends_player.Count);
    }

    private void Update()
    {
        playerController.Tick();

        foreach (var mob in ai_enemy)
        {
            mob.Tick();
        }

        foreach (var mob in ai_friends)
        {
            mob.Tick();
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Lose!");
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Win!");
    }

    public void AddFriendsToPlayer(ICharacter character)
    {
        ai_friends_player.Add(character);
        uiManager.SetFriendsPlayerCounter(ai_friends_player.Count);
    }
}
