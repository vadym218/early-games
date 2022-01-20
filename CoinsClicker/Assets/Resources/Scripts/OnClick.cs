using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

    //GreenGrocers
    public Button GreenGrocers;
    public Image GrnGro;
    public static int GGQuantity;
    public static int GGPrice;
    [SerializeField]
    private Text GGQ = null;
    [SerializeField]
    private Text GGP = null;
    [SerializeField]
    private Text GGI = null;
    //FastFood
    public Button FastFood;
    public Image FstFd;
    public static int FFQuantity;
    public static int FFPrice;
    [SerializeField]
    private Text FFQ = null;
    [SerializeField]
    private Text FFP = null;
    [SerializeField]
    private Text FFI = null;
    //FitnessClub
    public Button FitnessClub;
    public Image FtnClb;
    public static int FCQuantity;
    public static int FCPrice;
    [SerializeField]
    private Text FCQ = null;
    [SerializeField]
    private Text FCP = null;
    [SerializeField]
    private Text FCI = null;
    //Jewellers
    public Button Jewellers;
    public Image JewLrs;
    public static int JLQuantity;
    public static int JLPrice;
    [SerializeField]
    private Text JLQ = null;
    [SerializeField]
    private Text JLP = null;
    [SerializeField]
    private Text JLI = null;
    //Bank
    public Button Bank;
    public Image Bnk;
    public static int BKQuantity;
    public static int BKPrice;
    [SerializeField]
    private Text BKQ = null;
    [SerializeField]
    private Text BKP = null;
    [SerializeField]
    private Text BKI = null;
    //Office
    public Image Ofic;
    public Button Office;
    public static int OCQuantity;
    public static int OCPrice;
    [SerializeField]
    private Text OCQ = null;
    [SerializeField]
    private Text OCP = null;
    [SerializeField]
    private Text OCI = null;



    //Glasses
    public Image Gls;
    public Button Glasses;
    public static int GSQuantity;
    public static int GSPrice;
    [SerializeField]
    private Text GSQ = null;
    [SerializeField]
    private Text GSP = null;
    [SerializeField]
    private Text GSI = null;
    //Computer
    public Image Cmp;
    public Button Computer;
    public static int CTQuantity;
    public static int CTPrice;
    [SerializeField]
    private Text CTQ = null;
    [SerializeField]
    private Text CTP = null;
    [SerializeField]
    private Text CTI = null;
    //Smartphone
    public Image Smf;
    public Button Smartphone;
    public static int SPQuantity;
    public static int SPPrice;
    [SerializeField]
    private Text SPQ = null;
    [SerializeField]
    private Text SPP = null;
    [SerializeField]
    private Text SPI = null;
    //Tablet
    public Image Tbt;
    public Button Tablet;
    public static int TTQuantity;
    public static int TTPrice;
    [SerializeField]
    private Text TTQ = null;
    [SerializeField]
    private Text TTP = null;
    [SerializeField]
    private Text TTI = null;
    //BusinessGuide
    public Image Bsg;
    public Button BusinessGuide;
    public static int BGQuantity;
    public static int BGPrice;
    [SerializeField]
    private Text BGQ = null;
    [SerializeField]
    private Text BGP = null;
    [SerializeField]
    private Text BGI = null;
    //Van
    public Image Vn;
    public Button Van;
    public static int VQuantity;
    public static int VPrice;
    [SerializeField]
    private Text VQ = null;
    [SerializeField]
    private Text VP = null;
    [SerializeField]
    private Text VI = null;
    //Mini
    public Image Mi;
    public Button Mini;
    public static int MNQuantity;
    public static int MNPrice;
    [SerializeField]
    private Text MNQ = null;
    [SerializeField]
    private Text MNP = null;
    [SerializeField]
    private Text MNI = null;
    //Jeep
    public Image Jip;
    public Button Jeep;
    public static int JPQuantity;
    public static int JPPrice;
    [SerializeField]
    private Text JPQ = null;
    [SerializeField]
    private Text JPP = null;
    [SerializeField]
    private Text JPI = null;
    //Car
    public Image Cr;
    public Button Car;
    public static int CQuantity;
    public static int CPrice;
    [SerializeField]
    private Text CQ = null;
    [SerializeField]
    private Text CP = null;
    [SerializeField]
    private Text CI = null;
    //Plane
    public Image Pln;
    public Button Plane;
    public static int PLQuantity;
    public static int PLPrice;
    [SerializeField]
    private Text PLQ = null;
    [SerializeField]
    private Text PLP = null;
    [SerializeField]
    private Text PLI = null;
    //Yacht
    public Image Ycht;
    public Button Yacht;
    public static int YTQuantity;
    public static int YTPrice;
    [SerializeField]
    private Text YTQ = null;
    [SerializeField]
    private Text YTP = null;
    [SerializeField]
    private Text YTI = null;


    //Upgrade
    private int FFUP = 500;
    public Button FFUPB;
    private bool FFisB = false;
    private int FFQBB;

    private int FCUP = 500;
    public Button FCBUPB;
    public Button FCDUPB;
    private bool FCBisB = false;
    private bool FCDisB = false;
    private int FCDQBB;
    private int FCBQBB;


    [SerializeField]
    private Text Coins = null;
    public static int CoinsS;
    public int AddCoins;
    public static int AddCoinsS = 1;
    public float time0;
    public float time1;
    public int AddPerSecond;
    public static int AddPerSecondS;
    public GameObject PerSecond;
    public GameObject PerClick;
    public GameObject Main;
    public GameObject Upgrade;
    public GameObject Options;


    void Start()
    {
        Main.SetActive(true);
        PerSecond.SetActive(false);
        PerClick.SetActive(false);
        Upgrade.SetActive(false);
        Options.SetActive(false);
        time1 = time0;
    }

    void Update()
    {
        Coins.text = "" + CoinsS;
        //GreenGrocers
        if (GGQuantity >= 2)
        {
            GGPrice = 30 * GGQuantity;
        }
        else
        {
            if(GGQuantity >= 1)
            {
                GGPrice = 45;
            }
            else
            {
                GGPrice = 30;
            }
        }       
        if(CoinsS >= GGPrice)
        {
            GreenGrocers.interactable=true;
        }
        else
        {
            GreenGrocers.interactable = false;
        }
        GGQ.text = GGQuantity + "x";
        GGP.text = "" + GGPrice;
        //FastFood
        if (FFQuantity >= 2)
        {
            FFPrice = 30 * FFQuantity;
        }
        else
        {
            if (FFQuantity >= 1)
            {
                FFPrice = 45;
            }
            else
            {
                FFPrice = 30;
            }
        }
        if (CoinsS >= FFPrice)
        {
            FastFood.interactable = true;
        }
        else
        {
            FastFood.interactable = false;
        }
        FFQ.text = FFQuantity + "x";
        FFP.text = "" + FFPrice;
        //FitnessClub
        if (FCQuantity >= 2)
        {
            FCPrice = 30 * FCQuantity;
        }
        else
        {
            if (FCQuantity >= 1)
            {
                FCPrice = 45;
            }
            else
            {
                FCPrice = 30;
            }
        }
        if (CoinsS >= FCPrice)
        {
            FitnessClub.interactable = true;
        }
        else
        {
            FitnessClub.interactable = false;
        }
        FCQ.text = FCQuantity + "x";
        FCP.text = "" + FCPrice;
        //Jewellers
        if (JLQuantity >= 2)
        {
            JLPrice = 30 * JLQuantity;
        }
        else
        {
            if (JLQuantity >= 1)
            {
                JLPrice = 45;
            }
            else
            {
                JLPrice = 30;
            }
        }
        if (CoinsS >= JLPrice)
        {
            Jewellers.interactable = true;
        }
        else
        {
            Jewellers.interactable = false;
        }
        JLQ.text = JLQuantity + "x";
        JLP.text = "" + JLPrice;
        //Bank
        if (BKQuantity >= 2)
        {
            BKPrice = 30 * BKQuantity;
        }
        else
        {
            if (BKQuantity >= 1)
            {
                BKPrice = 45;
            }
            else
            {
                BKPrice = 30;
            }
        }
        if (CoinsS >= BKPrice)
        {
            Bank.interactable = true;
        }
        else
        {
            Bank.interactable = false;
        }
        BKQ.text = BKQuantity + "x";
        BKP.text = "" + BKPrice;
        //Office
        if (OCQuantity >= 2)
        {
            OCPrice = 30 * OCQuantity;
        }
        else
        {
            if (OCQuantity >= 1)
            {
                OCPrice = 45;
            }
            else
            {
                OCPrice = 30;
            }
        }
        if (CoinsS >= OCPrice)
        {
            Office.interactable = true;
        }
        else
        {
            Office.interactable = false;
        }
        OCQ.text = OCQuantity + "x";
        OCP.text = "" + OCPrice;


        //Glasses
        if (GSQuantity == 3)
        {
            GSP.text = "MAX";
        }
        if (GSQuantity == 2)
        {
            GSPrice = 300;
        }
        if (GSQuantity == 1)
        {
            GSPrice = 200;
        }
        if (GSQuantity == 0)
        {
            GSPrice = 100;
        }
        if (CoinsS >= GSPrice)
        {
            Glasses.interactable = true;
        }
        else
        {
            Glasses.interactable = false;
        }
        GSQ.text = GSQuantity + "x";
        if (GSQuantity < 3)
        {
            GSP.text = "" + GSPrice;
        }
        //Computer
        if (CTQuantity == 3)
        {
            CTP.text = "MAX";
        }
        if (CTQuantity == 2)
        {
            CTPrice = 300;
        }
        if (CTQuantity == 1)
        {
            CTPrice = 200;
        }
        if (CTQuantity == 0)
        {
            CTPrice = 100;
        }
        if (CoinsS >= CTPrice)
        {
            Computer.interactable = true;
        }
        else
        {
            Computer.interactable = false;
        }
        CTQ.text = CTQuantity + "x";
        if (CTQuantity < 3)
        {
            CTP.text = "" + CTPrice;
        }
        //Smartphone
        if (SPQuantity == 3)
        {
            SPP.text = "MAX";
        }
        if (SPQuantity == 2)
        {
            SPPrice = 300;
        }
        if (SPQuantity == 1)
        {
            SPPrice = 200;
        }
        if (SPQuantity == 0)
        {
            SPPrice = 100;
        }
        if (CoinsS >= SPPrice)
        {
            Smartphone.interactable = true;
        }
        else
        {
            Smartphone.interactable = false;
        }
        SPQ.text = SPQuantity + "x";
        if (SPQuantity < 3)
        {
            SPP.text = "" + SPPrice;
        }
        //Tablet
        if (TTQuantity == 3)
        {
            TTP.text = "MAX";
        }
        if (TTQuantity == 2)
        {
            TTPrice = 300;
        }
        if (TTQuantity == 1)
        {
            TTPrice = 200;
        }
        if (TTQuantity == 0)
        {
            TTPrice = 100;
        }
        if (CoinsS >= TTPrice)
        {
            Tablet.interactable = true;
        }
        else
        {
            Tablet.interactable = false;
        }
        if (TTQuantity < 3)
        {
            TTP.text = "" + TTPrice;
        }
        TTQ.text = TTQuantity + "x";
        //BusinessGuide
        if (BGQuantity == 3)
        {
            BGP.text = "MAX";
        }
        if (BGQuantity == 2)
        {
            BGPrice = 300;
        }
        if (BGQuantity == 1)
        {
            BGPrice = 200;
        }
        if (BGQuantity == 0)
        {
            BGPrice = 100;
        }
        if (CoinsS >= BGPrice)
        {
            BusinessGuide.interactable = true;
        }
        else
        {
            BusinessGuide.interactable = false;
        }
        if (BGQuantity < 3)
        {
            BGP.text = "" + BGPrice;
        }
        BGQ.text = BGQuantity + "x";
        //Van
        if (VQuantity == 3)
        {
            VP.text = "MAX";
        }
        if (VQuantity == 2)
        {
            VPrice = 300;
        }
        if (VQuantity == 1)
        {
            VPrice = 200;
        }
        if (VQuantity == 0)
        {
            VPrice = 100;
        }
        if (CoinsS >= VPrice)
        {
            Van.interactable = true;
        }
        else
        {
            Van.interactable = false;
        }
        if (VQuantity < 3)
        {
            VP.text = "" + VPrice;
        }
        VQ.text = VQuantity + "x";
        //Mini
        if (MNQuantity == 3)
        {
            MNP.text = "MAX";
        }
        if (MNQuantity == 2)
        {
            MNPrice = 300;
        }
        if (MNQuantity == 1)
        {
            MNPrice = 200;
        }
        if (MNQuantity == 0)
        {
            MNPrice = 100;
        }
        if (CoinsS >= MNPrice)
        {
            Mini.interactable = true;
        }
        else
        {
            Mini.interactable = false;
        }
        if (MNQuantity < 3)
        {
            MNP.text = "" + MNPrice;
        }
        MNQ.text = MNQuantity + "x";
        //Jeep
        if (JPQuantity == 3)
        {
            JPP.text = "MAX";
        }
        if (JPQuantity == 2)
        {
            JPPrice = 300;
        }
        if (JPQuantity == 1)
        {
            JPPrice = 200;
        }
        if (JPQuantity == 0)
        {
            JPPrice = 100;
        }
        if (CoinsS >= JPPrice)
        {
            Jeep.interactable = true;
        }
        else
        {
            Jeep.interactable = false;
        }
        if (JPQuantity < 3)
        {
            JPP.text = "" + JPPrice;
        }
        JPQ.text = JPQuantity + "x";
        //Car
        if (CQuantity == 3)
        {
            CP.text = "MAX";
        }
        if (CQuantity == 2)
        {
            CPrice = 300;
        }
        if (CQuantity == 1)
        {
            CPrice = 200;
        }
        if (CQuantity == 0)
        {
            CPrice = 100;
        }
        if (CoinsS >= CPrice)
        {
             Car.interactable = true;
        }
        else
        {
            Car.interactable = false;
        }
        if (CQuantity < 3)
        {
            CP.text = "" + CPrice;
        }
        CQ.text = CQuantity + "x";
        //Plane
        if (PLQuantity == 3)
        {
            PLP.text = "MAX";
        }
        if (PLQuantity == 2)
        {
            PLPrice = 300;
        }
        if (PLQuantity == 1)
        {
            PLPrice = 200;
        }
        if (PLQuantity == 0)
        {
            PLPrice = 100;
        }
        if (CoinsS >= PLPrice)
        {
            Plane.interactable = true;
        }
        else
        {
            Plane.interactable = false;
        }
        if (PLQuantity < 3)
        {
            PLP.text = "" + PLPrice;
        }
        PLQ.text = PLQuantity + "x";
        //Yacht
        if (YTQuantity == 3)
        {
            YTP.text = "MAX";
        }
        if (YTQuantity == 2)
        {
            YTPrice = 300;
        }
        if (YTQuantity == 1)
        {
            YTPrice = 200;
        }
        if (YTQuantity == 0)
        {
            YTPrice = 100;
        }
        if (CoinsS >= YTPrice)
        {
            Yacht.interactable = true;
        }
        else
        {
            Yacht.interactable = false;
        }
        if(YTQuantity < 3)
        {
            YTP.text = "" + YTPrice;
        }
            YTQ.text = YTQuantity + "x";

        if (FFisB == true)
        {
            AddPerSecondS = AddPerSecondS + ((FFQuantity - FFQBB) * 10);
            FFQBB = FFQuantity;
        }

        if (FCDisB == true)
        {
            AddPerSecondS = AddPerSecondS + ((FCQuantity - FCDQBB) * 10);
            FCDQBB = FCQuantity;
        }

        if (FCBisB == true)
        {
            AddPerSecondS = AddPerSecondS + ((FCQuantity - FCBQBB) * 10);
            FCBQBB = FCQuantity;
        }

        AddPerSecond = AddPerSecondS;
        AddCoins = AddCoinsS;
        if (Input.GetKeyDown(KeyCode.Escape) &&  Main.activeSelf == false)
        {
            Main.SetActive(true);
            PerSecond.SetActive(false);
            PerClick.SetActive(false);
            Upgrade.SetActive(false);
            Options.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Main.activeSelf == true)
        {
            Application.Quit();
        }
        if (time1 > 0)
        {
            time1 -= Time.deltaTime;
        }
        if (time1 < 0)
        {
            CoinsS = CoinsS + AddPerSecond;
            Coins.text = "" + CoinsS;
            time1 = time0;
        }
    }

    public void OnClickFFU()
    {
        if(CoinsS >= FFUP)
        {
            CoinsS = CoinsS - FFUP;
            AddPerSecondS = AddPerSecondS + (FFQuantity * 10);
            FFUPB.interactable = false;
            FFQBB = FFQuantity;
            FFisB = true;
        }
    }
    public void OnClickFCUD()
    {
        if (CoinsS >= FCUP)
        {
            CoinsS = CoinsS - FCUP;
            AddPerSecondS = AddPerSecondS + (FCQuantity * 10);
            FCDUPB.interactable = false;
            FCDQBB = FCQuantity;
            FCDisB = true;
        }
    }
    public void OnClickFCUB()
    {
        if (CoinsS >= FCUP)
        {
            CoinsS = CoinsS - FCUP;
            AddPerSecondS = AddPerSecondS + (FCQuantity * 10);
            FCBUPB.interactable = false;
            FCBQBB = FCQuantity;
            FCBisB = true;
        }
    }
    public void OnClickCoin()
    {
        CoinsS = CoinsS + AddCoins;
        Coins.text = "" + CoinsS;
    }

    public void OnClickFinger()
    {
        Upgrade.SetActive(false);
        Main.SetActive(false);
        PerSecond.SetActive(false);
        PerClick.SetActive(true);
        Options.SetActive(false);
    }

    public void OnClickTimer()
    {
        Upgrade.SetActive(false);
        Main.SetActive(false);
        PerSecond.SetActive(true);
        PerClick.SetActive(false);
        Options.SetActive(false);
    }
    public void OnClickUpgrade()
    {
        Upgrade.SetActive(true);
        Main.SetActive(false);
        PerSecond.SetActive(false);
        PerClick.SetActive(false);
        Options.SetActive(false);
    }
    public void OnClickOptions()
    {
        Upgrade.SetActive(false);
        Main.SetActive(false);
        PerSecond.SetActive(false);
        PerClick.SetActive(false);
        Options.SetActive(true);
    }
    public void OnClickLight()
    {
        GGQ.color = Color.black;
        FFQ.color = Color.black;
        JLQ.color = Color.black;
        BKQ.color = Color.black;
        OCQ.color = Color.black;
        GSQ.color = Color.black;
        CTQ.color = Color.black;
        SPQ.color = Color.black;
        TTQ.color = Color.black;
        BGQ.color = Color.black;
        VQ.color = Color.black;
        MNQ.color = Color.black;
        JPQ.color = Color.black;
        CQ.color = Color.black;
        PLQ.color = Color.black;
        YTQ.color = Color.black;
        GGI.color = Color.black;
        FFI.color = Color.black;
        JLI.color = Color.black;
        BKI.color = Color.black;
        OCI.color = Color.black;
        GSI.color = Color.black;
        CTI.color = Color.black;
        SPI.color = Color.black;
        TTI.color = Color.black;
        BGI.color = Color.black;
        VI.color = Color.black;
        MNI.color = Color.black;
        JPI.color = Color.black;
        CI.color = Color.black;
        PLI.color = Color.black;
        YTI.color = Color.black;
        Options.SetActive(false);
        Main.SetActive(true);
    }
    public void OnClickBlue()
    {
        GrnGro.sprite = Resources.Load<Sprite>("Sprites/Greengrocer'sB") as Sprite;
        FstFd.sprite = Resources.Load<Sprite>("Sprites/FastFoodB") as Sprite;
        FtnClb.sprite = Resources.Load<Sprite>("Sprites/FitnessClubB") as Sprite;
        JewLrs.sprite = Resources.Load<Sprite>("Sprites/Jeweller'sB") as Sprite;
        Bnk.sprite = Resources.Load<Sprite>("Sprites/BankB") as Sprite;
        Ofic.sprite = Resources.Load<Sprite>("Sprites/OfficeB") as Sprite;
        Gls.sprite = Resources.Load<Sprite>("Sprites/GlassesB") as Sprite;
        Cmp.sprite = Resources.Load<Sprite>("Sprites/ComputerB") as Sprite;
        Smf.sprite = Resources.Load<Sprite>("Sprites/SmartphoneB") as Sprite;
        Tbt.sprite = Resources.Load<Sprite>("Sprites/TabletB") as Sprite;
        Bsg.sprite = Resources.Load<Sprite>("Sprites/BussinessGuideB") as Sprite;
        Vn.sprite = Resources.Load<Sprite>("Sprites/VanB") as Sprite;
        Mi.sprite = Resources.Load<Sprite>("Sprites/MiniB") as Sprite;
        Jip.sprite = Resources.Load<Sprite>("Sprites/JeepB") as Sprite;
        Cr.sprite = Resources.Load<Sprite>("Sprites/CarB.") as Sprite;
        Pln.sprite = Resources.Load<Sprite>("Sprites/PlaneB") as Sprite;
        Ycht.sprite = Resources.Load<Sprite>("Sprites/YachtB") as Sprite;
        GGQ.color = Color.white;
        FFQ.color = Color.white;
        FCQ.color = Color.white;
        JLQ.color = Color.white;
        BKQ.color = Color.white;
        OCQ.color = Color.white;
        GSQ.color = Color.white;
        CTQ.color = Color.white;
        SPQ.color = Color.white;
        TTQ.color = Color.white;
        BGQ.color = Color.white;
        VQ.color = Color.white;
        MNQ.color = Color.white;
        JPQ.color = Color.white;
        CQ.color = Color.white;
        PLQ.color = Color.white;
        YTQ.color = Color.white;
        GGI.color = Color.white;
        FFI.color = Color.white;
        FCI.color = Color.white;
        JLI.color = Color.white;
        BKI.color = Color.white;
        OCI.color = Color.white;
        GSI.color = Color.white;
        CTI.color = Color.white;
        SPI.color = Color.white;
        TTI.color = Color.white;
        BGI.color = Color.white;
        VI.color = Color.white;
        MNI.color = Color.white;
        JPI.color = Color.white;
        CI.color = Color.white;
        PLI.color = Color.white;
        YTI.color = Color.white;
        Options.SetActive(false);
        Main.SetActive(true);
    }
    public void OnClickDark()
    {
        GrnGro.sprite = Resources.Load<Sprite>("Sprites/Greengrocer's") as Sprite;
        FstFd.sprite = Resources.Load<Sprite>("Sprites/FastFood") as Sprite;
        FtnClb.sprite = Resources.Load<Sprite>("Sprites/FitnessClub") as Sprite;
        JewLrs.sprite = Resources.Load<Sprite>("Sprites/Jeweller's") as Sprite;
        Bnk.sprite = Resources.Load<Sprite>("Sprites/Bank") as Sprite;
        Ofic.sprite = Resources.Load<Sprite>("Sprites/Office") as Sprite;
        Gls.sprite = Resources.Load<Sprite>("Sprites/Glasses") as Sprite;
        Cmp.sprite = Resources.Load<Sprite>("Sprites/Computer") as Sprite;
        Smf.sprite = Resources.Load<Sprite>("Sprites/Smartphone") as Sprite;
        Tbt.sprite = Resources.Load<Sprite>("Sprites/Tablet") as Sprite;
        Bsg.sprite = Resources.Load<Sprite>("Sprites/BussinessGuide") as Sprite;
        Vn.sprite = Resources.Load<Sprite>("Sprites/Van") as Sprite;
        Mi.sprite = Resources.Load<Sprite>("Sprites/Mini") as Sprite;
        Jip.sprite = Resources.Load<Sprite>("Sprites/Jeep") as Sprite;
        Cr.sprite = Resources.Load<Sprite>("Sprites/Car.") as Sprite;
        Pln.sprite = Resources.Load<Sprite>("Sprites/Plane") as Sprite;
        Ycht.sprite = Resources.Load<Sprite>("Sprites/Yacht") as Sprite;
        GGQ.color = Color.white;
        FFQ.color = Color.white;
        FCQ.color = Color.white;
        JLQ.color = Color.white;
        BKQ.color = Color.white;
        OCQ.color = Color.white;
        GSQ.color = Color.white;
        CTQ.color = Color.white;
        SPQ.color = Color.white;
        TTQ.color = Color.white;
        BGQ.color = Color.white;
        VQ.color = Color.white;
        MNQ.color = Color.white;
        JPQ.color = Color.white;
        CQ.color = Color.white;
        PLQ.color = Color.white;
        YTQ.color = Color.white;
        GGI.color = Color.white;
        FFI.color = Color.white;
        FCI.color = Color.white;
        JLI.color = Color.white;
        BKI.color = Color.white;
        OCI.color = Color.white;
        GSI.color = Color.white;
        CTI.color = Color.white;
        SPI.color = Color.white;
        TTI.color = Color.white;
        BGI.color = Color.white;
        VI.color = Color.white;
        MNI.color = Color.white;
        JPI.color = Color.white;
        CI.color = Color.white;
        PLI.color = Color.white;
        YTI.color = Color.white;
        Options.SetActive(false);
        Main.SetActive(true);
    }
}

