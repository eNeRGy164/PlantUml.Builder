using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class LifeLineEventsTests
    {
        [TestMethod]
        [DynamicData(nameof(GetActivations), DynamicDataSourceType.Method)]
        public void ReturnCorrectLifeLineEvent(LifeLineEvents activation, string expected)
        {
            activation.ToString().Should().Be(expected);
        }

        private static IEnumerable<object[]> GetActivations()
        {
            yield return new object[] { LifeLineEvents.None, "" };
            yield return new object[] { LifeLineEvents.Activate, "++" };
            yield return new object[] { LifeLineEvents.ActivateDeactivate, "++--" };
            yield return new object[] { LifeLineEvents.ActivateTarget, "++" };
            yield return new object[] { LifeLineEvents.ActivateTargetDeactivateSource, "++--" };
            yield return new object[] { LifeLineEvents.Create, "**" };
            yield return new object[] { LifeLineEvents.CreateTargetInstance, "**" };
            yield return new object[] { LifeLineEvents.Deactivate, "--" };
            yield return new object[] { LifeLineEvents.DeactivateActivate, "--++" };
            yield return new object[] { LifeLineEvents.DeactivateSource, "--" };
            yield return new object[] { LifeLineEvents.DeactivateSourceActivateTarget, "--++" };
            yield return new object[] { LifeLineEvents.Destroy, "!!" };
            yield return new object[] { LifeLineEvents.DestroyTargetInstance, "!!" };
        }
    }
}
