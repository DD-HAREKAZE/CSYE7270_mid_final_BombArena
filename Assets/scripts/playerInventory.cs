using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{

    public int RGD5Amount;
    public int molotovAmount;
    public int flashAmount;

    public Text RGD5Amount_UI;
    public Text molotovAmount_UI;
    public Text flashAmount_UI;
    // Start is called before the first frame update
    void Start()
    {
        RGD5Amount = 0;
        molotovAmount = 0;
        flashAmount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RGD5Amount_UI.text = RGD5Amount.ToString();
        molotovAmount_UI.text = molotovAmount.ToString();
        flashAmount_UI.text = flashAmount.ToString();
    }
}
