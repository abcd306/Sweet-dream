using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �̰Ŷ� ���� ��ũ��Ʈ ����, ���� - ����Ʈ���� ����
public class CoinBurst : MonoBehaviour
{
    private ParticleSystem coinParticle;

        void Start()
        {
            coinParticle = GetComponent<ParticleSystem>();
        }
}
