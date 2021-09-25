using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable 
{   //외부에서 싱글톤 오브젝트 땡길때 사용할 프로퍼티
    public static GameManager instance
    {
        get
        {
            if (m_instance == null) //싱글톤 == null
                m_instance = FindObjectOfType<GameManager>(); //씬에서 GameManager오브젝트 찾아 할당
            return m_instance; //싱글톤 오브젝트 반환
        }

        
    }

    public static GameManager buildInstance = null; //보드 생성 변수
    private static GameManager m_instance; //싱글톤 할당 변수
    BoardManager boardScript;
    public GameObject playerPrefab; // 캐릭터 프리팹
    public GameObject playerInstance;

    private int score = 0; //현재 게임 점수
    public bool isGameover { get; private set; } //게임 오버 상태

    //주기적 자동 실행 동기화 메서드
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //로컬이면 쓰기, 리모트면 읽기
        if (stream.IsWriting) stream.SendNext(score);
        else
        {
            score = (int)stream.ReceiveNext();
            //UIManager.instance.UpdateScoreText(score);
        }
    }

    private void Awake()
    {
        if (buildInstance == null)
            buildInstance = this;
        else if (buildInstance != this)
            Destroy(gameObject);

        boardScript = GetComponent<BoardManager>();
        InitGame();
    }
    void InitGame()
    {
        boardScript.SetupScenes();
    }
    //플레이어 생성
    private void Start()
    {
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        randomSpawnPos.z = -1f; randomSpawnPos.x += 5f; randomSpawnPos.y += 5f;

        playerInstance = PhotonNetwork.Instantiate(playerPrefab.name, randomSpawnPos, Quaternion.identity);
    }

    //점수 추가 및 UI갱신
    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            UIManager.instance.UpdateScoreText(score);
        }
    }

    public void EndGame()
    {
        isGameover = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PhotonNetwork.LeaveRoom();
    }
    // Update is called once per frame
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }
}
