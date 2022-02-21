using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIContainer : MonoBehaviour
{
    [SerializeField] private Text friends_on_map;
    [SerializeField] private Text friends_to_player;
    [SerializeField] private Image slider;

    public Text FriendsOnMap { get { return friends_on_map; } }
    public Text FriendsToPlayer { get { return friends_to_player; } }
}
