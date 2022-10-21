using UnityEngine;
using UnityEngine.UI;

public class UIStaminaBar : MonoBehaviour
{
    private void Awake(){
        Player.OnStaminaChange += (stamina) => {
            GetComponent<Image>().fillAmount = stamina / 100;
        };
    }
}
