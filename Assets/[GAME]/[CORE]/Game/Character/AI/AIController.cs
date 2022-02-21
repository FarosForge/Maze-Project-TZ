using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class AIController : ICharacter
{
    private IModel model;
    private IView view;
    private GameManager gameManager;

    public AIController(IView view)
    {
        this.view = view;
        model = new AIModel();
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
        gameManager.AddFriendsToPlayer(this);
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
