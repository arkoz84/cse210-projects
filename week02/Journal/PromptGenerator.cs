using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see God's hand in my life today?",
        "What are three things I am grateful for today?",
        "What could I have done differently today?",
        "Who did you thank today? How did they impact your day?",
        "What was one struggle and how did you face it?",
        "What small moment from today do I want to remember?",
        "When did I feel most at peace today?",
        "What did I learn about myself today?",
        "Who helped me today, and what did their help mean to me?",
        "How did I make someone else's day a little better?",
        "When did I feel God's guidance or comfort today?",
        "What made me laugh or smile today?",
        "What did I do today that took courage?",
        "What surprised me today, and how did I respond?",
        "What is one thing I handled better than I would have a year ago?",
        "What did I give my time to today that felt worthwhile?",
        "What is one thing I want to make time for tomorrow?",
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

