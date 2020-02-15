using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public int Coins = 0;
    public int Potions = 0;
    public Text CoinText;
    public Text PotionText;
    public int Damage = 1;

    private void Start()
    {
        CoinText.text = Coins.ToString(); // On s'assure ici que le coin commence bien a 0 sur l'interface utilisateur
                                          //On utilise to string, car envoyer une valeur de type int dans une propriete qui attends une string ne va pas faire bon menage
        PotionText.text = Potions.ToString();
    }

    public void AddCoins()
    {
        Coins += 1;
        CoinText.text = Coins.ToString(); // On s'assure ici que le coin commence bien a 0 sur l'interface utilisateur
                                          //On utilise to string, car envoyer une valeur de type int dans une propriete qui attends une string ne va pas faire bon menage
    }

    public void AddPotions()
    {
        Potions += 1;
        PotionText.text = Potions.ToString();
    }

    public void SubPotions()
    {
        Potions -= 1;
        PotionText.text = Potions.ToString();
    }
}
