namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ArrowExtensionsTests
{
    [DynamicData(nameof(GetArrowExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetArrowExtensionMethodsDisplayName))]
    [TestMethod]
    public void ExtensionMethodsShouldNotWorkOnANullArrow(string methodName, object[] methodParameters = null)
    {
        // Arrange
        Arrow arrow = null;

        var method = typeof(ArrowExtensions).GetMethod(methodName);
        var parameters = new List<object> { arrow };
        parameters.AddRange(methodParameters ?? Array.Empty<object>());

        // Act
        Action action = () => method.Invoke(null, parameters.ToArray());

        // Assert
        action.ShouldThrowExactly<TargetInvocationException>()
            .ShouldHaveInnerExceptionExactly<ArgumentNullException>()
            .WithParameterName("arrow");
    }

    private static IEnumerable<object[]> GetArrowExtensionMethods()
    {
        yield return new object[] { nameof(ArrowExtensions.Color), new object[] { (Color)NamedColor.Red } };
        yield return new object[] { nameof(ArrowExtensions.Destroy) };
        yield return new object[] { nameof(ArrowExtensions.Dotted) };
        yield return new object[] { nameof(ArrowExtensions.ExternalLeft) };
        yield return new object[] { nameof(ArrowExtensions.ExternalRight) };
        yield return new object[] { nameof(ArrowExtensions.IsExternalLeft) };
        yield return new object[] { nameof(ArrowExtensions.IsExternalRight) };
        yield return new object[] { nameof(ArrowExtensions.Lost) };
        yield return new object[] { nameof(ArrowExtensions.LostLeft) };
        yield return new object[] { nameof(ArrowExtensions.LostRight) };
        yield return new object[] { nameof(ArrowExtensions.Solid) };
    }

    public static string GetArrowExtensionMethodsDisplayName(MethodInfo _, object[] data) => $"Extension method \"{data[0]}\" should throw an argument exception when arrow is `null`";

    [DataRow("->", null, "->", DisplayName = "A `null` color should change nothing")]
    [DataRow("->", NamedColor.Red, "-[#Red]>", DisplayName = "The arrow should become colored")]
    [DataRow("-[#Orange]>", NamedColor.Blue, "-[#Blue]>", DisplayName = "The arrow should change colors")]
    [DataRow("[->", NamedColor.Yellow, "[-[#Yellow]>", DisplayName = "The incoming arrow should change color")]
    [TestMethod]
    public void ChangeTheColorOfTheArrow(string original, NamedColor? color, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        // Act
        var arrow = originalArrow.Color(color);

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    [DataRow("->", "-->", DisplayName = "A solid arrow line should become a dotted line")]
    [DataRow("-->", "-->", DisplayName = "A dotted arrow line should stay a dotted line")]
    [DataRow("--->", "-->", DisplayName = "A long dotted arrow line should become a short dotted line")]
    [DataRow("[->", "[-->", DisplayName = "An incoming solid arrow line should become a dotted line")]
    [TestMethod]
    public void EnsureTheLineIsDotted(string original, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        // Act
        var arrow = originalArrow.Dotted();

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    [DataRow("x<-", "Lost", DisplayName = "If the left side is already deleted, it can't become lost")]
    [DataRow("[x<-", "Lost", DisplayName = "If the left side is already deleted, it can't become lost")]
    [DataRow("->x", "Lost", DisplayName = "If the right side is already deleted, it can't become lost")]
    [DataRow("->x]", "Lost", DisplayName = "If the right side is already deleted, it can't become lost")]
    [DataRow("x->", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
    [DataRow("[x->", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
    [DataRow("x-x", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
    [DataRow("<-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
    [DataRow("<-x]", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
    [DataRow("x-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
    [TestMethod]
    public void TheDeletedSideCannotBecomeLost(string original, string methodName)
    {
        // Arrange
        Arrow originalArrow = original;

        var method = typeof(ArrowExtensions).GetMethod(methodName);
        var lostFunction = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

        // Act
        Action action = () => lostFunction(originalArrow);

        // Assert
        action.ShouldThrowExactly<NotSupportedException>()
            .WithMessage("You cannot combine the \"lost\" and \"deleted\" message notation in the same arrow head.");
    }

    [DataRow("<-", "LostLeft", "o<-", DisplayName = "Arrow to the left is lost")]
    [DataRow("->", "LostLeft", "o->", DisplayName = "Arrow to the right is found")]
    [DataRow("-->", "LostLeft", "o-->", DisplayName = "Dotted arrow to the right is found")]
    [DataRow("[->", "LostLeft", "[o->", DisplayName = "Incomming arrow to the right is lost")]
    [DataRow("?->", "LostLeft", "?o->", DisplayName = "Short incomming arrow to the right is lost")]
    [DataRow("o-->", "LostLeft", "o-->", DisplayName = "Dotted arrow to the right stays lost")]
    [DataRow("[o->", "LostLeft", "[o->", DisplayName = "Incomming arrow to the right stays lost")]
    [DataRow("->", "LostRight", "->o", DisplayName = "Arrow to the right is lost")]
    [DataRow("<-", "LostRight", "<-o", DisplayName = "Arrow to the left is found")]
    [DataRow("<--", "LostRight", "<--o", DisplayName = "Dotted arrow to the left is found")]
    [DataRow("<-]", "LostRight", "<-o]", DisplayName = "Incomming arrow to the left is lost")]
    [DataRow("<-?", "LostRight", "<-o?", DisplayName = "Short incomming arrow to the left is lost")]
    [DataRow("<--o", "LostRight", "<--o", DisplayName = "Dotted arrow to the left stays lost")]
    [DataRow("<-o]", "LostRight", "<-o]", DisplayName = "Incomming arrow to the left stays lost")]
    [DataRow("->", "Lost", "->o", DisplayName = "Arrow to the right is lost")]
    [DataRow("<-", "Lost", "o<-", DisplayName = "Arrow to the left is lost")]

    [TestMethod]
    public void AddTheLostNotationOnTheLeftOfTheArrowOnce(string original, string methodName, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        var method = typeof(ArrowExtensions).GetMethod(methodName);
        var function = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

        // Act
        var arrow = function(originalArrow);

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    [DataRow("->", "->", DisplayName = "A solid arrow line should stay a solid line")]
    [DataRow("-->", "->", DisplayName = "A dotted arrow line should become a solid line")]
    [DataRow("--->", "->", DisplayName = "A long dotted arrow line should become a short solid line")]
    [DataRow("[-->", "[->", DisplayName = "An incomming dotted arrow line should become a solid line")]
    [TestMethod]
    public void EnsureTheLineIsSolid(string original, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        // Act
        var arrow = originalArrow.Solid();

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    [DataRow("->", "->x", DisplayName = "A message to the right is deleted")]
    [DataRow("<-", "x<-", DisplayName = "A message to the left is deleted")]
    [DataRow("<--", "x<--", DisplayName = "A dotted message is deleted")]
    [DataRow("//--", "x//--", DisplayName = "A thin bottom message is deleted")]
    [DataRow("<--o", "x<--o", DisplayName = "A found message is deleted")]
    [DataRow("x<--o", "x<--o", DisplayName = "A deleted message to the left stays deleted")]
    [DataRow("x--", "x--", DisplayName = "A deleted message to the left stays deleted")]
    [DataRow("--x", "--x", DisplayName = "A deleted message to the right stays deleted")]
    [DataRow("-->x", "-->x", DisplayName = "A deleted message to the right stays deleted")]
    [TestMethod]
    public void DestroyTheMessageInTheDirectionOfTheArrow(string original, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        // Act
        var arrow = originalArrow.Destroy();

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    [DataRow("<->", "Lost", DisplayName = "A left-right arrow has both directions")]
    [DataRow("<-->", "Lost", DisplayName = "A dotted left-right arrow has both directions")]
    [DataRow("x-x", "Lost", DisplayName = "A left-right destroyed arrow has both directions")]
    [DataRow("<->", "Destroy", DisplayName = "A left-right arrow has both directions")]
    [DataRow("<-->", "Destroy", DisplayName = "A dotted left-right arrow has both directions")]
    [DataRow("x-x", "Destroy", DisplayName = "A left-right destroyed arrow has both directions")]
    [TestMethod]
    public void MethodsOnlyWorkIfTheArrowIsToTheLeftOrRight(string original, string methodName)
    {
        // Arrange
        Arrow originalArrow = original;

        var method = typeof(ArrowExtensions).GetMethod(methodName);
        var function = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

        // Act
        Action act = () => function(originalArrow);

        // Assert
        act.ShouldThrowExactly<NotSupportedException>()
            .WithMessage("This method only * an arrow if it is in a clear left or right direction.");
    }

    [DataRow("->", "ExternalRight", "->]", DisplayName = "The message will leave the diagram on the right")]
    [DataRow("<-", "ExternalRight", "<-]", DisplayName = "The message will come in from the right")]
    [DataRow("<---]", "ExternalRight", "<--]", DisplayName = "The message keeps comming in from the right")]
    [DataRow("<-?", "ExternalRight", "<-?", DisplayName = "The short message keeps comming in from the right")]
    [DataRow("<[#Blue]---]", "ExternalRight", "<--[#Blue]]", DisplayName = "The colored message keeps comming in from the right")]
    [DataRow("<-", "ExternalLeft", "[<-", DisplayName = "The message will leave the diagram on the left")]
    [DataRow("->", "ExternalLeft", "[->", DisplayName = "The message will come in from the left")]
    [DataRow("[--->", "ExternalLeft", "[-->", DisplayName = "The message keeps comming in from the left")]
    [DataRow("?-->", "ExternalLeft", "?-->", DisplayName = "The short message keeps comming in from the left")]
    [TestMethod]
    public void MakeArrowIncommingOrOutgoing(string original, string methodName, string expected)
    {
        // Arrange
        Arrow originalArrow = original;

        var method = typeof(ArrowExtensions).GetMethod(methodName);
        var function = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

        // Act
        var arrow = function(originalArrow);

        // Assert
        arrow.ToString().ShouldBe(expected);
    }
}
