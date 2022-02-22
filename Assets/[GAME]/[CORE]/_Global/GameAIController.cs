using System;
using System.Collections.Generic;
using UnityEngine;

public class GameAIController : IGameController
{
    public Action<int> updateFriendsUI;
    public Action<int> updatePlayerFriendsUI;

    private readonly GameContainer gameContainer;
    private readonly GameManager gameManager;
    private readonly GameUIManager ui;

    private List<IBot> ai_enemy = new List<IBot>();
    private List<IBot> ai_friends = new List<IBot>();
    private List<IBot> ai_friends_player = new List<IBot>();

    public GameAIController(GameContainer gameContainer, GameManager gameManager, 
        Action<int> updateUIAction, Action<int> updatePlayerFUI, GameUIManager _ui)
    {
        this.gameContainer = gameContainer;
        this.gameManager = gameManager;
        ui = _ui;
        updateFriendsUI += updateUIAction;
        updatePlayerFriendsUI += updatePlayerFUI;
    }

    public void Init()
    {
        for (int i = 0; i < gameContainer.AIViewsEnemy.Length; i++)
        {
            var mob = new AIController(gameContainer.AIViewsEnemy[i], gameContainer.GetPlayerView, ui.GetChaseSlider.SetValue);
            mob.Init(gameManager);
            ai_enemy.Add(mob);
        }

        for (int i = 0; i < gameContainer.AIViewsFriends.Length; i++)
        {
            var mob = new AIController(gameContainer.AIViewsFriends[i], gameContainer.GetPlayerView, ui.GetChaseSlider.SetValue);
            mob.addToPlayerAction += AddFriendsToPlayer;
            mob.Init(gameManager);
            ai_friends.Add(mob);
        }

        updateFriendsUI?.Invoke(ai_friends.Count);
        updatePlayerFriendsUI?.Invoke(ai_friends_player.Count);
    }

    public void Tick()
    {
        foreach (var mob in ai_enemy)
        {
            mob.Tick();
        }

        foreach (var mob in ai_friends)
        {
            mob.Tick();
        }
    }

    public void AddFriendsToPlayer(IBot character)
    {
        ai_friends_player.Add(character);
        character.addToPlayerAction -= AddFriendsToPlayer;
        updatePlayerFriendsUI?.Invoke(ai_friends_player.Count);
    }
}
