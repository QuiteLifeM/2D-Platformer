using TMPro;
using UnityEngine;

public class WalletTextView : MonoBehaviour
    {
        [SerializeField] Wallet _wallet;
        [SerializeField] private TextMeshProUGUI tmpText;

        private readonly string _walletText = "Кошелёк";

        private void Awake()
        {
            _wallet.WalletRefilled += UpdateView;
            tmpText.text = $"{_walletText}: {_wallet.Coins}";
        }

        private void UpdateView(int amount)
        {
            tmpText.text = $"{_walletText}: {amount}";
        }
    }
