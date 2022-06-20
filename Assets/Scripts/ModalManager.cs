using UnityEngine;

public class ModalManager : MonoBehaviour
{
    public static ModalManager Instance;
    [SerializeField] private GameObject loserModal;
    [SerializeField] private GameObject winnerModal;

    public enum ModalType
    {
        Winner,
        Loser
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (loserModal) loserModal.SetActive(false);
        if (winnerModal) winnerModal.SetActive(false);
    }

    public void ShowModal(ModalType modalType)
    {
        switch (modalType)
        {
            case ModalType.Loser:
                if (loserModal) loserModal.SetActive(true);
                break;
            case ModalType.Winner:
                if (winnerModal) winnerModal.SetActive(true);
                break;
        }
    }
}
