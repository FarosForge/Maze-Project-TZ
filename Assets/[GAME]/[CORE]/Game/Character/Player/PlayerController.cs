using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER;

public class PlayerController : ICharacter
{
    private IModel model;
    private IView view;

    public PlayerController(IView _view)
    {
        model = new PlayerModel();
        view = _view;
    }

    public void Tick()
    {
        view.Move(model.moveDirection(view.components.camera));
        view.Rotate(model.RotatePlayer(view.components.my_transform, view.components.camera));
    }

    public void Init(GameManager _gameManager)
    {

    }
}

