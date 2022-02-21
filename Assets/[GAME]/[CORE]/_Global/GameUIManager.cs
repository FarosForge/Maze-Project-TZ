using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameUIContainer uIContainer;

    public void SetFriendsMapCounter(int val)
    {
        uIContainer.FriendsOnMap.text = $"{val}";
    }
    public void SetFriendsPlayerCounter(int val)
    {
        uIContainer.FriendsToPlayer.text = $"{val}";
    }
}
