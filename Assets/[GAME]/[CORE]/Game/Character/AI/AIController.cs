using System;
using UnityEngine;
using AI;

public class AIController : IBot
{
    public Action<IBot> addToPlayerAction { get; set; }

    private IModel model;
    private IView view;
    private GameManager gameManager;

    public AIController(IView view, PLAYER.PlayerView player, Action<float> action)
    {
        this.view = view;
        model = new AIModel(view.components.my_transform, player.transform);

        if(view.components.type == AIType.Enemy)
            model.checkDistance += action;
    }

    public void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;

        switch (view.components.type)
        {
            case AIType.Enemy:
                view.lowDistanceAction += gameManager.Lose;
                break;
            case AIType.Friendly:
                view.lowDistanceAction += AddToPlayer;
                break;
        }
        
    }

    public void Tick()
    {
        view.Move(model.moveDirection(view.components));

        if(model.CheckDistanceToTarget(view.components))
        {
            view.lowDistanceAction?.Invoke();
        }
    }

    public void AddToPlayer()
    {
        addToPlayerAction?.Invoke(this);
        model.followTarget = true;
        Debug.Log("Friend!");

        switch (view.components.type)
        {
            case AIType.Enemy:
                view.lowDistanceAction -= gameManager.Lose;
                break;
            case AIType.Friendly:
                view.lowDistanceAction -= AddToPlayer;
                break;
        }
    }
}
