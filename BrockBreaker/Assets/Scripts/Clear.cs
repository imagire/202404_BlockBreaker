using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] GameObject[] stage; //���ꂼ��̃X�e�[�W�̃u���b�N���A��I�u�W�F�N�g�z��Ɋi�[���A���̕\���ؑւŃX�e�[�W�J�ڂ��s���Ă���B
    [SerializeField] ballMove ballMove;
    public GameObject ball;

    public bool clear_;
    public int speed = 5;
    private int stageCount;


    // Start is called before the first frame update
    void Start()
    {
        stage[0].SetActive(true); //�ŏ��̃X�e�[�W��\��
        ballMove.ballStart(0, -1.77f, 0, ball); //�{�[���̔���
    }

    // Update is called once per frame
    void Update()
    {
        if (stage[stageCount].transform.childCount == 0)//�u���b�N��S�ĉ󂵂���i��I�u�W�F�N�g�i�e�j�̒��̎q�I�u�W�F�N�g�i���̃X�e�[�W�̃u���b�N�j������c���Ă��Ȃ����j
        {
            clear();
            ballMove.ballStart(0, -1.77f, 0, ball); //clear()�ł̃X�e�[�W�J�ڌ�A�{�[���𔭎�
        }
    }   

    void clear() //�X�e�[�W���N���A�����Ƃ��Ɏ��s����֐��i3�X�e�[�W�����Ȃ��j
    {
        stageCount++;

        if (stageCount < 3) //�܂��X�e�[�W������΁A���̃X�e�[�W�ɑJ��
        {
            ball.SetActive(false);
            stage[stageCount - 1].SetActive(false);
            
            stage[stageCount].SetActive(true);
        }
        else //�S�ẴX�e�[�W���N���A������A�Q�[�����I��
        {
            EndGame();
        }
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
