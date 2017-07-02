﻿using NFluent;
using TechTalk.SpecFlow;

namespace YAGLi.Specs.Validators
{
    [Binding]
    public class BooleanValidator
    {
        public bool Subject { get; set; }

        [Then(@"I get the answer true")]
        public void ThenIGetTheAnswerTrue()
        {
            Check.That(Subject).IsTrue();
        }

        [Then(@"I get the answer false")]
        public void ThenIGetTheAnswerFalse()
        {
            Check.That(Subject).IsFalse();
        }
    }
}