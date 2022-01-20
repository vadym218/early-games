using UnityEngine;
using System.Collections;

public class OnClickFinger : MonoBehaviour {

    public OnClick onclick_script;

    public void OnClickGlasses()
    {
        if(OnClick.GSQuantity <= 2)
        {
             OnClick.GSQuantity++;
             OnClick.CoinsS = OnClick.CoinsS - OnClick.GSPrice;
             OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickComputer()
    {
        if (OnClick.CTQuantity <= 2)
        {
            OnClick.CTQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.CTPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickSmartphone()
    {
        if (OnClick.SPQuantity <= 2)
        {
            OnClick.SPQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.SPPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickTablet()
    {
        if (OnClick.TTQuantity <= 2)
        {
            OnClick.TTQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.TTPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickBusinessGuide()
    {
        if (OnClick.BGQuantity <= 2)
        {
            OnClick.BGQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.BGPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickVan()
    {
        if (OnClick.VQuantity <= 2)
        {
            OnClick.VQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.VPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickMini()
    {
        if (OnClick.MNQuantity <= 2)
        {
            OnClick.MNQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.MNPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickJeep()
    {
        if (OnClick.JPQuantity <= 2)
        {
            OnClick.JPQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.JPPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickCar()
    {
        if (OnClick.CQuantity <= 2)
        {
            OnClick.CQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.CPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickPlane()
    {
        if (OnClick.PLQuantity <= 2)
        {
            OnClick.PLQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.PLPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
    public void OnClickYacht()
    {
        if (OnClick.YTQuantity <= 2)
        {
            OnClick.YTQuantity++;
            OnClick.CoinsS = OnClick.CoinsS - OnClick.YTPrice;
            OnClick.AddCoinsS = OnClick.AddCoinsS + 10;
        }
    }
}
