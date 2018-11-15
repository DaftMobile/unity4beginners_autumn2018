
    public class LeftInputAdapter : IInput
    {
        public bool GetKey(string input)
        {
            return input == "a";
        }
    }
