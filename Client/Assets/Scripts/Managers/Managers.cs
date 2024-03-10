using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static bool Initialized { get; set; }

    static Managers s_instance;
    static public Managers Instance { get { Init(); return s_instance; } }

    public static bool InitComplete = false;

    #region Contents
    private GameManagerEX _gameMng = new GameManagerEX();
    private ObjectManager _objectMng = new ObjectManager();

    public static GameManagerEX GameMng { get { return Instance._gameMng; } }
    public static ObjectManager ObjectMng => Instance._objectMng;
    #endregion

    #region Core
    private DataManager _dataMng = new DataManager();
    private InputManager _inputMng = new InputManager();
    private PoolManager _poolMng = new PoolManager();
    private ResourceManager _resourceMng = new ResourceManager();
    private SceneManagerEx _sceneMng = new SceneManagerEx();
    private SoundManager _soundMng = new SoundManager();
    private UIManager _uiMng = new UIManager();
    private MapManager _mapMng = new MapManager();
    private NetworkManager _networkMng;

    public static DataManager DataMng => Instance._dataMng;
    public static InputManager InputMng => Instance._inputMng;
    public static PoolManager PoolMng => Instance._poolMng;
    public static ResourceManager ResourceMng => Instance._resourceMng;
    public static SceneManagerEx SceneMng => Instance._sceneMng;
    public static SoundManager SoundMng => Instance._soundMng;
    public static UIManager UIMng => Instance._uiMng;
    public static NetworkManager NetworkMng => Instance._networkMng;
    public static MapManager MapMng => Instance._mapMng;
    #endregion

    static void Init()
    {
        if (s_instance == null || Initialized == false)
        {
            Initialized = true;

            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
            s_instance._networkMng = go.GetComponent<NetworkManager>();

            NetworkMng.Init();
            InputMng.Init();
            DataMng.Init();
            SoundMng.Init();
            PoolMng.Init();
            ObjectMng.Init();
        }
    }

    public static void Clear()
    {
        GameMng.Clear();
        SoundMng.Clear();
        InputMng.Clear();
        SceneMng.Clear();
        UIMng.Clear();
        PoolMng.Clear();
    }
}
