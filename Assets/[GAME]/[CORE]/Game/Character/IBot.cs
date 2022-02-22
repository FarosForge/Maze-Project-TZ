using System;

public interface IBot : ICharacter
{
    public Action<IBot> addToPlayerAction { get; set; }
}
