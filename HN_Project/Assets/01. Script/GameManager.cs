using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region �̱���
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ �Ŵ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� SceneLoadManager�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� SceneLoadManager)�� �������ش�.
            //���� ���� �߰��ϸ� ���� �����ϴ� ��ī����
            Destroy(this.gameObject);
        }
    }

    // �ٸ� Ŭ�������� ���� �����ϰ� ����ƽ ������Ƽ ����(�ν��Ͻ� ��������� �� ��ȯ�ϰ� ������ �װ� ��ȯ
    // private �� instance�� ���̸� �α����� �տ� �빮�ڷ� ��
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
    //======================= ���� �̱��� �ڵ� =======================

    //------------------ ���� �� -------------------
    #region ���� ��
    public static bool SETTING1;
    public static bool SETTING2;
    public static bool SETTING3;
    public static bool SETTING4;

    public static bool GetSetting1() { return SETTING1; }
    public static bool GetSetting2() { return SETTING2; }
    public static bool GetSetting3() { return SETTING3; }
    public static bool GetSetting4() { return SETTING4; }

    #endregion
    //------------------ Ÿ�� �� -------------------
}