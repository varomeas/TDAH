using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Liste des Menus")]
    public GameObject mainMenu;
    public GameObject postChild;
    public GameObject end;

    void Start()
    {
        // On désactive tout par défaut pour éviter les superpositions
        mainMenu.SetActive(false);
        postChild.SetActive(false);
        end.SetActive(false);

        // On active le bon menu selon l'état stocké
        switch (GameState.targetMenu)
        {
            case MenuState.Start:
                mainMenu.SetActive(true);
                break;

            case MenuState.PostChild:
                postChild.SetActive(true);
                break;

            case MenuState.End:
                end.SetActive(true);
                break;
        }

        if (GameState.targetMenu == MenuState.PostChild)
        {
            mainMenu.SetActive(false);
            postChild.SetActive(true);

            // ICI : On réinitialise pour casser la boucle
            GameState.targetMenu = MenuState.Start;
        }
        // Optionnel : Réinitialiser à Default pour le prochain lancement
        // GameState.targetMenu = MenuState.Default;
    }
}
