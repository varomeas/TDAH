using UnityEngine;

public enum MenuState
{
    Start,      // Le menu de base
    PostChild,   // Après le combat/l'action
    End,     // Si on a perdu
          
}

public static class GameState
{
    // On stocke l'état actuel ici
    public static MenuState targetMenu = MenuState.Start;
}
