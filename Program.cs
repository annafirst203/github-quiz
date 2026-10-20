using System.Text;
using GitHubQuiz;

Console.OutputEncoding = Encoding.UTF8;

Print("=== GitHub-квиз ===", ConsoleColor.Cyan);
Console.WriteLine($"Вопросов: {Questions.All.Count}. Отвечай номером варианта и нажимай Enter.");
Console.WriteLine();

int correct = 0;
var timer = System.Diagnostics.Stopwatch.StartNew();
for (int i = 0; i < Questions.All.Count; i++)
{
    Question q = Questions.All[i];
    Console.WriteLine($"{i + 1}. {q.Text}");
    for (int k = 0; k < q.Options.Length; k++)
        Console.WriteLine($"   {k + 1}) {q.Options[k]}");

    int answer = AskNumber(1, q.Options.Length);
    if (answer == q.Correct)
    {
        correct++;
        Print("Верно!", ConsoleColor.Green);
    }
    else
    {
        Print($"Неверно. Правильный ответ: {q.Correct}) {q.Options[q.Correct - 1]}", ConsoleColor.Red);
    }
    Console.WriteLine();
}

int total = Questions.All.Count;
int percent = correct * 100 / total;
Print($"Итог: {correct} из {total} — {percent}% за {(int)timer.Elapsed.TotalSeconds} с", ConsoleColor.Yellow);
Print(percent >= 80 ? "Отлично, GitHub тебе по плечу!" : "Перечитай слайды лекции и попробуй ещё раз.", ConsoleColor.Cyan);

// Спрашивает число от min до max, пока не введут правильно.
static int AskNumber(int min, int max)
{
    while (true)
    {
        Console.Write("Твой ответ: ");
        string? line = Console.ReadLine();
        if (line is null)
            Environment.Exit(0);
        if (int.TryParse(line, out int n) && n >= min && n <= max)
            return n;
        Print($"Введи число от {min} до {max}.", ConsoleColor.DarkYellow);
    }
}

static void Print(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}
