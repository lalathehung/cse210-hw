class Scripture
{
    private Reference _scriptureReference;
    private string _scriptureText;

    public Scripture(Reference scriptureReference, string scriptureText)
    {
        _scriptureReference = scriptureReference;
        _scriptureText = scriptureText;
    }

    public string GetText()
    {
        return _scriptureText;
    }

    public string GetReference()
    {
        return _scriptureReference.GetReference();
    }
}