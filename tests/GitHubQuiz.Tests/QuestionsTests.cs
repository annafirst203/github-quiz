namespace GitHubQuiz.Tests;

// Тесты проверяют данные квиза: все вопросы из Questions.All.
public class QuestionsTests
{
    [Fact]
    public void EveryQuestionHasTextAndOptions()
    {
        foreach (Question q in Questions.All)
        {
            Assert.False(string.IsNullOrWhiteSpace(q.Text), "Есть вопрос без текста");
            Assert.True(q.Options.Length >= 2, $"Вопрос «{q.Text}»: вариантов меньше двух");
        }
    }

    [Fact]
    public void CorrectAnswerIsOneOfTheOptions()
    {
        foreach (Question q in Questions.All)
            Assert.True(q.Correct >= 1 && q.Correct <= q.Options.Length,
                $"Вопрос «{q.Text}»: правильный ответ {q.Correct}, а вариантов {q.Options.Length}");
    }

    [Fact]
    public void QuestionsAreNotRepeated()
    {
        var texts = Questions.All.Select(q => q.Text).ToList();
        Assert.Equal(texts.Count, texts.Distinct().Count());
    }
}
