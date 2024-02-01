using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Coins { get; private set; } = 0;

    public event Action<int> WalletRefilled;

    public void Refill(int amount)
    {
        Coins += amount;
        WalletRefilled?.Invoke(Coins);
    }
}