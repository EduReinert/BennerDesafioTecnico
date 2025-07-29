public class Network
{
    private int numberOfElements;
    private List<int[]> connectionsList;
    private Dictionary<int, List<int>> connectionsMap;

    public List<int[]> ConnectionsList
    {
        get { return connectionsList; }
        set { connectionsList = value; }
    }

    public Network(int numberOfElements)
    {
        try
        {
            if (numberOfElements <= 0)
            {
                throw new ArgumentException("Invalid parameter; number must be a positive value (greater than 0)");
            }

            this.numberOfElements = numberOfElements;
            this.connectionsList = new List<int[]>();
            this.connectionsMap = new Dictionary<int, List<int>>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Connect(int firstElement, int secondElement)
    {
        try
        {
            IsParametersInRange(firstElement, secondElement);

            if (IsDirectConnectionAlreadyEstablished(firstElement, secondElement))
            {
                throw new Exception($"Connection was already established between values {firstElement} and {secondElement}");
            }

            int[] connection = { firstElement, secondElement };
            connectionsList.Add(connection);
            
            connectionsMap[firstElement].Add(secondElement);
            connectionsMap[secondElement].Add(firstElement);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public bool Query(int firstElement, int secondElement)
    {
        try
        {
            IsParametersInRange(firstElement, secondElement);

            return IsElementsConnected(firstElement, secondElement);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return false;
    }

    //
    //
    // MÉTODOS AUXILIARES
    //
    //

    private void IsParametersInRange(int firstElement, int secondElement)
    {
        if (
            (firstElement <= 0 || secondElement <= 0) ||
            (firstElement > this.numberOfElements || secondElement > this.numberOfElements))
        {
            throw new ArgumentException($"Invalid parameter; both numbers must be greater than 0 and equal or lower than {this.numberOfElements}");
        }
    }

    private bool IsElementsConnected(int firstElement, int secondElement)
    {
        if (IsDirectConnectionAlreadyEstablished(firstElement, secondElement))
        {
            return true;
        }

        bool firstElementContainConnection = false;
        bool secondElementContainConnection = false;
        foreach (int[] connection in connectionsList)
        {
            if (connection[0] == firstElement || connection[1] == firstElement)
            {
                firstElementContainConnection = true;
            }

            if (connection[0] == secondElement || connection[1] == secondElement)
            {
                secondElementContainConnection = true;
            }
        }

        if (firstElementContainConnection || secondElementContainConnection)
        {
            return IsElementsConnectedIndirectly(firstElement, secondElement);
        }

        return false;
    }

    private bool IsDirectConnectionAlreadyEstablished(int firstElement, int secondElement)
    {
        foreach (int[] connection in connectionsList)
        {
            if (
                (connection[0] == firstElement && connection[1] == secondElement) ||
                (connection[0] == secondElement && connection[1] == firstElement)
            )
            {
                return true;
            }
        }

        return false;
    }

    private bool IsElementsConnectedIndirectly(int firstElement, int secondElement)
    {
        List<int> numbersConnectedToFirstElementList = ConnectionsToElement(firstElement);
        List<int> numbersConnectedToSecondElementList = ConnectionsToElement(secondElement);

        foreach (int number in numbersConnectedToFirstElementList)
        {
            if (numbersConnectedToSecondElementList.Contains(number))
            {
                return true;
            }
        }

        return false;
    }

    private List<int> ConnectionsToElement(int element)
    {
        List<int> numbersList = new List<int>();

        foreach (int[] connection in connectionsList)
        {
            if (connection[0] == element)
            {
                numbersList.Add(connection[1]);
            }
            else if (connection[1] == element)
            {
                numbersList.Add(connection[0]);
            }
        }

        return numbersList;
    }
}
