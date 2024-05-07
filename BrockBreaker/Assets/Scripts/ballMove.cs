using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public float speed = 7f;
    public int breakCount_; //�j�󂵂��u���b�N��

    Rigidbody b_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        breakCount_ = 0; //������
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ballStart(float x, float y, float z, GameObject gameObject) //�w��ʒu����̃{�[�����ˁi�X�e�[�W�J�n���j
    {
        gameObject.transform.position = new Vector3(x, y, z);
        b_rigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        b_rigidbody.velocity = new Vector3(speed, speed, 0);
    }

    private void OnCollisionEnter(Collision collision) //�j�󂵂��u���b�N�����J�E���g
    {
        if (collision.gameObject.tag == "block")
        {
            breakCount_++;
        }
    }

    public int blockBreakCount() //�j�󂵂��u���b�N����Ԃ�
    {
        return breakCount_;
    }
}
