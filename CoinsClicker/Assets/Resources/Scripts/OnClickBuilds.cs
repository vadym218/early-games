using UnityEngine;
using System.Collections;

public class OnClickBuilds : MonoBehaviour {

    public OnClick onclick_script;

	public void OnClickGreenGrocers()
    {
        OnClick.GGQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.GGPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 10;
    }
    public void OnClickFastFood()
    {
        OnClick.FFQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.FFPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 10;
    }
    public void OnClickFitnessClub()
    {
        OnClick.FCQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.FCPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 10;
    }
    public void OnClickJewellers()
    {
        OnClick.JLQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.JLPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 10;
    }
    public void OnClickBank()
    {
        OnClick.BKQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.BKPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 10;
    }
    public void OnClickOffice()
    {
        OnClick.OCQuantity++;
        OnClick.CoinsS = OnClick.CoinsS - OnClick.OCPrice;
        OnClick.AddPerSecondS = OnClick.AddPerSecondS + 9;
    }
}
