public class Network
{
    private int _numberOfElements;
    private Dictionary<int, List<int>> _connectionsMap;
    
    public Dictionary<int, List<int>> ConnectionsMap
    {
        get { return _connectionsMap; }
        set { _connectionsMap = value; }
    }
    

    public Network(int numberOfElements)
    {
        try
        {
            if (numberOfElements <= 0)
            {
                throw new ArgumentException("Invalid parameter; number must be a positive value (greater than 0)");
            }

            _numberOfElements = numberOfElements;
            _connectionsMap = new Dictionary<int, List<int>>();

            for (int i = 1; i <= _numberOfElements; i++)
            {
                _connectionsMap[i] = new List<int>();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }

    public void Connect(int firstElement, int secondElement)
    {
        try
        {
            IsParametersInRange(firstElement, secondElement);

            if (firstElement == secondElement)
            {
                throw new ArgumentException("Invalid parameter; elements must not be equal");
            }
            
            if (IsDirectConnectionAlreadyEstablished(firstElement, secondElement))
            {
                throw new Exception($"Connection was already established between values " +
                                    $"{firstElement} and " + $"{secondElement}");
            }
            
            _connectionsMap[firstElement].Add(secondElement);
            _connectionsMap[secondElement].Add(firstElement);
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
            if (firstElement == secondElement)
            {
                throw new ArgumentException("Invalid parameter; elements must not be equal");
            }
            
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
            (firstElement > _numberOfElements || secondElement > _numberOfElements))
        {
            throw new ArgumentException($"Invalid parameter; both numbers must be greater than 0 " +
                                        $"and equal or lower than {_numberOfElements}");
        }
    }

    private bool IsElementsConnected(int firstElement, int secondElement)
    {
        return IsDirectConnectionAlreadyEstablished(firstElement, secondElement) 
               || IsElementsConnectedIndirectly(firstElement, secondElement);
    }

    private bool IsDirectConnectionAlreadyEstablished(int firstElement, int secondElement)
    {
        if (_connectionsMap.ContainsKey(firstElement))
        {
            return _connectionsMap[firstElement].Contains(secondElement);
        }
        return false;
    }

    private bool IsElementsConnectedIndirectly(int firstElement, int secondElement)
    {
        List<int> checkingList = new List<int>();
        int initialElement = firstElement;
        PopulateCheckingList(firstElement, initialElement, checkingList);

        return checkingList.Contains(secondElement);
    }

    private void PopulateCheckingList(int firstElement, int initialElement, List<int> checkingList)
    {
        foreach (int number in _connectionsMap[firstElement])
        {
            if (!checkingList.Contains(number) && number != initialElement)
            {
                checkingList.Add(number);
                PopulateCheckingList(number, initialElement, checkingList);
            }
        }
    }
}
