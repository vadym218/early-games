using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Settings : MonoBehaviour
{

    public Dropdown resolutiondd, texture, aa, preset;
    public Toggle fullscreen;
    public Resolution[] resolutions;
    private bool fullscreenb = true,antia,tex;
    public QualitySave gamesettings;
    public Slider sens;
    public Text sensvalue;
    private float sen;

    void OnEnable()
    {
        gamesettings = new QualitySave();
        fullscreen.onValueChanged.AddListener(delegate { OnFullScreenChanged(); });
        texture.onValueChanged.AddListener(delegate { OnTextureChanged(); });
        resolutiondd.onValueChanged.AddListener(delegate { OnResolutionChanged(); });
        aa.onValueChanged.AddListener(delegate { OnAAChanged(); });
        preset.onValueChanged.AddListener(delegate { OnPresetChanged(); });
        sens.onValueChanged.AddListener(delegate { OnSensivityChange(); });
        sen = (int)sens.value;
        sensvalue.text = sen.ToString();
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutiondd.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadQuality();
    }

    void OnFullScreenChanged()
    {
        Screen.fullScreen = gamesettings.fullscreen = fullscreen.isOn;
        fullscreenb = fullscreen.isOn;
    }

    void OnTextureChanged()
    {
        if (tex == false)
        {
            preset.value = 5;
        }
        if (texture.value == 0) QualitySettings.masterTextureLimit = 0;
        if (texture.value == 1) QualitySettings.masterTextureLimit = 0;
        if (texture.value == 2) QualitySettings.masterTextureLimit = 1;
        if (texture.value == 3) QualitySettings.masterTextureLimit = 2;
        if (texture.value == 4) QualitySettings.masterTextureLimit = 3;
        gamesettings.texture = texture.value;
    }

    void OnAAChanged()
    {
        if (antia == false)
        {
            preset.value = 5;
        }
        if (aa.value == 0) QualitySettings.antiAliasing = 0;
        if (aa.value == 1) QualitySettings.antiAliasing = 0;
        if (aa.value == 2) QualitySettings.antiAliasing = 2;
        if (aa.value == 3) QualitySettings.antiAliasing = 4;
        if (aa.value == 4) QualitySettings.antiAliasing = 8;
        gamesettings.aa = aa.value;
    }
    void OnResolutionChanged()
    {
        if (resolutiondd.value == 0) Screen.SetResolution(1280, 720, fullscreenb);
        else Screen.SetResolution(resolutions[resolutiondd.value].width, resolutions[resolutiondd.value].height, fullscreenb);
        gamesettings.resind = resolutiondd.value;
    }
    void OnPresetChanged()
    {
            tex = true;
            antia = true;

        if (preset.value == 0)
        {
            QualitySettings.SetQualityLevel(3);
            aa.value = 2;
            texture.value = 1;
            preset.value = 1;
            antia = false;
            tex = false;
        }
        if (preset.value == 1)
        {
            QualitySettings.SetQualityLevel(3);
            aa.value = 2;
            texture.value = 1;
            antia = false;
            tex = false;
        } 
        if (preset.value == 2)
        {
            QualitySettings.SetQualityLevel(2);
            aa.value = 1;
            texture.value = 2;
            antia = false;
            tex = false;
        }
        if (preset.value == 3)
        {
            QualitySettings.SetQualityLevel(1);
            aa.value = 1;
            texture.value = 3;
            antia = false;
            tex = false;
        }
        if (preset.value == 4)
        {
            QualitySettings.SetQualityLevel(0);
            aa.value = 1;
            texture.value = 4;
            antia = false;
            tex = false;
        }
        if (preset.value == 5)
        {
            QualitySettings.SetQualityLevel(4);

            if (aa.value == 0) QualitySettings.antiAliasing = 0;
            if (aa.value == 1) QualitySettings.antiAliasing = 0;
            if (aa.value == 2) QualitySettings.antiAliasing = 2;
            if (aa.value == 3) QualitySettings.antiAliasing = 4;
            if (aa.value == 4) QualitySettings.antiAliasing = 8;

            if (texture.value == 0) QualitySettings.masterTextureLimit = 0;
            if (texture.value == 1) QualitySettings.masterTextureLimit = 0;
            if (texture.value == 2) QualitySettings.masterTextureLimit = 1;
            if (texture.value == 3) QualitySettings.masterTextureLimit = 2;
            if (texture.value == 4) QualitySettings.masterTextureLimit = 3;

            antia = false;
            tex = false;
        }
        gamesettings.preset = preset.value;
    }
    public void SaveQuality()
    {
        string jsonData = JsonUtility.ToJson(gamesettings, true);
        File.WriteAllText(Application.persistentDataPath + "/QualitySave.json", jsonData);
    }
    void LoadQuality()
    {
        gamesettings = JsonUtility.FromJson<QualitySave>(File.ReadAllText(Application.persistentDataPath + "/QualitySave.json"));

        if (gamesettings.preset == 5)
        {
            aa.value = gamesettings.aa;
            texture.value = gamesettings.texture;
        }
        preset.value = gamesettings.preset;
        resolutiondd.value = gamesettings.resind;
        fullscreen.isOn = gamesettings.fullscreen;
        sens.value = gamesettings.sensivity;
        sen = (int)sens.value;
        sensvalue.text = sen.ToString();

        Screen.fullScreen = gamesettings.fullscreen = fullscreen.isOn;
    }

    void OnSensivityChange()
    {
        CharacterControl.sensivitys = sens.value;
        gamesettings.sensivity = sens.value;
        sen = (int)sens.value;
        sensvalue.text = sen.ToString();
    }
}
