using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChessboardGenerator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private RectTransform boardParent;
    [SerializeField] private Color color1 = Color.white;
    [SerializeField] private Color color2 = Color.black;

    public void GenerateChessboard()
    {
        ResetPreviousBoard();

        int size = int.Parse(inputSize.text);

        float tileSize = Mathf.Min(boardParent.rect.width / size, boardParent.rect.height / size);

        float boardWidth = tileSize * size;
        float boardHeight = tileSize * size;
        float startX = -boardWidth / 2f + tileSize / 2f;
        float startY = boardHeight / 2f - tileSize / 2f;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject tile = Instantiate(tilePrefab, boardParent);
                RectTransform tileRect = tile.GetComponent<RectTransform>();
                tileRect.sizeDelta = new Vector2(tileSize, tileSize);

                tileRect.anchoredPosition = new Vector2(startX + j * tileSize, startY - i * tileSize);

                Image tileImage = tile.GetComponent<Image>();
                tileImage.color = (i + j) % 2 == 0 ? color1 : color2;
            }
        }
    }

    void ResetPreviousBoard()
    {
        foreach (Transform child in boardParent)
        {
            Destroy(child.gameObject);
        }
    }
}
