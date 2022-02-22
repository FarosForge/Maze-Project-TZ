using UnityEngine;

public class GameUIManager: IGameController
{
    private readonly GameUIContainer uIContainer;

    private ChaseSlider chaseSlider;

    public GameUIManager(GameUIContainer uIContainer)
    {
        this.uIContainer = uIContainer;
    }

    public ChaseSlider GetChaseSlider => chaseSlider;

    public void Init()
    {
        chaseSlider = new ChaseSlider(uIContainer.GetSlider, 10, uIContainer.RootSlider);
    }

    public void SetFriendsMapCounter(int val)
    {
        uIContainer.FriendsOnMap.text = $"{val}";
    }
    public void SetFriendsPlayerCounter(int val)
    {
        uIContainer.FriendsToPlayer.text = $"{val}";
    }

    public void Tick()
    {
        GetChaseSlider.UpdateSlider();
    }
}
