using UnityEngine;
using UnityEngine.UI;

public class GameUIContainer : MonoBehaviour
{
    [SerializeField] private Text friends_on_map;
    [SerializeField] private Text friends_to_player;
    [SerializeField] private Image slider;
    [SerializeField] private GameObject root_slider;

    public Text FriendsOnMap => friends_on_map;
    public Text FriendsToPlayer => friends_to_player;
    public Image GetSlider => slider;
    public GameObject RootSlider => root_slider;
}
