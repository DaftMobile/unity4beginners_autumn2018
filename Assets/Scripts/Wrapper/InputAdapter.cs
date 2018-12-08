using UnityEngine;

public class InputAdapter : IInput
{
    public bool GetKey(string input)
    {
        return Input.GetKey(input);
    }

}