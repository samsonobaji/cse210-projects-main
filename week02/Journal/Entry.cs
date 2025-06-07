using System;
using System.Text.Json;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;
    public int _wordCount;

    public Entry(string date, string prompt, string response, string mood = "")
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _wordCount = response.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public string GetDisplayString()
    {
        string moodDisplay = string.IsNullOrEmpty(_mood) ? "" : $"\nMood: {_mood}";
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}{moodDisplay}\nWord Count: {_wordCount}\n";
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Entry FromJson(string json)
    {
        return JsonSerializer.Deserialize<Entry>(json);
    }
} 