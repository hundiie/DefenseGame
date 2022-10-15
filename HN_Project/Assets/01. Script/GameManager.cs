using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 SceneLoadManager가 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 SceneLoadManager)을 삭제해준다.
            //지가 지를 발견하면 지를 삭제하는 메카니즘
            Destroy(this.gameObject);
        }
    }

    // 다른 클래스에서 쉽게 접근하게 스태틱 프로퍼티 생성(인스턴스 비어있으면 널 반환하고 있으면 그걸 반환
    // private 의 instance와 차이를 두기위해 앞에 대문자로 씀
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    //======================= 위쪽 싱글톤 코드 =======================

    //------------------ 설정 값 -------------------
    #region 설정 값
    public static bool SETTING1;
    public static bool SETTING2;
    public static bool SETTING3;
    public static bool SETTING4;

    public static bool GetSetting1() { return SETTING1; }
    public static bool GetSetting2() { return SETTING2; }
    public static bool GetSetting3() { return SETTING3; }
    public static bool GetSetting4() { return SETTING4; }

    #endregion
    //------------------ 타워 값 -------------------
}