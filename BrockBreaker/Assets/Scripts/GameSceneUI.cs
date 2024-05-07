using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI; //�Q�[���I�[�o�[����UI
    [SerializeField] GameObject gameSceneUI; //��ʍ���ɏ�ɕ\������Ă���UI�i�_���ƃ��C�t���j
    [SerializeField] GameObject ball; //�Q�[���I�[�o�[���ɁA�{�[�����\���ɂ��邽�߂ɎQ��
    [SerializeField] ballMove ballMove;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifeText;

    private int playerLife_;
    private string title;

    // Start is called before the first frame update
    void Start()
    {
        playerLife_ = 3;
        title = "Title";
        gameOverUI.SetActive(false);
        gameSceneUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //�C���Q�[�����ɉf���Ă���UI�̍X�V

        scoreText.SetText("Score:{0}", ballMove.blockBreakCount());
        lifeText.SetText("Life:{0}", playerLife_);
    }

    private void OnCollisionEnter(Collision collision) //�{�[�������ɗ��������̏���
    {
        if (collision.gameObject.tag == "ball")
        {
            playerLife_--; //�c�@�����炷
            if (playerLife_ == 0) //�v���C���[�̎c�@��0�ɂȂ����Ƃ��A�Q�[���I�[�o�[UI��\��
            {
                gameSceneUI.SetActive(false);
                showGameOver();
            }
            else //�ēx�{�[���𔭎ˁi���g���C�j
            {
                ballMove.ballStart(0, -1.77f, 0, ball);
            }     
        }
    }

    void showGameOver() //�Q�[���I�[�o�[UI�\���֐�
    {
        gameOverUI.SetActive(true);
        ball.SetActive(false);
    }

    public void OnBackButtonClick() //�Q�[���I�[�o�[��ʂ̃{�^���֐�(OnClick())
    {
        SceneManager.LoadScene(title);
    }
}
