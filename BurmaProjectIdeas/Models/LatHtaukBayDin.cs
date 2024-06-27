﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurmaProjectIdeas.Models;

public class LatHtaukBayDinDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}
