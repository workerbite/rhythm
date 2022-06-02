using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTool : MonoBehaviour
{

    const float GAP = 9.0f;

    Vector2 _nextPoint;
    [Header("파일이름 세팅해주세요")]
    [SerializeField] string _fileName;

    [Header("게임시작할때 스피드")]
    [Range(0, 100.0f)]
    [SerializeField] float _speed = 10.0f;


    [Header("나머지는 손안대셔도 되요.")]
    [SerializeField] GameObject[] _blockPrefabs;
    [SerializeField] LevelModel _level = new LevelModel();
    [SerializeField] List<GameObject> _blockList = new List<GameObject>();

    
    public void ButtonCreateBlock(BlockModel.Type blockType)
    {
        
        GameObject oj = Instantiate(_blockPrefabs[(int)blockType]);
        oj.transform.position = _nextPoint;
        oj.transform.SetParent(transform);
        _blockList.Add(oj);
        _level.blockList.Add(new BlockModel() { type = blockType });
        _nextPoint.x += GAP;
    }


    public void ButtonClear()
    {
  
            _level.blockList.Clear();
            for (int i = 0; i < _blockList.Count; ++i)
            {
                if (_blockList[i] != null)
                    DestroyImmediate(_blockList[i],true);
            }
            _blockList.Clear();
            _nextPoint = Vector2.zero;
  
    }

    public void ButtonSave()
    {
        string json = JsonUtility.ToJson(_level);
        string path = Application.dataPath + @"\Resources\Map" + @"\" + _fileName + ".json";
        System.IO.File.WriteAllText(path, json);
        
        Debug.Log(string.Format("FileSave \n Path : {0} \n Data : {1}", path, json));

    }

    public void ButtonLoad()
    {
        ButtonClear();
        string path =  @"Map\" +  _fileName;
        string json = Resources.Load<TextAsset>(path).text;
         _level = JsonUtility.FromJson<LevelModel>(json);

        _nextPoint = Vector2.zero;
        for (int i = 0; i < _level.blockList.Count; ++i)
        {
            GameObject oj =  Instantiate( _blockPrefabs[(int)_level.blockList[i].type]);
            oj.transform.position = _nextPoint;
            _blockList.Add(oj);
            oj.transform.SetParent(transform);
            _nextPoint.x += GAP;

        }


    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_nextPoint, 1);
    }


    

    private void FixedUpdate()
    {
        for (int i = 0; i < _blockList.Count; ++i)
        {
            if (_blockList[i] != null)
                _blockList[i].transform.Translate(Vector2.left * Time.fixedDeltaTime * _speed);
        }
    }







}
