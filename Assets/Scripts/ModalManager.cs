using UnityEngine;

public class ModalManager : MonoBehaviour
{
    public static ModalManager Instance;
    [SerializeField] private GameObject loserModal;
    [SerializeField] private GameObject winnerModal;
    [SerializeField] private GameObject endGameModal;

    public enum ModalType
    {
        Loser,
        Winner,
        EndGame,
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
        if (endGameModal) endGameModal.SetActive(false);
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
            case ModalType.EndGame:
                if (endGameModal) endGameModal.SetActive(true);
                break;
            default:
                Debug.Log($"O modalType: {modalType} é inválido!");
                break;
        }
    }
}
