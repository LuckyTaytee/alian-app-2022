using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public PlayerData player;
    public string saveFile;
    public static SaveManager instance;
    public GameObject butterflyCanvas;
    private Button button;
    private Image picture;


    private void Awake()
    {
        //mengakses path untuk savefile data
        saveFile = Application.persistentDataPath + "/gamedata.json";
        instance = this;
    }

    private void Start()
    {
        //apabila saveFile ada maka player yang merupakan objek dari kelas PlayerData akan diread dari file, readFile() adalah metode untuk membaca file json
        if (File.Exists(saveFile))
        {
            player = ReadFile();
        }
        else
        {
            player = new PlayerData();
        }
        LoadData();
        
    }

    public void LoadData() {
        //code buat load data row1
        if (player.parthenosSylvia)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Parthenos Sylvia").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Parthenos Sylvia").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255,255,255,100);
            button.interactable = true;
        }
        if (player.graphiumAgamemnon)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Graphium Agamemnon").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Graphium Agamemnon").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.euploeaMulciber)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Euploea Mulciber").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Euploea Mulciber").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.hypolimnasBolina)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Hypolimnas Bolina").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 1").Find("Hypolimnas Bolina").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        //code buat load data row2
        if (player.hypolimnasMissipus)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Hypolimnas Misippus").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Hypolimnas Misippus").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.papilioDemoleus)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Papilio Demoleus").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Papilio Demoleus").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.politesPeckius)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Polites Peckius").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Polites Peckius").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.danausChrysippus)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Danaus Chrysippus").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 2").Find("Danaus Chrysippus").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        //data row 3
        if (player.pachlioptaAristolochiae)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Pachliopta Aristolochiae").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Pachliopta Aristolochiae").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.graphiumSarpedon)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Graphium Sarpedon").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Graphium Sarpedon").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.graphiumDoson)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Graphium Doson").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Graphium Doson").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.acraeaTerpsicore)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Acraea Terpiscore").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 3").Find("Acraea Terpiscore").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        //data row 4
        if (player.doleschalliaBisaltide)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 4").Find("Doleschallia Bisaltide").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 4").Find("Doleschallia Bisaltide").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.papilioMemnon)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 4").Find("Papilio Memnon").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 4").Find("Papilio Memnon").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        //data row 5
        if (player.troidesHelena)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Troides Helena").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Troides Helena").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.losariaCoon)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Losaria Coon").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Losaria Coon").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.papilioHelenus)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Papilio Helenus").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Papilio Helenus").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }
        if (player.attacusAtlas)
        {
            button = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Attacus Atlas").Find("Button").GetComponent<Button>();
            picture = butterflyCanvas.transform.Find("Scroll Area").Find("Content").Find("Row 5").Find("Attacus Atlas").Find("Gambar").GetComponent<Image>();
            picture.color = new Color(255, 255, 255, 100);
            button.interactable = true;
        }

    }

    //metode membaca file Json
    public PlayerData ReadFile()
    {
        string fileContents = File.ReadAllText(saveFile);
        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }


}
