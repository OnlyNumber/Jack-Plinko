using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class BallSpawner : MonoBehaviour
{
    public int BallsCount;

    private int _currentBallCount;

    private Vector2 _firstPos;

    [SerializeField]
    private float _radius;

    [SerializeField]
    private Rigidbody2D _prefabBall;

    [SerializeField]
    private Rigidbody2D _currentBall;

    [SerializeField]
    private TMP_Text _ballCount;

    [SerializeField]
    private TMP_Text _totalWinText;

    [SerializeField]
    private PanelControl _winPanel;

    [SerializeField]
    private PanelControl _betPanel;

    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private UnityEngine.UI.Image IconImage;

    private PlayerData _playerData;

    [SerializeField]
    private float _forcePower;

    public float TotalWin;

    public bool IsGame;

    public float BallPrice;

    private List<Rigidbody2D> _ballsPool = new List<Rigidbody2D>();

    public System.Action OnWin;


    [Inject]
    public void Initialize(PlayerData playerData)
    {
        _playerData = playerData;

        Debug.Log(_playerData.CurrentSkin[(int)PlayerSkinType.ball]);

        IconImage.sprite = _skinInfos[_playerData.CurrentSkin[(int)PlayerSkinType.ball]].SkinSprite;

    }

    public void Initialize(int ballsCount, float totalBet)
    {
        BallsCount = ballsCount;

        _currentBallCount = BallsCount;

        BallPrice = totalBet / ballsCount;

        TotalWin = 0;
        _ballCount.text = _currentBallCount + " / " + BallsCount;
    }

    private void Update()
    {
        if (Input.touchCount <= 0 || !IsGame || _currentBallCount <= 0)
        {
            return;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _currentBall = Instantiate(_prefabBall, transform);

            _currentBall.GetComponent<SpriteRenderer>().sprite = _skinInfos[_playerData.CurrentSkin[(int)PlayerSkinType.ball]].SkinSprite;

            _currentBall.bodyType = RigidbodyType2D.Kinematic;

            _currentBall.velocity = Vector2.zero;

            _firstPos = Input.GetTouch(0).position;
            _ballsPool.Add(_currentBall);

        }

        if (_currentBall)
        {
            _currentBall.gameObject.transform.localPosition = _radius * GetDirection(_firstPos, Input.GetTouch(0).position);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended && _currentBall)
        {
            _currentBall.bodyType = RigidbodyType2D.Dynamic;
            _currentBall.AddForce(GetDirection(_firstPos, Input.GetTouch(0).position) * _forcePower, ForceMode2D.Impulse);
            _currentBallCount--;
            _ballCount.text = _currentBallCount + " / " + BallsCount;

        }
    }

    public Vector2 GetDirection(Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 dif = secondPos - firstPos;
        dif.Normalize();

        return dif;
    }

    public float GetAngle(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        return angle;
    }

    public void SetRewardWithCoeficient(float coeficient, Rigidbody2D ball)
    {
        _playerData.TryChangeValueCoin(BallPrice * coeficient);


        TotalWin += BallPrice * coeficient;

        _ballsPool.Remove(ball);

        if (_currentBallCount <= 0 && _ballsPool.Count == 0)
        {
            OnWin?.Invoke();

            ShowWinPanel();
        }

    }

    public void ShowWinPanel()
    {


        _winPanel.SetPanel(true);
        _totalWinText.text = TotalWin.ToString();
        IsGame = false;
    }

    public void RestartGame()
    {
        _winPanel.SetPanel(false);
        _betPanel.SetPanel(true);
    }


}
