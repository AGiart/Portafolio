using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Question[] questions;

    [SerializeField]
    TextMeshProUGUI questionText;

    [SerializeField]
    float timeBetweenQuestions = 1.5F;

    Question _currentQuestion;
    List<Question> _questions;


    void Start()
    {
        
        _questions = new List<Question>(questions);
        GetRandomQuestion();
    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, _questions.Count);
        _currentQuestion = _questions[randomQuestionIndex];

        questionText.text = _currentQuestion.Fact.ToString();   
    }

    public void SelectTrue()
    {
        if (_currentQuestion.isTrue)
        {
            questionText.text = "CORRECTO!";
        }
        else
        {
            questionText.text = "INCORRECTO, SILLA ELECTRICA!";
        }
        StartCoroutine(GoToNextQuestion());
    }
    public void SelectFalse()
    {
        if (!_currentQuestion.isTrue)
        {
            questionText.text = "CORRECTO!";
        }
        else
        {
            questionText.text = "INCORRECTO, SILLA ELECTRICA!";
        }
        StartCoroutine(GoToNextQuestion());
    }
    IEnumerator GoToNextQuestion()
    {
        _questions.Remove( _currentQuestion );
        yield return new WaitForSeconds(timeBetweenQuestions);
        GetRandomQuestion() ;
    }
}
